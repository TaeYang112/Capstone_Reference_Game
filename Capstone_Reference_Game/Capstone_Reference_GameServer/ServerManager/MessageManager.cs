using Capstone_Referecne_GameServer.Client;
using Capstone_Reference_Game_Module;
using System.Drawing;

namespace Capstone_Referecne_GameServer
{
    public class MessageManager
    {
        private GameServerManager serverManager;

        public MessageManager(GameServerManager serverManager)
        {
            this.serverManager = serverManager;
        }

        // 받은 메시지를 해석함
        public void ParseMessage(ClientCharacter client, byte[] message)
        {

            MessageConverter converter = new MessageConverter(message);

            byte protocol = converter.Protocol;
            switch (protocol)
            {
                // 클라이언트가 서버에 응답하여 자신의 학번을 보냄
                case Protocols.C_RES_ID:
                    {
                        RecieveStudentID(client, converter);
                    }
                    break;
                // 클라이언트가 자신이 누른 키를 알려줌
                case Protocols.C_KEY_INPUT:
                    {
                        ClientKeyInputed(client, converter);
                    }
                    break;
                // 클라이언트가 동기화를 위해 자신의 좌표를 알려줌
                case Protocols.C_LOCATION_SYNC:
                    {
                        SyncLocation(client, converter);
                    }
                    break;
                // 클라이언트가 자신의 정답을 알려줌
                case Protocols.C_ANSWER:
                    {
                        AnswerProcess(client, converter);
                    }
                    break;
                default:
                    Console.WriteLine("에러 프로토콜 : " + protocol);
                    break;

            }

            
            
        }


        //클라이언트가 보낸 학번 처리
        private void RecieveStudentID(ClientCharacter client, MessageConverter converter)
        {
            string studentID = converter.NextString();
            client.StudentID = studentID;
            Console.WriteLine($"[INFO] [{studentID}]님이 서버에 접속하였습니다.");

            // 게임과 관련된 온갖 정보를 넘겨줌
            serverManager.SendGameInfo(client);

            if (studentID != "GUEST")
            {
                MessageGenerator generator = new MessageGenerator(Protocols.S_USER_INFO_OTHER);
                generator.AddInt(client.Key);
                generator.AddInt(client.Skin);
                generator.AddInt(client.Location.X);
                generator.AddInt(client.Location.Y);

                // 다른 클라이언트들에게 들어온 클라이언트를 알려줌
                serverManager.SendMessageToAll(generator.Generate(), client);
            }
        }
       
        // 클라이언트가 누른 키 처리
        private void ClientKeyInputed(ClientCharacter client, MessageConverter converter)
        {
            byte inputedKey = converter.NextByte();
            bool isPressed = converter.NextBool();

            // 다른 클라이언트들에게도 알려줌
            MessageGenerator generator = new MessageGenerator(Protocols.S_KEY_INPUT_OTHER);
            generator.AddInt(client.Key);
            generator.AddByte(inputedKey);
            generator.AddBool(isPressed);

            serverManager.SendMessageToAll(generator.Generate(), client);
        }

        // 동기화를 위해 클라이언트가 보낸 좌표를 다른 클라이언트에게도 알려줌
        private void SyncLocation(ClientCharacter client, MessageConverter converter)
        {
            int x = converter.NextInt();
            int y = converter.NextInt();

            client.Location = new Point(x, y);

            MessageGenerator generator = new MessageGenerator(Protocols.S_LCATION_SYNC_OTHER);
            generator.AddInt(client.Key);
            generator.AddInt(x).AddInt(y);

            serverManager.SendMessageToAll(generator.Generate(),client);
        }

        // 클라이언트가 전송한 정답 처리
        private void AnswerProcess(ClientCharacter client, MessageConverter converter)
        {
            int answer = converter.NextInt();

            using (StreamWriter sw = new StreamWriter(new FileStream("result.txt", FileMode.Append)))
            {
                sw.Write(client.StudentID + " ");
                sw.WriteLine(answer);
            }
            
        }

    }
}
