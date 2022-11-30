

// -----------------
// ----- 서버 ------
// -----------------

using Capstone_Reference_GameServer.TCP;
using System.Drawing;

namespace Capstone_Reference_GameServer.Client
{
    public class ClientCharacter
    {
        // TcpClient 객체
        public ClientData clientData { get; }

        public int Key { get ; private set; }

        public int Skin { get; set; } = 0;

        public string StudentID { get; set; } = string.Empty;
        public string StudentName { get; set; } = String.Empty;

        public Point Location { get; set; }

        public ClientCharacter(int key, ClientData clientData)
        {
            this.clientData = clientData;
            this.Key = key;
            clientData.Key = Key;
            Random random = new Random();
            this.Skin = random.Next(0, 8);
            Location = new Point(490, 343);
        }

        
    }
}
