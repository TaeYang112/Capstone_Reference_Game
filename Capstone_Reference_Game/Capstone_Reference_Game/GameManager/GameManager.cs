using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Form;
using Capstone_Reference_Game_Module;
using Reference_Game.TCP;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Capstone_Reference_Game.Manager
{
    public partial class GameManager
    {
        // 에러로 인한 프로그램 종료 플래그 변수
        private bool bExitReady = false;

        // 서버와 TCP통신을 담당하는 객체
        public MyClient myClient { get; }

        public ReferenceGame_Form MainForm { get; }

        // 메시지 처리 스레드
        private Thread messageProcess_thread;

        // 메시지를 처리하는 객체
        private MessageManager messageManager;

        // 수신받은 메시지 보관하는 큐
        private ConcurrentQueue<byte[]> messageQueue;

        // 메시지가 없으면 대기하기 위한 락 오브젝트
        object lockObject = new object();

        public string StudentID { get; set; } = "GUEST";
        public string StudentName { get; set; } = " ";

        public GameManager(ReferenceGame_Form form, string ip)
        {
            this.MainForm = form;

            // 클라이언트 객체 생성
            myClient = new MyClient(ip);

            // 서버로부터 메시지를 받으면 onTakeMessage함수 호출
            myClient.onDataRecieve += onDataRecieve;

            // 서버로부터 에러를 받으면 TakeException 함수 호출
            myClient.onException += TakeException;

            messageManager = new MessageManager(this);
            messageQueue = new ConcurrentQueue<byte[]>();
            messageProcess_thread = new Thread(MessageProcess);
            messageProcess_thread.IsBackground = true;

        }

        public void Start()
        {
            myClient.Start();
            messageProcess_thread.Start();
        }


        // 서버로부터 받은 메시지를 처리
        private void onDataRecieve(byte[] message)
        {
            messageQueue.Enqueue(message);

            // 큐에 메시지가 있다는거를 알려줌
            lock (lockObject) { Monitor.Pulse(lockObject); }
        }

        private void MessageProcess()
        {
            while (true)
            {
                if (messageQueue.IsEmpty == false)
                {
                    byte[] message;
                    bool result = messageQueue.TryDequeue(out message!);

                    if (result == false) continue;

                    messageManager.ParseMessage(message);
                }
                else
                {
                    // 큐에 메시지가 더이상 없으면 다음 데이터가 들어올때 까지 대기
                    lock (lockObject) { Monitor.Wait(lockObject); }
                }

            }
        }

        // TCP 통신중 발생한 에러 처리
        private void TakeException(Exception e)
        {
            if (e.GetType().ToString() == "System.InvalidOperationException")
            {
                if (bExitReady) return;

                bExitReady = true;
                MessageBox.Show("서버와 연결되어있지 않습니다.", $"에러코드 : {-1}", MessageBoxButtons.OK);
                Application.Exit();

            }
        }




        // 서버로 메시지 전송
        public void SendMessage(byte[] message)
        {
            myClient.SendMessage(message);
        }

        // 서버로 답안 정송
        public void SendMyAnswer()
        {
            QuizBase? quiz = MainForm.CurrentQuiz;
            if (quiz != null && MainForm.UserCharacter != null)
            {
                MessageGenerator generator = new MessageGenerator(Protocols.C_ANSWER);
                generator.AddInt(quiz.GetAnswer());
                SendMessage(generator.Generate());
            }
        }


    }
}

