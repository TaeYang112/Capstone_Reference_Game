using Capstone_Reference_GameServer.Client;
using Capstone_Reference_GameServer.TCP;
using Capstone_Reference_Game_Module;
using Capstone_Reference_GameServer;
using System.Collections.Concurrent;
using System.Diagnostics;

// -----------------
// ----- 서버 ------
// -----------------

namespace Capstone_Reference_GameServer
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

        // 메시지가 없으면 대기하기 위한 락 오브젝트
        object lockObject = new object();

        // 게임 설정
        public GameConfiguration Configuration { get;private set; }

        // 게임 진행된 시간
        private Stopwatch stopwatch = new Stopwatch();
        private System.Threading.Timer gameTimer;

        // 메인 폼
        public GameServerForm ServerForm { get; private set; }

        public GameServerManager(GameServerForm serverForm)
        {
            this.ServerForm = serverForm;

            server = new MyServer();
            server.onClientJoin += new ClientJoinEventHandler(ClientJoin);
            server.onDataRecieve += new DataRecieveEventHandler(onDataRecieve);
            server.onClientLeave += new ClientLeaveEventHandler(onClientLeave);

            clientManager = new ClientManager();

            messageQueue = new ConcurrentQueue<KeyValuePair<ClientCharacter, byte[]>>();
            messageProcess_thread = new Thread(MessageProcess);
            messageProcess_thread.IsBackground = true;

            messageManager = new MessageManager(this);

            gameTimer = new System.Threading.Timer(new TimerCallback(TimerEnd), null, Timeout.Infinite, Timeout.Infinite);
        }



        ~GameServerManager()
        {
            gameTimer.Dispose();
            server.Stop();
        }

        public void Start(GameConfiguration config)
        {
            Configuration = config;
            server.Start();
            messageProcess_thread.Start();
            
            if (Configuration.Time > 0)
            {
                stopwatch.Start();
                gameTimer.Change(Configuration.Time * 1000, Timeout.Infinite);
            }

        }

        public void Stop()
        {
            server.Stop();
        }

        public void TimerEnd(object? o)
        {
            Console.WriteLine("[INFO] 시간 종료");
            MessageGenerator generator = new MessageGenerator(Protocols.S_GAME_END);
            SendMessageToAll(generator.Generate());
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

                if (client.Key == otherClient.Key || otherClient.StudentID == "GUEST") continue;

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
            generator.AddInt((int)stopwatch.ElapsedMilliseconds);

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


        // 클라이언트와 연결을 끊을 때 호출
        private void ClientLeave(ClientCharacter oldClient)
        {
            bool result = clientManager.RemoveClient(oldClient);

            if(result == true)
            {
                if(oldClient.StudentID != string.Empty)
                    Console.WriteLine($"[INFO] [{oldClient.StudentID}]님이 접속을 종료하였습니다.");

                MessageGenerator generator = new MessageGenerator(Protocols.S_LEAVE_OTHER);
                generator.AddInt(oldClient.Key);
                SendMessageToAll(generator.Generate());
            }
        }

        // 클라이언트와 연결이 끊기면 호출
        private void onClientLeave(ClientData oldData)
        {
            ClientCharacter? clientCharacter;
            bool result = clientManager.ClientDic.TryGetValue(oldData.Key, out clientCharacter);

            if (result == true)
            {
                ClientLeave(clientCharacter!);
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

    public struct GameConfiguration
    {
        public GameConfiguration()
        {
            QuizType = QuizTypes.OX_QUIZ;
            Title = "";
            Time = 10;
            Questions = new List<string>();
            Answer = 0;
        }
        public byte QuizType;
        public string Title;
        public int Time;
        public List<string> Questions;
        public int Answer;
    }

}