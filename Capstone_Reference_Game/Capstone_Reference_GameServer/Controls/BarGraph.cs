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
    public partial class BarGraph : UserControl
    {
        private List<Bar> Bars = new List<Bar>();
        private List<Rectangle> BarRectangle = new List<Rectangle>();

        // 너비
        public int BarWidth { get; set; }

        // 좌우위아래 여백
        public int BarMargin { get; set; }

        public BarGraph()
        {
            InitializeComponent();
            BarWidth = 50;
            BarMargin = 30;
        }

        private void BarGraph_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            // 그래픽 객체 선언
            Font font = new Font("웰컴체 Regular", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            StringFormat sf = new StringFormat();
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;

            // 막대 및 라벨 그리기
            int barCnt = Bars.Count;
            for (int i = 0; i < barCnt; i++)
            {
                // 막대
                g.FillRectangle(Bars[i].Brush, BarRectangle[i]);

                // 번호
                Rectangle numRect = new Rectangle(new Point(BarRectangle[i].X + BarWidth / 2 - 30, Height - BarMargin), new Size(60,BarMargin));
                g.DrawString(i + 1 + "번", font, Brushes.Black,numRect,sf);

                // 값 ( 개수 )
                Rectangle valueRect = new Rectangle(new Point(BarRectangle[i].X + BarWidth / 2 - 30, BarRectangle[i].Y - 30), new Size(60, BarMargin));
                g.DrawString(Bars[i].Value.ToString(), font, Brushes.Black, valueRect, sf);
            }

            // Dispose
            font.Dispose();
            sf.Dispose();

        }

        // 막대 바의 크기를 다시 계산함
        private void UpdateBar()
        {
            int barCnt = Bars.Count;

            int X_Offset = (Width - (BarMargin * 2) - BarWidth * barCnt) / (barCnt + 1);

            // 최대값
            int maxValue = GetMaxValue();

            for (int i = 0; i< barCnt; i++)
            {
                int barHeight;
                if (maxValue == 0)
                {
                    barHeight = 0;
                }
                else
                {
                    barHeight = (int)((Height - BarMargin * 2) * (float)Bars[i].Value / maxValue); ;
                }
                int y = Height - BarMargin - barHeight;
                int x = BarMargin + BarWidth * i + (X_Offset * (i + 1));

                BarRectangle[i] = new Rectangle(new Point(x, y), new Size(BarWidth, barHeight));
            }
        }

        // 최대 값 반환
        private int GetMaxValue()
        {
            int maxValue = 0;

            foreach(Bar bar in Bars)
            {
                maxValue = Math.Max(bar.Value, maxValue);
            }

            return maxValue;
        }

        // 막대 추가
        public void AddBar(Bar newBar)
        {
            Bars.Add(newBar);
            BarRectangle.Add(new Rectangle());
            UpdateBar();
            Invalidate(ClientRectangle);
        }

        // 해당 막대의 값을 1 증가
        public void AddBarValue(int index)
        {
            Bars[index].Value++;
            UpdateBar();
            Invalidate(ClientRectangle);
        }

        public void UpdateBarValue(int index, int value)
        {
            Bars[index].Value = value;
            UpdateBar();
            Invalidate(ClientRectangle);
        }
    }

    public class Bar
    {
        public Bar()
        {
            _brush = new SolidBrush(Color.Blue);
            Value = 0;
        }
        ~Bar()
        {
            Brush.Dispose();
        }
        public int Value { get; set; }

        private Brush _brush;
        public Brush Brush 
        { 
            get
            {
                return _brush;
            }
            set
            {
                _brush.Dispose();
                _brush = value;
            } 
        }
    }
}
