using Capstone_Referecne_GameServer.Client;
using Capstone_Referecne_GameServer.TCP;
using Capstone_Reference_Game_Module;
using System.Collections.Concurrent;

// -----------------
// ----- 서버 ------
// -----------------

namespace Capstone_Referecne_GameServer
{
    public class GameServerManager
    {
        //public static Program program = Program.GetInstance();

        // TCP 서버를 관리하고 클라이언트와 통신하는 객체
        private MyServer server;

        // 메시지 처리하는
        private Thread messageProcess_thread;

        // 수신받은 메시지 보관하는 큐
        ConcurrentQueue<KeyValuePair<ClientCharacter, byte[]>> messageQueue;


        // 로그인한 클라이언트들을 관리하는 객체
        public ClientManager clientManager { get; }

        // 비로그인 클라이언트 관리 객체
        public ClientManager guestClientManager { get;}

        // 메시지 처리하는 객체
        private MessageManager messageManager;

        // 서버와 클라이언트가 계속 연결되어있는지 확인하기 위해 일정시간마다 가짜 메시지를 보냄
        private Timer HeartBeatTimer;

        // 하나의 클라이언트가 여러번 나가는거를 막기위한 세마포
        private Semaphore sema_ClientLeave;

        // 메시지가 없으면 대기하기 위한 락 오브젝트
        object lockObject = new object();

        static void Main(string[] args)
        {
            GameServerManager program = new GameServerManager();
            program.Start();
            Console.WriteLine("[INFO] 서버가 시작되었습니다.");
            while (true)
            {
                string[] command = Console.ReadLine()!.Split(' ');
                program.server.server.Stop();
                try
                {
                    switch (command[0])
                    {
                        /*
                        case "/r":
                            {
                                // 게임 강제 시작 및 맵 변경
                                if (command.Length >= 2 && command.Length <= 3)
                                {
                                    int roomKey = int.Parse(command[1]);
                                    Room room;
                                    bool result = program.roomManager.RoomDic.TryGetValue(roomKey, out room);
                                    if (result == false)
                                    {
                                        throw new Exception("[ERROR] 존재하지 않은 방입니다.");
                                    }

                                    int stageNum = 1;

                                    if (command.Length == 3)
                                    {
                                        stageNum = int.Parse(command[2]);
                                    }

                                    if (room.IsGameStart == false)
                                        room.GameStart();
                                    room.MapChange(stageNum);

                                    Console.WriteLine("[INFO] " + roomKey + "번 방을 시작하였습니다.");
                                }
                                else throw new Exception("[ERROR] 올바르지 않은 매개변수 개수입니다.");


                            }
                            break;
                        */
                        default:
                            Console.WriteLine("[ERROR] 알수없는 명령어입니다.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("[ERROR] 올바르지 않은 매개변수 형식입니다.");
                    continue;
                }
                catch (ArgumentNullException)
                {
                    Console.WriteLine("[ERROR] 매개변수가 존재하지 않습니다.");
                    continue;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    continue;
                }
            }
        }

        /*
        public static Program GetInstance()
        {
            if (program == null)
            {
                program = new Program();
            }
            return program;
        }
        */

        private GameServerManager()
        {
            server = new MyServer();
            server.onClientJoin += new ClientJoinEventHandler(ClientJoin);
            server.onDataRecieve += new DataRecieveEventHandler(onDataRecieve);

            clientManager = new ClientManager();
            guestClientManager = new ClientManager();

            sema_ClientLeave = new Semaphore(1, 1);

            messageQueue = new ConcurrentQueue<KeyValuePair<ClientCharacter, byte[]>>();
            messageProcess_thread = new Thread(MessageProcess);
            messageManager = new MessageManager(this);

            // 서버와 클라이언트가 계속 연결되어있는지 확인하기 위해 일정시간마다 가짜 메시지를 보내는 타이머
            TimerCallback tc = new TimerCallback(HeartBeat);
            HeartBeatTimer = new System.Threading.Timer(tc, null, Timeout.Infinite, Timeout.Infinite);


        }

        ~GameServerManager()
        {
            HeartBeatTimer.Dispose();
        }

        public void Start()
        {
            server.Start();
            HeartBeatTimer.Change(0, 30000);
            messageProcess_thread.Start();
        }

        // 서버와 클라이언트가 계속 연결되어있는지 확인하기 위해 일정시간마다 가짜 메시지를 보냄
        private void HeartBeat(object? t)
        {
            MessageGenerator generator = new MessageGenerator(Protocols.S_PING);
            byte[] message = generator.Generate();

            // 비로그인 유저
            foreach(var client in guestClientManager.ClientDic)
            {
                SendMessage(message, client.Value);
            }

            // 로그인 유저
            foreach (var client in clientManager.ClientDic)
            {
                SendMessage(message, client.Value);
            }
        }



        // 큐에 들어온 메시지를 처리함
        private void MessageProcess()
        {
            while (true)
            {
                if (messageQueue.IsEmpty == false)
                {
                    KeyValuePair<ClientCharacter, byte[]> message;
                    bool result = messageQueue.TryDequeue(out message);

                    if (result == false) continue;

                    messageManager.ParseMessage(message.Key, message.Value);

                }
                else
                {
                    lock (lockObject) { Monitor.Wait(lockObject); }
                }

            }
        }
        
        // 메시지 전송
        public void SendMessage(byte[] message, ClientCharacter client)
        {
            try
            {
                // 메시지 전송
                server.SendMessage(message, client.clientData);
            }
            catch
            {
                // 전송에 실패할 경우 접속을 끊음
                ClientLeave(client);
            }

        }
        
        #region Event

        // 서버에 새로운 클라이언트가 접속하면 호출됨
        private void ClientJoin(ClientData newClientData)
        {
            ClientCharacter newClient = guestClientManager.AddClient(newClientData);

            Console.WriteLine("[INFO] " + newClientData.key + "번 클라이언트가 접속하였습니다.");


            // client의 메시지가 수신되면 메시지와 함께 ClientUser을 반환하도록 함
            MyServer.AsyncResultParam param = new MyServer.AsyncResultParam(newClientData, newClient);
            server.DetectDataRecieve(param);
        }


        // 클라이언트와 연결이 끊기면 호출됨
        private void ClientLeave(ClientCharacter oldClient)
        {
            bool result = false;
            
            // 로그인된 클라이언트일 경우
            if(oldClient.IsLogin)
            {
                // clientManager에 있음
                result = clientManager.RemoveClient(oldClient);

                if(result == true)
                {
                    Console.WriteLine($"[INFO] {oldClient.ID}님이 접속을 종료하였습니다.");
                }
            }
            else
            {
                result = guestClientManager.RemoveClient(oldClient);
                if (result == true)
                {
                    Console.WriteLine($"[INFO] {oldClient.clientData.key}번 클라이언트님이 접속을 종료하였습니다.");
                }
            }
        }

        //  클라이언트로 부터 메시지 수신
        private void onDataRecieve(MyServer.AsyncResultParam param, byte[] message)
        {
            ClientCharacter? clientCharacter = param.returnObj as ClientCharacter;

            // 메시지 처리를 위해 큐에 넣음
            messageQueue.Enqueue(new KeyValuePair<ClientCharacter, byte[]>(clientCharacter!, message));

            lock (lockObject) { Monitor.Pulse(lockObject); }
        }
        #endregion
    }

}