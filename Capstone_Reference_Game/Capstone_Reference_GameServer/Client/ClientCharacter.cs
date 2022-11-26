

// -----------------
// ----- 서버 ------
// -----------------

using Capstone_Referecne_GameServer.TCP;

namespace Capstone_Referecne_GameServer.Client
{
    public class ClientCharacter
    {
        // TcpClient 객체
        public ClientData clientData { get; }

        public int Key { get ; private set; }

        public int Skin { get; set; } = 0;

        public string StudentID { get; set; } = string.Empty;

        public ClientCharacter(int key, ClientData clientData)
        {
            this.clientData = clientData;
            this.Key = key;
            Random random = new Random();
            this.Skin = random.Next(0, 7);
        }

        
    }
}
