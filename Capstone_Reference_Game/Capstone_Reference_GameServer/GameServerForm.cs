using Capstone_Reference_GameServer;
using Capstone_Reference_GameServer.Controls;
using Capstone_Reference_GameServer.Controls.Core;
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
            new DropShadow().ApplyShadows(this);
        }

        public void Start()
        {
            GameServerManager.Start(config);
            GameResult_Screen screen = new GameResult_Screen(this);
            screen.Location = new Point(0, 24);
            Controls.Add(screen);
            screen.Start(config.Time);
        }


        private void GameServer_Load(object sender, EventArgs e)
        {
        
            
        }

        private void GameServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            GameServerManager.Stop();
        }


        #region 상단바

        bool TagMove;
        int MValX, MValY;

        private void panel_MouseDown(object sender, MouseEventArgs e)
        {
            TagMove = true;
            MValX = e.X;
            MValY = e.Y;
        }

        private void panel_MouseMove(object sender, MouseEventArgs e)
        {
            if(TagMove == true)
            {
                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void pb_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel_MouseUp(object sender, MouseEventArgs e)
        {
            TagMove = false;
        }

        #endregion

    }
}
