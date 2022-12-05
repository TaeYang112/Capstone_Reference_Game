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
    public partial class MultipleChart_Screen : UserControl
    {
        // 답안 별 제출수
        //private List<int> question_submitCounts;
        public MultipleChart_Screen( List<string> questions, int correctAnswer)
        {
            InitializeComponent();
            for(int i = 0; i < questions.Count; i++)
            {
                Controls["lbl_AnNum" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Text = questions[i];

                if(i == correctAnswer-1)
                {
                    // 정답 색
                    barGraph1.AddBar(new Bar() { Brush = new SolidBrush(Color.FromArgb(120,30,255)) });
                }
                else
                {
                    // 비정답 색
                    barGraph1.AddBar(new Bar() { Brush = new SolidBrush(Color.FromArgb(180, 130, 255)) });
                }
            }
            
        }

        public void SetTitle(string title)
        {
            lbl_Title.Text = title;
        }

        public void AddResult(int answer)
        {
            if (answer <= 0) return; 
            barGraph1.AddBarValue(answer - 1);
        }

        private void MultipleChart_Screen_Load(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            barGraph1.AddBarValue(random.Next(0,5));
        }

        private void lbl_Title_SizeChanged(object sender, EventArgs e)
        {
            if (Parent != null)
            {
                // 제목이 가운데로 오게 함
                int x = Parent.Width / 2 - lbl_Title.Width / 2;
                lbl_Title.Left = x;

                pnl_underTitle.Left = x;
                pnl_underTitle.Top = lbl_Title.Top + lbl_Title.Height;
                pnl_underTitle.Width = lbl_Title.Width;
            }
        }
    }
}
