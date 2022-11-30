using Capstone_Referecne_GameServer;
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

        private Action? GameStartDelegate;
        //public Action? GameStopDelegate;

        public GameServerForm()
        {
            InitializeComponent();
            GameServerManager = new GameServerManager(this);
        }

        public GameServerForm(Action? GameStartCallback)
        {
            InitializeComponent();
            GameStartDelegate = GameStartCallback;
            //GameStopDelegate = GameStopCallback;

            GameServerManager = new GameServerManager(this);
        }

        private void GameServer_Load(object sender, EventArgs e)
        {
            ChangeScreen(new GameSetting_Screen(this, GameStartDelegate));
        }

        public void ChangeScreen(Control newControl)
        {
            Controls.Clear();
            Controls.Add(newControl);
        }
    }
}
