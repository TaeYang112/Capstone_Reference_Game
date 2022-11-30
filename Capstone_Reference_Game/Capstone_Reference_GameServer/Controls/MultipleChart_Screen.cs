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
        public MultipleChart_Screen(string title, List<string> questions)
        {
            InitializeComponent();
            lbl_Title.Text = title;
            
            for(int i = 0; i < questions.Count; i++)
            {
                Controls["lbl_Num" + (i + 1)].Visible = true;
                Controls["lbl_AnNum" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Visible = true;
                Controls["lbl_Answer" + (i + 1)].Text = questions[i];


                

            }
        }

    }
}
