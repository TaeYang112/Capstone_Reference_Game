using Capstone_Reference_Game.Object;

namespace Capstone_Reference_Game
{

    public partial class QuizBaseForm : Form
    {
        // 유저 캐릭터
        protected ClientCharacter userCharacter = new ClientCharacter(0,1);

        // 매 프레임마다 Update를 호출시키는 타이머
        private System.Threading.Timer UpdateTimer;

        // 디버그
        private System.Threading.Timer FPSTimer;
        private int FPS = 0;

        public QuizBaseForm()
        {
            InitializeComponent();

            // 최적화
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 60프레임 화면 업데이트
            TimerCallback tc = new TimerCallback(Update);
            UpdateTimer = new System.Threading.Timer(tc, null, Timeout.Infinite, Timeout.Infinite);

            TimerCallback tc2 = new TimerCallback(DebugTimer);
            FPSTimer = new System.Threading.Timer(tc2, null, 0, 1000);
            FPS = 0;

            // Dispose 설정
            Disposed += CustomDispose;
        }

        protected virtual void CustomDispose(object? sender, EventArgs e)
        {
            FPSTimer.Dispose();
            UpdateTimer.Dispose();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Change(0, 15);
        }

        #region Graphic

        // 화면 다시그리기
        protected virtual void Update(object? temp)
        {
            FPS++;
            Invalidate();
        }

        // 프레임 표시
        private void DebugTimer(object? c)
        {
            Console.WriteLine(FPS + "FPS.");
            FPS = 0;
        }

        #endregion

        #region Input Process

        // 키가 눌렸을 때
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    if (userCharacter.LeftKeyDown == false)
                    {
                        userCharacter.LeftKeyDown = true;
                        
                        // 왼쪽키 true 전송
                    }
                    break;
                case Keys.Right:
                    if (userCharacter.RightKeyDown == false)
                    {
                        userCharacter.RightKeyDown = true;
                        
                        // 오른쪽키 true 전송
                    }
                    break;
                case Keys.Up:
                    if (userCharacter.UpKeyDown == false)
                    {
                        userCharacter.UpKeyDown = true;

                        // 윗키 true 전송
                    }
                    break;
                case Keys.Down:
                    if (userCharacter.DownKeyDown == false)
                    {
                        userCharacter.DownKeyDown = true;

                        // 아랫키 true 전송
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        // 키가 떼어졌을 때
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    if (userCharacter.LeftKeyDown == true)
                    {
                        userCharacter.LeftKeyDown = false;

                        // 왼쪽키 false 전송
                    }
                    break;
                case Keys.Right:
                    if (userCharacter.RightKeyDown == true)
                    {
                        userCharacter.RightKeyDown = false;

                        // 오른쪽키 false 전송
                    }
                    break;
                case Keys.Up:
                    if (userCharacter.UpKeyDown == true)
                    {
                        userCharacter.UpKeyDown = false;

                        // 윗키 false 전송
                    }
                    break;
                case Keys.Down:
                    if (userCharacter.DownKeyDown == true)
                    {
                        userCharacter.DownKeyDown = false;

                        // 아랫키 false 전송
                    }
                    break;
                default:
                    break;
            }
        }

        // 폼의 포커스가 풀리면 ( 알트 탭, 다른 윈도우 선택시 ) 이벤트 발생
        private void Form_Deactivate(object sender, EventArgs e)
        {
            // 입력중인 키 모두 해제

            // 모든 키 해제 전송
        }
        #endregion

        
    }
}