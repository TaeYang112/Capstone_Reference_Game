
using System.Numerics;

namespace Capstone_Reference_Game.Object
{
    public class ClientCharacter : IPaintable
    {
        // 클라이언트 구별을 위한 유일 키
        public int Key { get; }

        public int Speed { get; set; }

        // 그래픽을 위한 멤버
        public Point Location { get; set; }
        private Size size = new Size(42, 35);
        private Image? image;
        private Image? leftImage;
        private Image? rightImage;

        // 스레드


        // 이동키 누름 여부
        public bool LeftKeyDown { get; set; } = false;
        public bool RightKeyDown { get; set; } = false;
        public bool UpKeyDown { get; set; } = false;
        public bool DownKeyDown { get; set; } = false;


        public ClientCharacter(int key, int skinNum)
        {
            this.Speed = 4;
            this.Key = key;
            SetSkin(skinNum);
        }

        private void SetSkin(int skinNum)
        {
            Bitmap? tempImage;
            switch (skinNum % 8)
            {
                case 0:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Red;
                    break;
                case 1:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Orange;
                    break;
                case 2:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Yellow;
                    break;
                case 3:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Green;
                    break;
                case 4:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Blue;
                    break;
                case 5:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Purple;
                    break;
                case 6:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Pink;
                    break;
                case 7:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Gray;
                    break;
                default:
                    tempImage = Capstone_Reference_Game.Properties.Resources.Red;
                    break;
            }
            rightImage = new Bitmap(tempImage, size);
            leftImage = new Bitmap(tempImage, size);
            leftImage.RotateFlip(RotateFlipType.RotateNoneFlipX);

            image = rightImage;
        }

        public void Draw(Graphics g)
        {
            g.DrawImage(image!, new Rectangle(Location, size));
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
            if(velocity.X < 0)
            {
                image = leftImage;
            }
            else if(velocity.X > 0)
            {
                image = rightImage;
            }

            // 피타고라스 정리에 따라 대각선으로 이동할 때 더빠르므로 정규화를 통해 속도 조정
            float velSize = (float)Math.Sqrt(velocity.X * velocity.X + velocity.Y * velocity.Y);
            if (velSize == 0) return;

            PointF normalVel = new PointF(velocity.X / velSize, velocity.Y / velSize);
            Location = new Point(Location.X + (int)Math.Round(normalVel.X * Speed), Location.Y + (int)Math.Round(normalVel.Y * Speed));
        }
    }
}
