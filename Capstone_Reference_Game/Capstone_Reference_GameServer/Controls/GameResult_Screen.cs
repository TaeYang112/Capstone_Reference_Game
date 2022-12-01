using Capstone_Reference_GameServer;
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
    public partial class GameResult_Screen : UserControl
    {
        // 제출자 수
        private int submitterCount = 0;

        // 정답자 수
        private int correctAnswerCount = 0;

        private int time;

        GameServerForm serverForm;
        public GameResult_Screen(GameServerForm serverForm)
        {
            InitializeComponent();
            this.serverForm = serverForm;
        }

        public void Start(int time)
        {
            if(time == 0)
            {
                lbl_Time.Text = "";
            }
            else
            {
                timer.Enabled = true;
                this.time = time;
                lbl_Time.Text = TimeToString(time);
            }
            
        }

        private void btn_GameStop_Click(object sender, EventArgs e)
        {
            MessageGenerator generator = new MessageGenerator(Protocols.S_GAME_END);
            serverForm.GameServerManager.SendMessageToAll(generator.Generate());
            
            //btn_GameStop.Enabled = false;
        }

        public void AddResult(string studentId, string studentName, int answer)
        {
            GameConfiguration config = serverForm.GameServerManager.Configuration;
            submitterCount++;

            string strAnswer = "";
            string AnswerCheck = "";
            if(config.QuizType == QuizTypes.OX_QUIZ)
            {
                switch(answer)
                {
                    case 1: strAnswer = "O";
                        break;
                    case 2: strAnswer = "X";
                        break;
                    default: strAnswer = "무응답";
                        break;
                }
            }
            else
            {
                if (answer == -1) strAnswer = "무응답";
                else strAnswer = answer.ToString();
            }

            if(config.Answer == answer)
            {
                AnswerCheck = "정답";
                correctAnswerCount++;
            }

            // 차트 업데이트
            if(config.QuizType == QuizTypes.OX_QUIZ)
            {
                OXChart_Screen? oxChart = pnl_Chart.Controls[0] as OXChart_Screen;

                if(oxChart != null)
                {
                    oxChart.AddResult(answer);
                }
            }
            else if(config.QuizType == QuizTypes.MULTIPLE_QUIZ)
            {

                MultipleChart_Screen? mQuiz = pnl_Chart.Controls[0] as MultipleChart_Screen;

                if (mQuiz != null)
                {
                    mQuiz.AddResult(answer);
                }
                
            }

            Invoke(new Action(() => {
                // 그리드 뷰에 추가
                grid_Result.Rows.Add(studentName,studentId, strAnswer,AnswerCheck);

                // 제출자, 정답자, 정답률 텍스트 변경
                lbl_submitter.Text = submitterCount + "명";
                lbl_CorrectAnswer.Text = correctAnswerCount + "명";
                lbl_AnswerPercent.Text = Math.Round((float)correctAnswerCount / submitterCount * 100) + "%";

            }));
            
        }

        private void GameResult_Screen_Load(object sender, EventArgs e)
        {
            GameConfiguration config = serverForm.GameServerManager.Configuration;
            if (config.QuizType == QuizTypes.OX_QUIZ)
            {
                OXChart_Screen oxChart = new OXChart_Screen(config.Title);
                pnl_Chart.Controls.Add(oxChart);
            }
            else
            {
                MultipleChart_Screen multiChart = new MultipleChart_Screen(config.Title, config.Questions, config.Answer);
                pnl_Chart.Controls.Add(multiChart);
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            time--;
            lbl_Time.Text = TimeToString(time);
            if (time == 0)
            {
                timer.Enabled = false;
                btn_GameStop.Enabled = false;
            }
        }

        private string TimeToString(int time)
        {
            int min = time / 60;
            int sec = time % 60;
            string result = string.Format("{0:D2}:{1:D2}",min, sec);
            return result;
        }
    }
}
