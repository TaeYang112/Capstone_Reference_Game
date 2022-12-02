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
        public Descriptive_Screen(string title)
        {
            InitializeComponent();
            lbl_Title.Text = title;
        }


        private void MultipleChart_Screen_Load(object sender, EventArgs e)
        {
        }

        public void Update(string context, string StudentID, string StudentName)
        {
            lbl_Context.Text = context;
            lbl_Name.Text = StudentID + "  " + StudentName;
        }

    }
}
