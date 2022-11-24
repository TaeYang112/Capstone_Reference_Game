using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_Game.Client
{
    public class ClientManager
    {
        public ConcurrentDictionary<int,ClientCharacter> Clients { get; }

        public ClientManager()
        {
            Clients = new ConcurrentDictionary<int,ClientCharacter>();
        }
    }
}
