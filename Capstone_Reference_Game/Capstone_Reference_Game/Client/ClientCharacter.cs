
using System.Numerics;

namespace Capstone_Reference_Game.Client
{
    public class ClientCharacter : IPaintable, IDisposable
    {
        #region Basic
        // 클라이언트 구별을 위한 유일 키
        public int Key { get; }

        public int Speed { get; set; }

        // 그래픽을 위한 멤버
        public Point Location { get; set; }
        public Size Size { get; set; }
        private Image? image;
        private bool isLookRight = true;
        private bool doLookRight = true;

        // 스레드


        // 이동키 누름 여부
        public bool LeftKeyDown { get; set; } = false;
        public bool RightKeyDown { get; set; } = false;
        public bool UpKeyDown { get; set; } = false;
        public bool DownKeyDown { get; set; } = false;
        

        // Dispose 재호출 방지를 위한 플래그 변수
        private bool _disposed = false;

        public ClientCharacter(int key, int skinNum)
        {
            Size = new Size(42, 35);
            this.Speed = 4;
            this.Key = key;
            SetSkin(skinNum);
        }

        ~ClientCharacter() => Dispose(false);

        // 사용자가 원할 때 메모리를 해제할 수 있는 함수
        public void Dispose()
        {
            Dispose(true);

            // Dispose패턴을 통해 메모리를 해제했기 때문에 소멸자 호출을 막음
            GC.SuppressFinalize(this);
        }

        // Dispose 패턴
        protected virtual void Dispose(bool disposing)
        {
            if (_disposed)
            {
                return;
            }

            if (disposing)
            {
                // 관리 메모리 해제
            }

            // 비관리 메모리 해제
            image!.Dispose();

            _disposed = true;
        }

        #endregion Basic

        private void SetSkin(int skinNum)
        {
            switch (skinNum % 8)
            {
                case 0:
                    image = Properties.Resources.Red;
                    break;
                case 1:
                    image = Properties.Resources.Orange;
                    break;
                case 2:
                    image = Properties.Resources.Yellow;
                    break;
                case 3:
                    image = Properties.Resources.Green;
                    break;
                case 4:
                    image = Properties.Resources.Blue;
                    break;
                case 5:
                    image = Properties.Resources.Purple;
                    break;
                case 6:
                    image = Properties.Resources.Pink;
                    break;
                case 7:
                    image = Properties.Resources.Gray;
                    break;
                default:
                    image = Properties.Resources.Red;
                    break;
            }
        }

        public void Draw(Graphics g)
        {
            if (doLookRight != isLookRight)
            {
                image!.RotateFlip(RotateFlipType.RotateNoneFlipX);
                isLookRight = doLookRight;
            }
            g.DrawImage(image!, new Rectangle(Location, Size));
        }

        public void MoveWithKeyDown()
        {
            PointF velocity = new PointF(0.0f, 0.0f);

            // 왼쪽 방향키가 눌려있는 상태라면 왼쪽으로 움직임
            if (LeftKeyDown == true)
            {
                velocity.X -= 1.0f;
            }

            // 오른쪽 방향키가 눌려있는 상태라면 오른쪽으로 움직임
            if (RightKeyDown == true)
            {
                velocity.X += 1.0f;
            }

            // 윗쪽 방향키가 눌려있는 상태라면 왼쪽으로 움직임
            if (UpKeyDown == true)
            {
                velocity.Y -= 1.0f;
            }

            // 윗쪽 방향키가 눌려있는 상태라면 왼쪽으로 움직임
            if (DownKeyDown == true)
            {
                velocity.Y += 1.0f;
            }

            // 움직이는 방향에 따라 이미지 설정
            if (velocity.X < 0)
            {
                doLookRight = false;
            }
            else if (velocity.X > 0)
            {
                doLookRight = true;
            }

            // 피타고라스 정리에 따라 대각선으로 이동할 때 더빠르므로 정규화를 통해 속도 조정
            float velSize = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            if (velSize == 0) return;

            PointF normalVel = new PointF(velocity.X / velSize, velocity.Y / velSize);
            Point tempPoint = new Point(Location.X + (int)Math.Round(normalVel.X * Speed), Location.Y + (int)Math.Round(normalVel.Y * Speed));


            // 맵 밖에 나가지 못하게 조정
            if (tempPoint.X < 0) tempPoint.X = 0;
            else if (tempPoint.X > 1024 - Size.Width) tempPoint.X = 1024 - Size.Width;

            if(tempPoint.Y < 120) tempPoint.Y = 120;
            else if(tempPoint.Y > 600 - Size.Height) tempPoint.Y = 600 - Size.Height;

            Location = tempPoint;
        }

    }
}
