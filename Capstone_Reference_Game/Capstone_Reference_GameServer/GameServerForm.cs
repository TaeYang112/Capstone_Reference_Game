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

        private GameConfiguration config;
        public GameServerForm(GameConfiguration config)
        {
            InitializeComponent();
            this.config = config;
            GameServerManager = new GameServerManager(this);
            GameResult_Screen screen = new GameResult_Screen(this);
            Controls.Add(screen);
            screen.Start(config.Time);
            
        }

        public void Start()
        {
            GameServerManager.Start(config);
        }


        private void GameServer_Load(object sender, EventArgs e)
        {
        
            
        }

        private void GameServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameServerManager.Stop();
        }
    }
}
