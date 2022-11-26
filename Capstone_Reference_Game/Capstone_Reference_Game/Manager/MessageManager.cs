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
                    // 서버로 부터 로그인 결과 수신
                    case Protocols.RES_LOGIN:
                        {
                            ReceiveLoginResult(converter);
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

            private void ReceiveLoginResult(MessageConverter converter)
            {
                int result = converter.NextByte();
                
                // 로그인에 성공
                if(result == LoginResult.SUCCESS)
                {
                    Console.WriteLine("로긴 성공");
                }
                else
                {
                    Console.WriteLine("로긴 실패");
                }
            }

            public void Error(MessageConverter converter)
            {
                int errorCode = converter.NextInt();

                switch (errorCode)
                {
                    case 0:
                        {
                            MessageBox.Show("해당 방은 꽉찼습니다.", $"에러코드 : {errorCode}", MessageBoxButtons.OK);
                        }
                        break;
                    case 1:
                        {
                            MessageBox.Show("존재하지 않은 방입니다.", $"에러코드 : {errorCode}", MessageBoxButtons.OK);
                        }
                        break;
                    default:
                        Console.WriteLine("알수 없는 에러코드 {0}", errorCode);
                        break;
                }
            }
        }
    }
}