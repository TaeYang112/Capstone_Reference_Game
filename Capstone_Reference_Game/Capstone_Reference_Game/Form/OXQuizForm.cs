using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_Game
{
    // 가로 1024  /  세로 600
    public partial class OXQuizForm : QuizBaseForm
    {
        public OXQuizForm()
        {
            InitializeComponent();
        }

        private void OXQuizForm_Load(object sender, EventArgs e)
        {
            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);
            lbl_ProblemTitle.Text = "1. \"2 + 2 X 2\" 의 답은 8 이다. 테스트테스트테스트테스트테스테스테트테트스트";
        }

        public void SetTitle(string title)
        {
            lbl_ProblemTitle.Text = title;
        }

        private void OXQuizForm_Paint(object sender, PaintEventArgs e)
        {
            userCharacter.Draw(e.Graphics);
        }

        protected override void Update(object? sender)
        {
            userCharacter.MoveWithKeyDown();
            base.Update(sender);
        }

        
    }
}
