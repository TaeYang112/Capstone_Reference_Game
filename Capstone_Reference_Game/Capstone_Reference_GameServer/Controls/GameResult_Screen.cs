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

        private void GameResult_Screen_Load(object sender, EventArgs e)
        {
            GameConfiguration config = serverForm.GameServerManager.Configuration;
            if (config.QuizType == QuizTypes.OX_QUIZ)
            {
                OXChart_Screen oxChart = new OXChart_Screen(config.Answer);
                pnl_Chart.Controls.Add(oxChart);
                oxChart.SetTitle(config.Title);
            }
            else if (config.QuizType == QuizTypes.MULTIPLE_QUIZ)
            {
                MultipleChart_Screen multiChart = new MultipleChart_Screen(config.Questions, config.Answer);
                pnl_Chart.Controls.Add(multiChart);
                multiChart.SetTitle(config.Title);
            }
            else if(config.QuizType == QuizTypes.DESCRIPTIVE_QUIZ)
            {
                grid_Result.Columns[2].Visible = false;
                Descriptive_Screen descrip = new Descriptive_Screen();
                pnl_Chart.Controls.Add(descrip);
                descrip.SetTitle(config.Title);

                descrip.btn_Ans.Click += AnswerButtonClick;
            }
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
            
            timer.Enabled = false;
            lbl_Time.Text = TimeToString(0);
            btn_GameStop.Enabled = false;
            btn_GameStop.Text = "종료됨";
        }

        public void AddResult(string studentId, string studentName, object answer)
        {
            GameConfiguration config = serverForm.GameServerManager.Configuration;
            submitterCount++;

            string strAnswer = "";
            string AnswerCheck = "";
            if (config.QuizType == QuizTypes.OX_QUIZ)
            {
                // 클라이언트가 고른 정답을 변환
                int intAnswer = (int)answer;
                switch (intAnswer)
                {
                    case 1: strAnswer = "O";
                        break;
                    case 2: strAnswer = "X";
                        break;
                    default: strAnswer = "무응답";
                        break;
                }

                // 클라이언트가 고른 정답이 진짜 정답이라면 정답표시
                if (intAnswer == config.Answer)
                { 
                    AnswerCheck = "정답";
                    correctAnswerCount++;
                }

                // 통계 화면에 결과 추가
                OXChart_Screen? oxChart = pnl_Chart.Controls[0] as OXChart_Screen;
                if (oxChart != null)
                {
                    oxChart.AddResult(intAnswer);
                }
            }
            else if(config.QuizType == QuizTypes.MULTIPLE_QUIZ)
            {
                int intAnswer = (int)answer;

                // 클라이언트가 고른 정답을 변환
                if (intAnswer == -1) strAnswer = "무응답";
                else strAnswer = intAnswer.ToString();

                // 클라이언트가 고른 정답이 진짜 정답이라면 정답표시
                if (intAnswer == config.Answer)
                {
                    AnswerCheck = "정답";
                    correctAnswerCount++;
                }

                // 통계 화면에 결과 추가
                MultipleChart_Screen? mQuiz = pnl_Chart.Controls[0] as MultipleChart_Screen;
                if (mQuiz != null)
                {
                    mQuiz.AddResult((int)answer);
                }
            }
            else
            {
                strAnswer = answer.ToString() ?? "";
            }
            

            Invoke(new Action(() => {
                // 그리드 뷰에 추가
                grid_Result.Rows.Add(studentId, studentName, strAnswer,AnswerCheck);

                // 제출자, 정답자, 정답률 텍스트 변경
                lbl_submitter.Text = submitterCount + "명";
                lbl_CorrectAnswer.Text = correctAnswerCount + "명";
                lbl_AnswerPercent.Text = Math.Round((float)correctAnswerCount / submitterCount * 100) + "%";

            }));
            
        }

        

        private void timer_Tick(object sender, EventArgs e)
        {
            time--;
            lbl_Time.Text = TimeToString(time);
            if (time == 0)
            {
                timer.Enabled = false;
                btn_GameStop.Enabled = false;
                btn_GameStop.Text = "종료됨";
            }
        }

        private string TimeToString(int time)
        {
            int min = time / 60;
            int sec = time % 60;
            string result = string.Format("{0:D2}:{1:D2}",min, sec);
            return result;
        }

        private void grid_Result_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx < 0 || serverForm.GameServerManager.Configuration.QuizType != QuizTypes.DESCRIPTIVE_QUIZ) return;

            string id = grid_Result[0, idx].Value.ToString()!;
            string name = grid_Result[1, idx].Value.ToString()!;
            
            string context = grid_Result[2, idx].Value.ToString()!;

            Descriptive_Screen? screen =  pnl_Chart.Controls[0] as Descriptive_Screen;

            if(screen != null)
            {
                screen.Update(context, id, name);
            }
        }

        private void grid_Result_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            if (idx < 0 || serverForm.GameServerManager.Configuration.QuizType != QuizTypes.DESCRIPTIVE_QUIZ) return;

            string id = grid_Result[0, idx].Value.ToString()!;
            string name = grid_Result[1, idx].Value.ToString()!;
            
            string context = grid_Result[2, idx].Value.ToString()!;

            Descriptive_Screen? screen = pnl_Chart.Controls[0] as Descriptive_Screen;

            if (screen != null)
            {
                screen.Update(context, id, name);
            }
        }

        private void AnswerButtonClick(object? o, EventArgs e)
        {
            if(grid_Result.SelectedRows.Count == 0) return;
            object value = grid_Result.SelectedRows[0].Cells[3].Value;

            if ((string)value == "정답")
            {
                correctAnswerCount--;
                grid_Result.SelectedRows[0].Cells[3].Value = "";
            }
            else 
            { 
                correctAnswerCount++;
                grid_Result.SelectedRows[0].Cells[3].Value = "정답";
            }

            Invoke(new Action(() =>
            {
                lbl_CorrectAnswer.Text = correctAnswerCount + "명";
                lbl_AnswerPercent.Text = Math.Round((float)correctAnswerCount / submitterCount * 100) + "%";

            }));
        }

    }
}
