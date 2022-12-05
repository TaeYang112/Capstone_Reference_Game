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
    public partial class OXChart_Screen : UserControl
    {
        private int oValue = 0;
        private int xValue = 0;

        public OXChart_Screen(int correctAnswer)
        {
            InitializeComponent();

            Brush AnswerBrush = new SolidBrush(Color.FromArgb(120, 30, 255));
            Brush NotAnswerBrush = new SolidBrush(Color.FromArgb(180, 130, 255));

            // O가 정답
            if (correctAnswer == 1)
            {
                pieGraph1.OBrush = AnswerBrush;
                pnl_OColor.BackColor = Color.FromArgb(120, 30, 255);

                pieGraph1.XBrush = NotAnswerBrush;
                pnl_XColor.BackColor = Color.FromArgb(180, 130, 255);
            }
            // X가 정답
            else
            {
                pieGraph1.XBrush = AnswerBrush;
                pnl_XColor.BackColor = Color.FromArgb(120, 30, 255);

                pieGraph1.OBrush = NotAnswerBrush;
                pnl_OColor.BackColor = Color.FromArgb(180, 130, 255);
            }
        }

        private void OXChart_Screen_Load(object sender, EventArgs e)
        {
        }

        public void SetTitle(string title)
        {
            lbl_Title.Text = title;
        }

        public void AddResult(int answer)
        {
            if (answer == 1)
            {
                oValue++;
                pieGraph1.OValue = oValue;
            }
            else if (answer == 2)
            {
                xValue++;
                pieGraph1.XValue = xValue;
            }
            UpdateLegend();

        }

        // 범례 (legend) 내용 업데이트
        private void UpdateLegend()
        {
            // 합
            int sum = xValue + oValue;

            // 비율
            float oRatio;
            if (sum == 0)
            {
                oRatio = 0.5f;
            }
            else
            {
                oRatio = (float)oValue / sum;
            }

            lbl_oRatio.Text = ((int)(oRatio * 100)).ToString() + "%";
            lbl_xRatio.Text = ((int)((1 - oRatio) * 100)).ToString() + "%";

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
