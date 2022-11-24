using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_Game.Object
{
    public class TimerProgress : IPaintable, IDisposable
    {
        public event EventHandler<EventArgs>? OnTimerStop;

        private bool disposedValue;

        public Size Size { get; set; }
        public Point Location { get; set; }

        // 진행바 색
        private Brush brush = new SolidBrush(Color.FromArgb(255, 255, 159, 118));

        // 시간을 측정할 스톱워치
        public Stopwatch st { get; private set; } = new Stopwatch();

        // 실제 타이머
        private System.Threading.Timer Timer;

        // 목표 시간 ( 초단위)
        public int TargetTime { get; set; }

        // 시작 여부
        public bool IsStart { get; private set; } = false;

        public TimerProgress(Point location, Size size)
        {
            Location = location;
            Size = size;

            // 타이머 초기화
            TimerCallback tc = new TimerCallback(TimerRunningOut);
            Timer = new System.Threading.Timer(tc, null, Timeout.Infinite, Timeout.Infinite);
        }

        public void Start()
        {
            if (IsStart == false)
            {
                st.Start();
                IsStart = true;

                // 타이머 ON
                Timer.Change(TargetTime * 1000, Timeout.Infinite);
            }
        }

        public void Draw(Graphics g)
        {
            if (IsStart)
            {
                float remainTime = TargetTime - (float)st.ElapsedMilliseconds / 1000;
                if (remainTime < 0) remainTime = 0;
                float ratio = remainTime / TargetTime;
                Size tempSize = new Size((int)(Size.Width * ratio), Size.Height);

                g.FillRectangle(brush, new Rectangle(Location, tempSize));
            }
        }

        private void TimerRunningOut(object? o)
        {
            st.Stop();
            IsStart=false;

            if(OnTimerStop != null)
            {
                OnTimerStop(this, EventArgs.Empty);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 관리형 상태(관리형 개체)를 삭제합니다.
                }

                // TODO: 비관리형 리소스(비관리형 개체)를 해제하고 종료자를 재정의합니다.
                brush.Dispose();

                disposedValue = true;
            }
        }

        ~TimerProgress()
        {
             // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
             Dispose(disposing: false);
        }

        public void Dispose()
        {
            // 이 코드를 변경하지 마세요. 'Dispose(bool disposing)' 메서드에 정리 코드를 입력합니다.
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
