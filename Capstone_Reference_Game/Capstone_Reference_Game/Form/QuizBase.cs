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

        // ���� ĳ���� ���� �ִ� ȭ��ǥ
        private Bitmap? arrow;

        // �� �����Ӹ��� Update�� ȣ���Ű�� Ÿ�̸�
        private System.Threading.Timer UpdateTimer;

        // ���� ���� ����
        public bool IsStart { get; private set; }

        // Ÿ�̸� ���α׷�����
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // �ڽ��� �� ������ �����ִ� ��
        private CustomLabel? lbl_MyAnswer;

        // ū ���� ��
        private CustomLabel lbl_ProblemTitle = new CustomLabel(new Point(0,18), new Size(1024,97));

        protected ClientCharacter? userCharacter;
        protected ConcurrentDictionary<int, ClientCharacter> clients;

        // ���� ū ����
        private string _title = string.Empty;

        // ī��Ʈ �ٿ� ����
        private int count;

        public QuizBase() : this(null,new ConcurrentDictionary<int, ClientCharacter>())
        {
        }

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

            // ����ȭ
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 60������ ȭ�� ������Ʈ
            TimerCallback tc = new TimerCallback(Update);
            UpdateTimer = new System.Threading.Timer(tc, null, Timeout.Infinite, Timeout.Infinite);

            // Dispose ����
            Disposed += CustomDispose;

            Paint += OnPaint;
            progressBar.OnTimerStop += OnTimerStop;
        }

        // ����� �޸� ����
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

        // ���� ����
        public virtual void Start()
        {
            // ������ ���۵Ǿ��ų� ī��Ʈ�� �������̸� ����
            if (IsStart || timer_CountDown.Enabled)
            {
                return;
            }

            // ū���� �󺧿� ����־���
            lbl_ProblemTitle.Text = _title;
            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);

            IsStart = true;

            // �����ڰ� �ƴҰ��
            if (userCharacter != null)
            {
                // ĳ���� ���� ��ġ ����
                Point clientCenterLoc = new Point(ClientRectangle.Width / 2 - userCharacter.Size.Width / 2, (ClientRectangle.Height - 120) / 2 - userCharacter.Size.Height / 2 + 120);
                userCharacter.Location = clientCenterLoc;
            }
            

            // ����ڰ� Ÿ�̸��� �ð��� ������ ���� Ÿ�̸Ӹ� ������
            if (progressBar.TargetTime > 0)
            {
                progressBar.Start();
            }
        }

        // ī��Ʈ �ٿ�� �Բ� ������ ������
        public void StartWithCount(int sec)
        {
            // ������ ���۵Ǿ��ų� ī��Ʈ�� �������̸� ����
            if(IsStart || timer_CountDown.Enabled)
            {
                return;
            }

            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 50, FontStyle.Regular);
            lbl_ProblemTitle.Text = sec.ToString();

            count = sec - 1;
            timer_CountDown.Enabled = true;
        }

        
        // ī��Ʈ �ٿ��� ���۵Ǹ� 1�ʸ��� ȣ���
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

        // ��� ���� ������� ��ȯ
        public virtual int GetAnswer()
        {
            return 0;
        }

        // Ÿ�Ӿ��� ����
        public void SetTargetTime(int sec, int cu)
        {
            progressBar.TargetTime = sec;
            progressBar.TimeOffset = cu;
        }

        // ���� ���� ����
        public void SetTitle(string title)
        {
            _title = title;
            if(IsStart)
            {
                lbl_ProblemTitle.Text = title;
            }
        }

        // Ÿ�̸� ����
        protected virtual void OnTimerStop(object? sender, EventArgs e)
        {
            // Console.WriteLine(GetAnswer());
        }

        #region Graphic

        // ȭ�� �ٽñ׸���
        protected virtual void Update(object? temp)
        {
            // �ڽ��� ĳ���� �̵�
            if (userCharacter != null)
            {
                userCharacter.MoveWithKeyDown();
            }
            // �ٸ� Ŭ���̾�Ʈ �̵�
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

                // ���� ��尡 �ƴ϶��
                if (userCharacter != null)
                {
                    // �ڽ��� �� �� ǥ��
                    lbl_MyAnswer!.Text = GetAnswerString();
                    lbl_MyAnswer.Draw(e.Graphics);

                    // �ڽ� Ŭ���̾�Ʈ ���
                    userCharacter.Draw(e.Graphics);

                    Point arrowPoint = new Point(userCharacter.Location.X + userCharacter.Size.Width/2 - arrow!.Width/2, userCharacter.Location.Y - 20);

                    // ĳ���� ���� ȭ��ǥ ǥ��
                    e.Graphics.DrawImage(arrow, arrowPoint);
                }
            }
        }

        // �ڽ��� �� ���� ǥ��
        protected virtual string GetAnswerString()
        {
            return "";
        }

        #endregion

        

        
    }
}