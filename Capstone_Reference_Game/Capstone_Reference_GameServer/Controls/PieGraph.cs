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
    public partial class PieGraph : UserControl
    {
        private int _oValue;
        public int OValue 
        {
            get 
            { 
                return _oValue;
            }
            set 
            { 
                _oValue = value; 
                Invalidate(ClientRectangle);
            }
        }

        private Brush _oBrush;
        public Brush OBrush {
            get 
            {
                return _oBrush;
            }
            set
            {
                _oBrush.Dispose();
                _oBrush = value;
                Invalidate(ClientRectangle);
            }
        }

        private int _xValue;
        public int XValue
        {
            get 
            {
                return _xValue;
            }
            set 
            {
                _xValue = value;
                Invalidate(ClientRectangle);
            }
        }

        private Brush _xBrush;
        public Brush XBrush
        {
            get
            {
                return _xBrush;
            }
            set
            {
                _xBrush.Dispose();
                _xBrush = value;
                Invalidate(ClientRectangle);
            }
        }

        public int ChartMargin { get; set; } = 10;


        public PieGraph()
        {
            InitializeComponent();
            _oBrush = new SolidBrush(Color.Blue);
            _xBrush = new SolidBrush(Color.Red);
        }

        ~PieGraph()
        {
            OBrush.Dispose();
            XBrush.Dispose();
        }

        private void PieGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int sum = XValue + OValue;
            float oRatio;

            if (sum == 0)
            {
                oRatio = 0.5f;
            }
            else
            {
                oRatio = (float)OValue / sum;
            } 

            Rectangle rect = new Rectangle(ChartMargin, ChartMargin, this.Width - ChartMargin, this.Height - ChartMargin);

            // X
            g.FillEllipse(XBrush, rect);

            // O
            g.FillPie(OBrush, rect, 270, 360 * oRatio);
        }

    }
}
