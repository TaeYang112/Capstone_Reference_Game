using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_Game
{
    internal interface IPaintable
    {
        public Point Location { get; set; }
        public Size Size { get; set; }

        public void Draw(Graphics g);
    }
}
