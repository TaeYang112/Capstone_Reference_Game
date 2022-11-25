using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_Game.Object
{
    internal class CustomLabel : IDisposable, IPaintable
    {
        private bool disposedValue;

        public Point Location { get; set; }
        public Size Size { get; set; }

        // 비관리 메모리
        private Font _font = new Font(ResourceLibrary.Families[0], 20, FontStyle.Regular);
        public Font Font
        {
            get { return _font; }
            set 
            {
                _font.Dispose();
                _font = value; 
            }
        }
        private StringFormat _format;
        public StringFormat Format
        {
            get { return _format; }
            set 
            {
                _format.Dispose();
                _format = value;
            }
        }

        // 텍스트
        public string Text { get; set; } = String.Empty;
        

        public CustomLabel(Point location, Size size)
        {
            this.Location = location;
            this.Size = size;

            _format = new StringFormat();
            _format.Alignment = StringAlignment.Center;
            _format.LineAlignment = StringAlignment.Center;
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                _font.Dispose();
                _format.Dispose();
                disposedValue = true;
            }
        }

        ~CustomLabel()
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
            g.DrawString(Text, _font, Brushes.Black, rect, _format);
        }
    }
}
