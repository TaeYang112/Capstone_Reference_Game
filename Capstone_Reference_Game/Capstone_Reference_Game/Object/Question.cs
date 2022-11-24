using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_Game.Object
{
    internal class Question : IDisposable, IPaintable
    {
        private bool disposedValue;

        public Point Location { get; set; }
        public Size Size { get; set; }

        // 비관리 메모리
        private Font font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);
        private StringFormat sf = new StringFormat();
        private Pen pen = new Pen(Color.Black,3);
        public string Text { get; set; } = string.Empty;

        public Question(Point location, Size size)
        {
            this.Location = location;
            this.Size = size;
            sf.Alignment = StringAlignment.Center;
            sf.LineAlignment = StringAlignment.Center;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                font.Dispose();
                sf.Dispose();
                pen.Dispose();
                disposedValue = true;
            }
        }

        ~Question()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        public void Draw(Graphics g)
        {
            Rectangle rect = new Rectangle(Location.X, Location.Y, Size.Width, Size.Height);
            

            g.FillRectangle(Brushes.White, rect);
            g.DrawRectangle(pen, rect);
            g.DrawString(Text, font, Brushes.Black, rect, sf);
        }
    }
}
