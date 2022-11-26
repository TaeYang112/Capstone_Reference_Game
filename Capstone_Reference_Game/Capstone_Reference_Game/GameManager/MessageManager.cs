using Capstone_Reference_Game_Module;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Capstone_Reference_Game.Manager
{
    public partial class GameManager
    {
        private class MessageManager
        {
            private GameManager gmaeManager;

            public MessageManager(GameManager gameManager)
            {
                this.gmaeManager = gameManager;
            }

            // 메시지를 해석 후 실행
            public void ParseMessage(byte[] message)
            {
                MessageConverter converter = new MessageConverter(message);

                byte protocol = converter.Protocol;
                switch (protocol)
                {
                    // 서버쪽의 사용자 학번 요청
                    case Protocols.S_REQ_ID:
                        {

                        }
                        break;
                    // 클라이언트가 접속중인지 확인하기 위해 서버가 보내는 메시지
                    case Protocols.S_PING:
                        {
                            // 클라이언트는 반응이 없어도 됨
                        }
                        break;
                    case Protocols.S_ERROR:
                        {
                            Error(converter);
                        }
                        break;
                    default:
                        Console.WriteLine("에러 : " + protocol);
                        break;
                }
                
            }

            public void ResponseStudentID()
            {

            }


            public void Error(MessageConverter converter)
            {
                int errorCode = converter.NextInt();

                switch (errorCode)
                {
                    default:
                        Console.WriteLine("알수 없는 에러코드 {0}", errorCode);
                        break;
                }
            }
        }
    }
}