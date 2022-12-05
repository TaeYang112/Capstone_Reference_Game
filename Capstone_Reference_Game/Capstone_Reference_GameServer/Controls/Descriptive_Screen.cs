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
    public partial class Descriptive_Screen : UserControl
    {
        // 답안 별 제출수
        //private List<int> question_submitCounts;
        public Descriptive_Screen()
        {
            InitializeComponent();
        }

        public void SetTitle(string title)
        {
            lbl_Title.Text = title;
        }


        private void MultipleChart_Screen_Load(object sender, EventArgs e)
        {
        }

        public void Update(string context, string StudentID, string StudentName)
        {
            lbl_Context.Text = context;
            lbl_ID.Text = "학번 : " + StudentID;
            lbl_Name.Text = "이름 : " + StudentName;
            label1.Text = "답안";
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
