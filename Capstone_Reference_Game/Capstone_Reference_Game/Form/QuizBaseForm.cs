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
        private Bitmap? arrow;

        // 클라이언트 매니저 ( 유저 캐릭터를 제외한 나머지 클라이언트 제어 )
        public ClientManager clientManager { get; } =  new ClientManager();

        // 매 프레임마다 Update를 호출시키는 타이머
        private System.Threading.Timer UpdateTimer;

        // 게임 시작 여부
        public bool IsStart { get; private set; }

        // 타이머 프로그레스바
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // 자신이 고른 정답을 보여주는 라벨
        private CustomLabel? lbl_MyAnswer;

        // 관전자 모드 여부
        public bool Spectator { get; }

        // 문제 큰 제목
        private string _title = string.Empty;

        // 카운트 다운 변수
        private int count;

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
                arrow = Properties.Resources.arrow;
                lbl_MyAnswer = new CustomLabel(new Point(0, 100), new Size(1024, 20));
                lbl_MyAnswer.Font = new Font(ResourceLibrary.Families[0], 15, FontStyle.Regular);
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

            // Dispose 설정
            Disposed += CustomDispose;

            Paint += OnPaint;
            progressBar.OnTimerStop += OnTimerStop;
        }

        // 비관리 메모리 해제
        protected virtual void CustomDispose(object? sender, EventArgs e)
        {
            UpdateTimer.Dispose();
            progressBar.Dispose();
            if(Spectator == false)
            {
                userCharacter!.Dispose();
                arrow!.Dispose();
                lbl_MyAnswer!.Dispose();
            }
            
        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Change(0, 15);
        }

        #endregion

        // 게임 시작
        public virtual void Start()
        {
            // 게임이 시작되었거나 카운트가 진행중이면 나감
            if (IsStart || timer_CountDown.Enabled)
            {
                return;
            }

            // 큰제목 라벨에 제목넣어줌
            lbl_ProblemTitle.Text = _title;
            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);

            IsStart = true;
            
            // 관전자가 아닐경우
            if (Spectator == false)
            {
                // 캐릭터 시작 위치 설정
                userCharacter!.Location = new Point(ClientRectangle.Width / 2 - userCharacter.Size.Width / 2, (ClientRectangle.Height - 120) / 2 - userCharacter.Size.Height / 2 + 120);
            }

            // 사용자가 타이머의 시간을 정했을 때만 타이머를 시작함
            if (progressBar.TargetTime > 0)
            {
                progressBar.Start();
            }
        }

        // 카운트 다운과 함께 게임을 시작함
        public void StartWithCount(int sec)
        {
            // 게임이 시작되었거나 카운트가 진행중이면 나감
            if(IsStart || timer_CountDown.Enabled)
            {
                return;
            }

            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 50, FontStyle.Regular);
            lbl_ProblemTitle.Text = sec.ToString();

            count = sec - 1;
            timer_CountDown.Enabled = true;
        }

        
        // 카운트 다운이 시작되면 1초마다 호출됨
        private void timer_CountDown_Tick(object sender, EventArgs e)
        {
            if(count == 0)
            {
                timer_CountDown.Enabled = false;
                Start();
                return;
            }
            lbl_ProblemTitle.Text = count.ToString();
            count--;
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
            _title = title;
            if(IsStart)
            {
                lbl_ProblemTitle.Text = title;
            }
        }

        // 타이머 종료
        protected virtual void OnTimerStop(object? sender, EventArgs e)
        {
            // Console.WriteLine(GetAnswer());
        }

        #region Graphic

        // 화면 다시그리기
        protected virtual void Update(object? temp)
        {
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
                    // 자신이 고른 답 표시
                    lbl_MyAnswer!.Text = GetAnswerString();
                    lbl_MyAnswer.Draw(e.Graphics);

                    // 자신 클라이언트 출력
                    userCharacter!.Draw(e.Graphics);

                    Point arrowPoint = new Point(userCharacter.Location.X + userCharacter.Size.Width/2 - arrow!.Width/2, userCharacter.Location.Y - 20);

                    // 캐릭터 위에 화살표 표시
                    e.Graphics.DrawImage(arrow, arrowPoint);
                }
            }
        }

        // 자신이 고른 정답 표시
        protected virtual string GetAnswerString()
        {
            return "";
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