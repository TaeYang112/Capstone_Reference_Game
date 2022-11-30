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
        public MultipleChart_Screen(string title, List<string> questions, int correctAnswer)
        {
            InitializeComponent();
            lbl_Title.Text = title;
            for(int i = 0; i < questions.Count; i++)
            {
                Controls["lbl_AnNum" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Text = questions[i];

                if(i == correctAnswer-1)
                {
                    barGraph1.AddBar(new Bar() { Brush = Brushes.Red });
                }
                else
                {
                    barGraph1.AddBar(new Bar() { Brush = Brushes.Green });
                }
            }
            
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
    }
}
