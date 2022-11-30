using Capstone_Reference_GameServer;
using Capstone_Reference_GameServer.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_GameServer
{
    public partial class GameServerForm : Form
    {
        public GameServerManager GameServerManager { get; private set; }

        public GameServerForm(GameConfiguration config)
        {
            InitializeComponent();
            GameServerManager = new GameServerManager(this);
            Controls.Add(new GameResult_Screen(this));
            GameServerManager.Start(config);
        }


        private void GameServer_Load(object sender, EventArgs e)
        {
        
            
        }


    }
}
