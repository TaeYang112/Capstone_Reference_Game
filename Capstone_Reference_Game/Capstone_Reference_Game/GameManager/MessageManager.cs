using Capstone_Reference_Game.Client;
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
            private GameManager gameManager;

            public MessageManager(GameManager gameManager)
            {
                this.gameManager = gameManager;
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
                            ResponseStudentID();
                        }
                        break;
                    // 서버쪽에서 내 정보를 넘겨줌 ( 스킨 등.. )
                    case Protocols.S_USER_INFO:
                        {
                            SettingMyClient(converter);
                        }
                        break;
                    // 다른 클라이언트 정보
                    case Protocols.S_USER_INFO_OTHER:
                        {
                            AddOtherClient(converter);
                        }
                        break;
                    // 게임 정보를 넘겨줌
                    case Protocols.S_GAME_INFO:
                        {
                            SettingGame(converter);
                        }
                        break;
                    // 다른클라이언트의 키 입력 수신
                    case Protocols.S_KEY_INPUT_OTHER:
                        {
                            OtherClientKeyInput(converter);
                        }
                        break;
                    // 다른 클라이언트의 좌표 수신
                    case Protocols.S_LCATION_SYNC_OTHER:
                        {
                            LocationSyncOther(converter);
                        }
                        break;
                    // 게임종료
                    case Protocols.S_GAME_END:
                        {
                            GameEnd();
                        }
                        break;
                    // 다른 클라이언트 종료
                    case Protocols.S_LEAVE_OTHER:
                        {
                            RemoveClient(converter);
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

            // 자신의 학번을 서버쪽으로 보냄
            private void ResponseStudentID()
            {
                MessageGenerator generator = new MessageGenerator(Protocols.C_RES_ID);
                generator.AddString(gameManager.StudentID);
                generator.AddString(gameManager.StudentName);
                gameManager.SendMessage(generator.Generate());
            }

            private void SettingMyClient(MessageConverter converter)
            {
                int skinNum = converter.NextInt();
                ClientCharacter? client = gameManager.MainForm.UserCharacter;

                client?.SetSkin(skinNum);
            }
            
            // 다른 클라이언트 추가
            private void AddOtherClient(MessageConverter converter)
            {
                int key = converter.NextInt();
                int skin = converter.NextInt();
                int x = converter.NextInt();
                int y = converter.NextInt();

                // 객체 생성
                ClientCharacter client = new ClientCharacter(key,skin);
                client.Location = new Point(x,y);

                // 딕셔너리에 추가
                gameManager.MainForm.Clients.TryAdd(key, client);
            }

            //
            private void SettingGame(MessageConverter converter)
            {
                byte quizType = converter.NextByte();
                string title = converter.NextString();
                int time = converter.NextInt();
                int currentTime = converter.NextInt();

                GameConfiguration config = new GameConfiguration()
                {
                    Time = time,
                    Title = title,
                    QuizType = quizType
                };

                List<string>? questions = null;
                if(quizType == QuizTypes.MULTIPLE_QUIZ)
                {
                    int count = converter.NextInt();
                    questions = new List<string>();

                    for(int i = 0; i < count; i++)
                    {
                        questions.Add(converter.NextString());
                    }
                    config.Questions = questions;
                }

                gameManager.MainForm.GameStart(config ,currentTime);
            }

            // 다른 클라이언트의 키 입력 처리
            private void OtherClientKeyInput(MessageConverter converter)
            {
                int key = converter.NextInt();
                byte inputedKey = converter.NextByte();
                bool isPressed = converter.NextBool();

                // 해당하는 클라이언트 검색
                ClientCharacter? client;
                gameManager.MainForm.Clients.TryGetValue(key, out client);

                if(client != null)
                {
                    client.Keys[inputedKey] = isPressed;
                }

            }

            private void LocationSyncOther(MessageConverter converter)
            {
                int key = converter.NextInt();
                int x = converter.NextInt();
                int y = converter.NextInt();

                // 해당하는 클라이언트 검색
                ClientCharacter? client;
                gameManager.MainForm.Clients.TryGetValue(key, out client);

                if (client != null)
                {
                    client.Location = new Point(x, y);
                }
            }

            // 게임이 종료됨. 자신의 정답을 서버로 반환
            private void GameEnd()
            {
                if (gameManager.MainForm.UserCharacter != null)
                {
                    gameManager.SendMyAnswer();
                }
                Application.Exit();
            }

            // 나간 클라이언트 제거
            private void RemoveClient(MessageConverter converter)
            {
                int key = converter.NextInt();
                gameManager.MainForm.Clients.TryRemove(key, out _);
            }

            private void Error(MessageConverter converter)
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