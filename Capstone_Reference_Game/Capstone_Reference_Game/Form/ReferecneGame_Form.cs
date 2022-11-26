using Capstone_Reference_Game.Manager;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_Game.Form
{
    public partial class ReferecneGame_Form : System.Windows.Forms.Form
    {
        GameManager gameManager;
        public ReferecneGame_Form()
        {
            InitializeComponent();
            gameManager = new GameManager(this);
        }

        private void ReferecneGame_Form_Load(object sender, EventArgs e)
        {
            gameManager.Start();
        }
    }
}
