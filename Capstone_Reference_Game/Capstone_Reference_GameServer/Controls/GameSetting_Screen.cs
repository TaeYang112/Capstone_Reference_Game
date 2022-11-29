using Capstone_Referecne_GameServer;
using Capstone_Reference_Game_Module;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_GameServer.Controls
{
    public partial class GameSetting_Screen : UserControl
    {
        GameServerForm serverForm;
        public GameSetting_Screen(GameServerForm serverForm)
        {
            InitializeComponent();
            this.serverForm = serverForm;
        }

        private void btn_GameStart_Click(object sender, EventArgs e)
        {
            GameConfiguration config = new GameConfiguration();
            config.Title = tb_Title.Text;

            int time;
            if(int.TryParse(tb_Time.Text, out time))
            {
                config.Time = time;
            }
            else
            {
                config.Time = 0;
            }

            if (radioButton1.Checked) config.QuizType = QuizTypes.OX_QUIZ;
            else
            {
                config.QuizType = QuizTypes.MULTIPLE_QUIZ;
                List<string> list = new List<string>();

                string controlName = "tb_Question";
                for(int i = 1; i<= 5; i++)
                {
                    string txt = Controls[controlName + i].Text;
                    Console.WriteLine(Controls[controlName + i].Name);
                    if (txt != "")
                    {
                        Console.WriteLine(txt);
                        list.Add(txt);
                    }
                    else
                        break;
                }
                config.Questions = list;
            }

            serverForm.GameServerManager.Start(config);

            serverForm.ChangeScreen(new GameResult_Screen(serverForm));
            
        }
    }
}
