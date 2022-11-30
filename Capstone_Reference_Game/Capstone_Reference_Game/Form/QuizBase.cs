using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Object;
using Capstone_Reference_Game.Other;
using System.Collections.Concurrent;
using System.Runtime.InteropServices;

namespace Capstone_Reference_Game
{

     public partial class QuizBase : UserControl
     {
        #region Basic

        // 유저 캐릭터 위에 있는 화살표
        private Bitmap? arrow;

        // 매 프레임마다 Update를 호출시키는 타이머
        private System.Threading.Timer UpdateTimer;

        // 게임 시작 여부
        public bool IsStart { get; private set; }

        // 타이머 프로그레스바
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // 자신이 고른 정답을 보여주는 라벨
        private CustomLabel? lbl_MyAnswer;

        // 큰 제목 라벨
        private CustomLabel lbl_ProblemTitle = new CustomLabel(new Point(0,18), new Size(1024,97));

        protected ClientCharacter? userCharacter;
        protected ConcurrentDictionary<int, ClientCharacter> clients;

        // 문제 큰 제목
        private string _title = string.Empty;

        // 카운트 다운 변수
        private int count;

        public QuizBase(ClientCharacter? user, ConcurrentDictionary<int, ClientCharacter> clients)
        {
            InitializeComponent();

            userCharacter = user;
            this.clients = clients;

            if (user != null)
            {
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
            lbl_ProblemTitle.Dispose();
            progressBar.Dispose();
            if(userCharacter != null)
            {
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
            if (userCharacter != null)
            {
                // 캐릭터 시작 위치 설정
                Point clientCenterLoc = new Point(ClientRectangle.Width / 2 - userCharacter.Size.Width / 2, (ClientRectangle.Height - 120) / 2 - userCharacter.Size.Height / 2 + 120);
                userCharacter.Location = clientCenterLoc;
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
        public void SetTargetTime(int sec, int cu)
        {
            progressBar.TargetTime = sec;
            progressBar.TimeOffset = cu;
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
            // 자신의 캐릭터 이동
            if (userCharacter != null)
            {
                userCharacter.MoveWithKeyDown();
            }
            // 다른 클라이언트 이동
            foreach (var client in clients)
            {
                client.Value.MoveWithKeyDown();
            }
            Invalidate();
        }


        protected virtual void OnPaint(object? sender, PaintEventArgs e)
        {
            progressBar.Draw(e.Graphics);
            lbl_ProblemTitle.Draw(e.Graphics);
            if (IsStart)
            {
                foreach (var client in clients)
                {
                    client.Value.Draw(e.Graphics);
                }

                // 관전 모드가 아니라면
                if (userCharacter != null)
                {
                    // 자신이 고른 답 표시
                    lbl_MyAnswer!.Text = GetAnswerString();
                    lbl_MyAnswer.Draw(e.Graphics);

                    // 자신 클라이언트 출력
                    userCharacter.Draw(e.Graphics);

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

        

        
    }
}