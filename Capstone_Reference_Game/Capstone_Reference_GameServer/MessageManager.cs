using Capstone_Referecne_GameServer.Client;
using Capstone_Reference_Game_Module;

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
                case Protocols.C_MSG:
                    {
                        string s = converter.NextString();
                        Console.WriteLine(s);
                    }
                    break;
                default:
                    Console.WriteLine("에러 프로토콜 : " + protocol);
                    break;

            }
            
        }

       
    }
}
