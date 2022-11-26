using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Object;

namespace Capstone_Reference_Game
{

    public partial class QuizBaseForm : System.Windows.Forms.Form
    {
        #region Basic

        // ���� ĳ����
        protected ClientCharacter? userCharacter;

        // ���� ĳ���� ���� �ִ� ȭ��ǥ
        private Bitmap? arrow;

        // Ŭ���̾�Ʈ �Ŵ��� ( ���� ĳ���͸� ������ ������ Ŭ���̾�Ʈ ���� )
        public ClientManager clientManager { get; } =  new ClientManager();

        // �� �����Ӹ��� Update�� ȣ���Ű�� Ÿ�̸�
        private System.Threading.Timer UpdateTimer;

        // ���� ���� ����
        public bool IsStart { get; private set; }

        // Ÿ�̸� ���α׷�����
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // �ڽ��� �� ������ �����ִ� ��
        private CustomLabel? lbl_MyAnswer;

        // ������ ��� ����
        public bool Spectator { get; }

        // ���� ū ����
        private string _title = string.Empty;

        // ī��Ʈ �ٿ� ����
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
            if (Spectator == false)
            {
                // ĳ���� ���� ��ġ ����
                userCharacter!.Location = new Point(ClientRectangle.Width / 2 - userCharacter.Size.Width / 2, (ClientRectangle.Height - 120) / 2 - userCharacter.Size.Height / 2 + 120);
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
        public void SetTargetTime(int sec)
        {
            progressBar.TargetTime = sec;
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
            if (Spectator == false)
            {
                // �ڽ��� ĳ���� �̵�
                userCharacter!.MoveWithKeyDown();
            }

            // �ٸ� Ŭ���̾�Ʈ �̵�
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

                // ���� ��尡 �ƴ϶��
                if (Spectator == false)
                {
                    // �ڽ��� �� �� ǥ��
                    lbl_MyAnswer!.Text = GetAnswerString();
                    lbl_MyAnswer.Draw(e.Graphics);

                    // �ڽ� Ŭ���̾�Ʈ ���
                    userCharacter!.Draw(e.Graphics);

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

        #region Input Process

        // Ű�� ������ ��
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // ������ ����ϰ�� Űó�� X
            if (IsStart && Spectator == false)
            {
                switch (keyData)
                {
                    case Keys.Left:
                        if (userCharacter!.LeftKeyDown == false)
                        {
                            userCharacter.LeftKeyDown = true;

                            // ����Ű true ����
                        }
                        break;
                    case Keys.Right:
                        if (userCharacter!.RightKeyDown == false)
                        {
                            userCharacter.RightKeyDown = true;

                            // ������Ű true ����
                        }
                        break;
                    case Keys.Up:
                        if (userCharacter!.UpKeyDown == false)
                        {
                            userCharacter.UpKeyDown = true;

                            // ��Ű true ����
                        }
                        break;
                    case Keys.Down:
                        if (userCharacter!.DownKeyDown == false)
                        {
                            userCharacter.DownKeyDown = true;

                            // �Ʒ�Ű true ����
                        }
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }
            }
            return true;
        }

        // Ű�� �������� ��
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            // ������ �ϰ�� Űó�� X
            if (IsStart && Spectator == false)
            {
                switch (e.KeyData)
                {
                    case Keys.Left:
                        if (userCharacter!.LeftKeyDown == true)
                        {
                            userCharacter.LeftKeyDown = false;

                            // ����Ű false ����
                        }
                        break;
                    case Keys.Right:
                        if (userCharacter!.RightKeyDown == true)
                        {
                            userCharacter.RightKeyDown = false;

                            // ������Ű false ����
                        }
                        break;
                    case Keys.Up:
                        if (userCharacter!.UpKeyDown == true)
                        {
                            userCharacter.UpKeyDown = false;

                            // ��Ű false ����
                        }
                        break;
                    case Keys.Down:
                        if (userCharacter!.DownKeyDown == true)
                        {
                            userCharacter.DownKeyDown = false;

                            // �Ʒ�Ű false ����
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        // ���� ��Ŀ���� Ǯ���� ( ��Ʈ ��, �ٸ� ������ ���ý� ) �̺�Ʈ �߻�
        private void Form_Deactivate(object sender, EventArgs e)
        {
            if (Spectator == false)
            {
                // �Է����� Ű ��� ����

                userCharacter!.DownKeyDown = false;
                userCharacter.UpKeyDown = false;
                userCharacter.LeftKeyDown = false;
                userCharacter.RightKeyDown = false;

                // ��� Ű ���� ����
            }
        }


        #endregion Input Process

        
    }
}