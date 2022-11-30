using Capstone_Reference_GameServer.TCP;
using System.Collections.Concurrent;

namespace Capstone_Reference_GameServer.Client
{
    // 클라이언트들을 관리하는 클래스
    public class ClientManager
    {
        // 클라이언트들을 담는 배열
        // 단순 배열과 다른점은 여러개의 스레드가 접근할때 자동으로 동기화 시켜줌
        public ConcurrentDictionary<int, ClientCharacter> ClientDic { get; }

        // 새로운 클라이언트에게 부여할 킷값을 저장
        private int CurrentKey;

        public ClientManager()
        {
            ClientDic = new ConcurrentDictionary<int, ClientCharacter>();
            CurrentKey = 0;
        }

        public ClientCharacter AddClient(ClientData newClientData)
        {
            ClientCharacter newClient = new ClientCharacter(CurrentKey, newClientData);

            // 새로운 클라이언트를 배열에 저장
            ClientDic.TryAdd(CurrentKey, newClient);

            CurrentKey++;

            return newClient;
        }

        public bool RemoveClient(ClientCharacter oldClient)
        {
            return ClientDic.TryRemove(oldClient.Key, out _);
        }
    }
}
