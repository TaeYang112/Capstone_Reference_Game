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
        private int O_count = 0;
        private int X_count = 0;
        public OXChart_Screen(string title)
        {
            InitializeComponent();
            this.lbl_Title.Text = title;
        }

        private void OXChart_Screen_Load(object sender, EventArgs e)
        {

        }

        public void AddResult(int answer)
        {
            if(answer == 1) O_count++;
            else if(answer == 2) X_count++;

            int size;
            int sum = O_count + X_count;
            if (sum == 0)
                size = 100;
            else
            {
                size = (int)(200 * ((float)O_count / sum));
            }
            Invoke(new Action(() =>
            {
                pnl_OChart.Size = new Size(size, pnl_OChart.Size.Height);
            }
            ));
        }

    }
}
