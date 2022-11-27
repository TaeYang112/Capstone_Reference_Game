using Capstone_Referecne_GameServer.Client;
using Capstone_Referecne_GameServer.TCP;
using Capstone_Reference_Game_Module;
using System.Collections.Concurrent;
using System.Diagnostics;

// -----------------
// ----- 서버 ------
// -----------------

namespace Capstone_Referecne_GameServer
{
    public class GameServerManager
    { 
        // TCP 서버를 관리하고 클라이언트와 통신하는 객체
        private MyServer server;

        // 메시지 처리하는
        private Thread messageProcess_thread;

        // 수신받은 메시지 보관하는 큐
        ConcurrentQueue<KeyValuePair<ClientCharacter, byte[]>> messageQueue;

        // 클라이언트들을 관리하는 객체
        public ClientManager clientManager { get; }

        // 메시지 처리하는 객체
        private MessageManager messageManager;

        // 서버와 클라이언트가 계속 연결되어있는지 확인하기 위해 일정시간마다 가짜 메시지를 보냄
        private Timer HeartBeatTimer;

        // 메시지가 없으면 대기하기 위한 락 오브젝트
        object lockObject = new object();

        // 게임 설정
        GameConfiguration Configuration { get; set; }

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

        private GameServerManager()
        {
            server = new MyServer();
            server.onClientJoin += new ClientJoinEventHandler(ClientJoin);
            server.onDataRecieve += new DataRecieveEventHandler(onDataRecieve);

            clientManager = new ClientManager();

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
            Configuration =  LoadConfig();
            server.Start();
            HeartBeatTimer.Change(0, 50000);
            messageProcess_thread.Start();
        }

        // 프로그램 실행할 때 커맨드로 들어온 값들을 읽어들임
        private GameConfiguration LoadConfig()
        {
            GameConfiguration config = new GameConfiguration();

            // 타입, 제목, 타이머, [문제1, 문제2..]
            string[] commands = Environment.GetCommandLineArgs();
            if(commands.Length >=4)
            {
                if(commands[1] == "OXQUIZ")
                {
                    config.QuizType = QuizTypes.OX_QUIZ;
                }
                else
                {
                    config.QuizType = QuizTypes.MULTIPLE_QUIZ;
                }

                config.Title = commands[2];
                int temp;
                bool isNumber = int.TryParse(commands[3],out temp);
                if(isNumber)
                {
                    config.Time = temp; ;
                }
                else config.Time = 0;
            }

            if(config.QuizType == QuizTypes.MULTIPLE_QUIZ)
            {
                int count = commands.Length - 4;
                for(int i = 0; i< count; i++)
                {
                    config.Questions.Add(commands[i + 4]);
                }
            }

            
            Console.WriteLine("타입 : " + config.QuizType);
            Console.WriteLine("제목 : " + config.Title);
            Console.WriteLine("시간 : " + config.Time);
            foreach (var item in config.Questions)
            {
                Console.WriteLine("문제 : " + item);
            }
            
            return config;
        }

        // 서버와 클라이언트가 계속 연결되어있는지 확인하기 위해 일정시간마다 가짜 메시지를 보냄
        private void HeartBeat(object? t)
        {
            MessageGenerator generator = new MessageGenerator(Protocols.S_PING);
            byte[] message = generator.Generate();

            SendMessageToAll(message);
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

        // 모두에게 메시지 전송
        public void SendMessageToAll(byte[] message, ClientCharacter? ignoreClient = null)
        {
            foreach(var item in clientManager.ClientDic)
            {
                if (ignoreClient != null && item.Value.Key == ignoreClient.Key) 
                    continue;

                SendMessage(message, item.Value );
            }
        }

        // 클라이언트에게 각 정보를 넘겨줌 ( 다른 클라이언트, 퀴즈 )
        public void SendGameInfo(ClientCharacter client)
        {
            // 유저 본인의 정보
            MessageGenerator generator = new MessageGenerator(Protocols.S_USER_INFO);
            generator.AddInt(client.Skin);

            SendMessage(generator.Generate(), client);

            generator.Clear();
            generator.Protocol = Protocols.S_USER_INFO_OTHER;
            
            // 다른 클라이언트 정보
            foreach(var item in clientManager.ClientDic)
            {
                ClientCharacter otherClient = item.Value;

                if (client.Key == otherClient.Key) continue;

                generator.AddInt(otherClient.Key);
                generator.AddInt(otherClient.Skin);
                generator.AddInt(otherClient.Location.X).AddInt(otherClient.Location.Y);
                SendMessage(generator.Generate(), client);
                generator.Clear();
            }

            generator.Clear();
            generator.Protocol = Protocols.S_GAME_INFO;

            // 게임 정보
            generator.AddByte(Configuration.QuizType);
            generator.AddString(Configuration.Title);
            generator.AddInt(Configuration.Time);

            if(Configuration.QuizType == QuizTypes.MULTIPLE_QUIZ)
            {
                generator.AddInt(Configuration.Questions.Count);
                foreach(var question in Configuration.Questions)
                {
                    generator.AddString(question);
                }
            }

            SendMessage(generator.Generate(), client);
        }
        
        #region Event

        // 서버에 새로운 클라이언트가 접속하면 호출됨
        private void ClientJoin(ClientData newClientData)
        {
            ClientCharacter newClient = clientManager.AddClient(newClientData);

            // 접속한 클라이언트에게 학번 요청
            MessageGenerator generator = new MessageGenerator(Protocols.S_REQ_ID);
            SendMessage(generator.Generate(), newClient);

            // client의 메시지가 수신되면 메시지와 함께 ClientUser을 반환하도록 함
            MyServer.AsyncResultParam param = new MyServer.AsyncResultParam(newClientData, newClient);
            server.DetectDataRecieve(param);
        }


        // 클라이언트와 연결이 끊기면 호출됨
        private void ClientLeave(ClientCharacter oldClient)
        {
            bool result = clientManager.RemoveClient(oldClient);

            if(result == true)
            {
                if(oldClient.StudentID != string.Empty)
                    Console.WriteLine($"[INFO] [{oldClient.StudentID}]님이 접속을 종료하였습니다.");
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

    struct GameConfiguration
    {
        public GameConfiguration()
        {
            QuizType = QuizTypes.OX_QUIZ;
            Title = "";
            Time = 0;
            Questions = new List<string>();

        }
        public byte QuizType;
        public string Title;
        public int Time;
        public List<string> Questions;
    }

}