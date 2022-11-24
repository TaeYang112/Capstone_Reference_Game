using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Object;

namespace Capstone_Reference_Game
{

    public partial class QuizBaseForm : System.Windows.Forms.Form
    {
        #region Basic

        // 유저 캐릭터
        protected ClientCharacter? userCharacter;

        // 유저 캐릭터 위에 있는 화살표
        Bitmap arrow = Properties.Resources.arrow;

        // 클라이언트 매니저 ( 유저 캐릭터를 제외한 나머지 클라이언트 제어 )
        public ClientManager clientManager { get; } =  new ClientManager();

        // 매 프레임마다 Update를 호출시키는 타이머
        private System.Threading.Timer UpdateTimer;

        // 디버그
        private System.Threading.Timer FPSTimer;
        private int FPS = 0;

        // 게임 시작 여부
        public bool IsStart { get; private set; }

        // 타이머 프로그레스바
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // 관전자 모드 여부
        public bool Spectator { get; }

        public QuizBaseForm() : this(false)
        {

        }
        public QuizBaseForm(bool isSpectator)
        {
            InitializeComponent();

            this.Spectator = isSpectator;
            if(isSpectator == false)
            {
               userCharacter = new ClientCharacter(0, 1);
            }

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

            Paint += OnPaint;
            progressBar.OnTimerStop += OnTimerStop;
        }

        // 비관리 메모리 해제
        protected virtual void CustomDispose(object? sender, EventArgs e)
        {
            FPSTimer.Dispose();
            UpdateTimer.Dispose();
            progressBar.Dispose();
            userCharacter?.Dispose();
            arrow.Dispose();
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Change(0, 15);
            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);
            lbl_MyAnswer.Font = new Font(ResourceLibrary.Families[0], 15, FontStyle.Regular);
        }

        #endregion

        // 게임 시작
        public virtual void Start()
        {
            if (IsStart == false)
            {
                IsStart = true;
                if (Spectator == false)
                {
                    userCharacter!.Location = new Point(ClientRectangle.Width / 2 - userCharacter.Size.Width / 2, (ClientRectangle.Height - 120) / 2 - userCharacter.Size.Height / 2 + 120);
                }

                // 사용자가 타이머의 시간을 정했을 때만 타이머를 시작함
                if (progressBar.TargetTime > 0)
                {
                    progressBar.Start();
                }
            }
        }

        // 몇번 답을 골랐는지 반환
        public virtual int GetAnswer()
        {
            return 0;
        }

        // 타임어택 설정
        public void SetTargetTime(int sec)
        {
            progressBar.TargetTime = sec;
        }

        // 문제 제목 설정
        public void SetTitle(string title)
        {
            lbl_ProblemTitle.Text = title;
        }

        // 타이머 종료
        protected virtual void OnTimerStop(object? sender, EventArgs e)
        {
            Console.WriteLine(GetAnswer());
        }

        #region Graphic

        // 화면 다시그리기
        protected virtual void Update(object? temp)
        {
            FPS++;

            if (Spectator == false)
            {
                // 자신의 캐릭터 이동
                userCharacter!.MoveWithKeyDown();
            }

            // 다른 클라이언트 이동
            foreach (var client in clientManager.Clients)
            {
                client.Value.MoveWithKeyDown();
            }

            Invalidate(ClientRectangle);
        }

        protected virtual void OnPaint(object? sender, PaintEventArgs e)
        {
            progressBar.Draw(e.Graphics);
            if (IsStart)
            {
                foreach (var client in clientManager.Clients)
                {
                    client.Value.Draw(e.Graphics);
                }

                // 관전 모드가 아니라면
                if (Spectator == false)
                {
                    // 자신 클라이언트 출력
                    userCharacter!.Draw(e.Graphics);

                    Point arrowPoint = new Point(userCharacter.Location.X + userCharacter.Size.Width/2 - arrow.Width/2, userCharacter.Location.Y - 20);

                    // 캐릭터 위에 화살표 표시
                    e.Graphics.DrawImage(arrow, arrowPoint);

                    // 자신이 고른 답 표시
                    lbl_MyAnswer.Text = GetAnswerString();
                }
            }
        }

        // 자신이 고른 정답 표시
        protected virtual string GetAnswerString()
        {
            return "";
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
            // 관전자 모드일경우 키처리 X
            if (IsStart && Spectator == false)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        if (userCharacter!.LeftKeyDown == false)
                        {
                            userCharacter.LeftKeyDown = true;

                            // 왼쪽키 true 전송
                        }
                        break;
                    case Keys.Right:
                        if (userCharacter!.RightKeyDown == false)
                        {
                            userCharacter.RightKeyDown = true;

                            // 오른쪽키 true 전송
                        }
                        break;
                    case Keys.Up:
                        if (userCharacter!.UpKeyDown == false)
                        {
                            userCharacter.UpKeyDown = true;

                            // 윗키 true 전송
                        }
                        break;
                    case Keys.Down:
                        if (userCharacter!.DownKeyDown == false)
                        {
                            userCharacter.DownKeyDown = true;

                            // 아랫키 true 전송
                        }
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return true;
        }

        // 키가 떼어졌을 때
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            // 관전자 일경우 키처리 X
            if (IsStart && Spectator == false)
            {
                switch (e.KeyData)
                {
                    case Keys.Left:
                        if (userCharacter!.LeftKeyDown == true)
                        {
                            userCharacter.LeftKeyDown = false;

                            // 왼쪽키 false 전송
                        }
                        break;
                    case Keys.Right:
                        if (userCharacter!.RightKeyDown == true)
                        {
                            userCharacter.RightKeyDown = false;

                            // 오른쪽키 false 전송
                        }
                        break;
                    case Keys.Up:
                        if (userCharacter!.UpKeyDown == true)
                        {
                            userCharacter.UpKeyDown = false;

                            // 윗키 false 전송
                        }
                        break;
                    case Keys.Down:
                        if (userCharacter!.DownKeyDown == true)
                        {
                            userCharacter.DownKeyDown = false;

                            // 아랫키 false 전송
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // 폼의 포커스가 풀리면 ( 알트 탭, 다른 윈도우 선택시 ) 이벤트 발생
        private void Form_Deactivate(object sender, EventArgs e)
        {
            if (Spectator == false)
            {
                // 입력중인 키 모두 해제

                userCharacter!.DownKeyDown = false;
                userCharacter.UpKeyDown = false;
                userCharacter.LeftKeyDown = false;
                userCharacter.RightKeyDown = false;

                // 모든 키 해제 전송
            }
        }

        #endregion Input Process

        
    }
}