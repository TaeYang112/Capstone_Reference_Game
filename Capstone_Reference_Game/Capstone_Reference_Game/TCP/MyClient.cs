using System;
using System.Text;
using System.Net.Sockets;
using System.Threading;



namespace Reference_Game.TCP
{
    public delegate void TakeMessageEventHandler(byte[] message);
    public delegate void ExceptionEventHandler(Exception exception);
    public class MyClient
    {
        // 서버로부터 메시지가 도착하면 이벤트 알림
        public event TakeMessageEventHandler? onDataRecieve;

        // 에러가 발생하면 이벤트 알림
        public event ExceptionEventHandler? onException;

        // 메시지 버퍼
        private byte[] readByteData;

        // TcpClient ( 통신 클래스 )
        private TcpClient client;

        // client를 실행시킬 스레드            
        private Thread client_tr;

        private string ip;

        public MyClient(string ip)
        {
            this.ip = ip;
            readByteData = new byte[5];

            // 클라이언트 생성
            client = new TcpClient();

            client.NoDelay = true;

            // 클라이언트 실행시킬 스레드
            client_tr = new Thread(TryToConnect);
            client_tr.IsBackground = true;
        }

        ~MyClient()
        {
            //클라이언트 종료
            client.Close();
        }


        // 클라이언트(스레드) 실행
        public void Start()
        {
            client_tr.Start();
        }


        // 서버에 연결
        public void TryToConnect()
        {
            while (true)
            {
                try
                {
                    // 서버에 연결 ( 서버IP, 포트 )
                    client.Connect(ip, 28898);
                }
                catch
                {
                    Console.WriteLine("서버에 접속에 실패하였습니다.");
                    Console.WriteLine("접속 시도중...");
                    Thread.Sleep(1000);
                    continue;
                }
                Console.WriteLine("서버에 접속하였습니다.");
                break;
            }
            
            // 서버로 부터 메시지를 받을경우 OnMessageReceive 메소드 호출
            client.GetStream().BeginRead(readByteData, 0, 4, new AsyncCallback(DataRecieved), null);
        }


        // 메시지를 서버로 보냄
        public void SendMessage(byte[] message)
        {
            try
            {
                client.GetStream().Write(message, 0, message.Length);
            }
            catch(System.InvalidOperationException e)
            {
                if (onException != null)
                {
                    onException(e);
                }
            }
        }

        private void DataRecieved(IAsyncResult ar)
        {
            // 먼저 크기를 읽음
            int byteSize = BitConverter.ToInt32(readByteData, 1);

            if (byteSize == 0) return;

            // 크기에 맞게 버퍼를 생성
            byte[] buffer = new byte[byteSize];
            Array.Copy(readByteData, buffer, 4);

            int readIdx = 4;

            // 크기에 맞는 내용을 모두 읽을때까지 읽어드림
            while (readIdx < byteSize)
            {
                int length = client.GetStream().Read(buffer, readIdx, byteSize - 4);
                readIdx += length;
            }

            // 연결된 함수 호출
            onDataRecieve!(buffer);

            Array.Clear(readByteData, 0, readByteData.Length);


            // 다시 메시지가 올때 이 함수가 호출되도록 함
            try
            {
                client.GetStream().BeginRead(readByteData, 0, 4, new AsyncCallback(DataRecieved), null);

            }
            catch (System.IO.IOException)
            {
                Console.WriteLine("서버와 연결이 끊어졌습니다.");
            }
            catch(System.InvalidOperationException)
            {
                Console.WriteLine("서버와 연결이 끊어졌습니다.");
            }
        }
    }
}
