using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_GameServer.Controls
{
    internal class BufferedLabel : Label
    {
        public BufferedLabel()
        {
            DoubleBuffered = true;
        }
    }
}
