

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

        public string ID { get; private set; } = string.Empty;

        public string Name { get; private set; } = string.Empty;

        public bool IsLogin { get; private set; } = false;

        public ClientCharacter(string id, ClientData clientData)
        {
            this.clientData = clientData;
            this.ID = id;
        }

        public void Login(string id, string name)
        {
            IsLogin = true;
            this.ID = id;
            this.Name = name;
        }

        public void Logout()
        {
            IsLogin = false;
            ID = string.Empty;
            Name = string.Empty;
        }
        
    }
}
