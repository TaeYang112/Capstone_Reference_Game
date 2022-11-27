using System.Net.Sockets;

// -----------------
// ----- 서버 ------
// -----------------

namespace Capstone_Referecne_GameServer.TCP
{
    public delegate void ClientJoinEventHandler(ClientData newClient);
    public delegate void ClientLeaveEventHandler(ClientData oldClient);
    public delegate void DataRecieveEventHandler(MyServer.AsyncResultParam param, byte[] Message);
    public class MyServer
    {
        // TCP통신에서 서버를 담당하는 클래스
        public TcpListener server { get; set; }

        // server를 실행시킬 스레드    
        private Thread server_tr;

        // 클라이언트가 접속할경우 ClientJoin에 연결된 함수를 호출함
        public event ClientJoinEventHandler? onClientJoin;

        // 클라이언트가 나가면 연결된 함수 호출
        public event ClientLeaveEventHandler? onClientLeave;

        // 클라이언트로 부터 메시지가 수신되면 연결된 함수 호출
        public event DataRecieveEventHandler? onDataRecieve;


        public MyServer()
        {
            // TcpListener 클래스 생성 ( IP, 포트 )
            server = new TcpListener(System.Net.IPAddress.Any, 28898);

            // 클라이언트 실행시킬 스레드 설정
            server_tr = new Thread(WaitAndAcceptClient);
            server_tr.IsBackground = true;
        }

        ~MyServer()
        {
            server.Stop();
            server_tr.Interrupt();
        }


        public void Start()
        {
            // 서버 시작
            server.Start();

            // 쓰레드 시작
            server_tr.Start();
        }

        private void WaitAndAcceptClient()
        {
            try
            {
                while (true)
                {
                    // 서버에 접속하려는 client 접속요청 허용후 클라이언트 객체에 할당
                    // 접속하려는 client가 없으면 무한 대기
                    TcpClient AcceptClient = server.AcceptTcpClient();

                    // 클라이언트가 가져야 할 정보를 포함하는 클래스 생성
                    ClientData clientData = new ClientData(AcceptClient);

                    // ClientJoin 이벤트에 연결된 함수를 호출함
                    onClientJoin!(clientData);
                }
            }
            catch(ThreadStateException)
            {
                return;
            }

        }

        // 메시지 전송
        // try catch 필요
        public void SendMessage(byte[] message, ClientData receiver)
        {
            // 메시지 전송
            receiver.client.GetStream().Write(message, 0, message.Length);
        }
        
        // 클라이언트 데이터 수신을 감지하고 ReturnObj와 함께 DataRecived 호출
        public void DetectDataRecieve(AsyncResultParam asyncResultParam)
        {
            ClientData clientData = asyncResultParam.clientData;

            clientData.client.GetStream().BeginRead(clientData.byteData, 0, 4, new AsyncCallback(DataRecieved), asyncResultParam);
        }

        // 데이터를 수신
        private void DataRecieved(IAsyncResult ar)
        {
            AsyncResultParam? result = ar.AsyncState as AsyncResultParam;
            
            try
            {
                ClientData clientData = result!.clientData;

                // 먼저 크기를 읽음
                int byteSize = BitConverter.ToInt32(clientData.byteData, 1);

                if (byteSize == 0)
                {
                    if(onClientLeave != null)
                    {
                        onClientLeave(clientData);
                    }
                    return;
                }

                // 크기에 맞게 버퍼를 생성
                byte[] buffer = new byte[byteSize];
                Array.Copy(clientData.byteData, buffer, 4);

                int readIdx = 4;

                // 크기에 맞는 내용을 모두 읽을때까지 읽어드림
                while (readIdx < byteSize)
                {
                    int length = clientData.client.GetStream().Read(buffer, readIdx, byteSize - 4);
                    readIdx += length;
                }

                // 연결된 함수 호출
                onDataRecieve!(result!, buffer);

                Array.Clear(clientData.byteData, 0, clientData.byteData.Length);

                // 다시 데이터 수신 감시
                DetectDataRecieve(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine("에러");
                Console.WriteLine(ex.ToString());  
            }

        }

        public class AsyncResultParam
        {
            public ClientData clientData { get; set; }
            public object returnObj { get; set; }
            public AsyncResultParam(ClientData clientData, object returnObj)
            {
                this.clientData = clientData;
                this.returnObj = returnObj;
            }
        }
    }
}
