using Capstone_Reference_Game.Object;

namespace Capstone_Reference_Game
{

    public partial class QuizBaseForm : Form
    {
        // ���� ĳ����
        protected ClientCharacter userCharacter = new ClientCharacter(0,1);

        // �� �����Ӹ��� Update�� ȣ���Ű�� Ÿ�̸�
        private System.Threading.Timer UpdateTimer;

        // �����
        private System.Threading.Timer FPSTimer;
        private int FPS = 0;

        public QuizBaseForm()
        {
            InitializeComponent();

            // ����ȭ
            DoubleBuffered = true;
            SetStyle(ControlStyles.ResizeRedraw, true);
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);

            // 60������ ȭ�� ������Ʈ
            TimerCallback tc = new TimerCallback(Update);
            UpdateTimer = new System.Threading.Timer(tc, null, Timeout.Infinite, Timeout.Infinite);

            TimerCallback tc2 = new TimerCallback(DebugTimer);
            FPSTimer = new System.Threading.Timer(tc2, null, 0, 1000);
            FPS = 0;

            // Dispose ����
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

        // ȭ�� �ٽñ׸���
        protected virtual void Update(object? temp)
        {
            FPS++;
            Invalidate();
        }

        // ������ ǥ��
        private void DebugTimer(object? c)
        {
            Console.WriteLine(FPS + "FPS.");
            FPS = 0;
        }

        #endregion

        #region Input Process

        // Ű�� ������ ��
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    if (userCharacter.LeftKeyDown == false)
                    {
                        userCharacter.LeftKeyDown = true;
                        
                        // ����Ű true ����
                    }
                    break;
                case Keys.Right:
                    if (userCharacter.RightKeyDown == false)
                    {
                        userCharacter.RightKeyDown = true;
                        
                        // ������Ű true ����
                    }
                    break;
                case Keys.Up:
                    if (userCharacter.UpKeyDown == false)
                    {
                        userCharacter.UpKeyDown = true;

                        // ��Ű true ����
                    }
                    break;
                case Keys.Down:
                    if (userCharacter.DownKeyDown == false)
                    {
                        userCharacter.DownKeyDown = true;

                        // �Ʒ�Ű true ����
                    }
                    break;
                default:
                    return base.ProcessCmdKey(ref msg, keyData);
            }

            return true;
        }

        // Ű�� �������� ��
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            switch (e.KeyData)
            {
                case Keys.Left:
                    if (userCharacter.LeftKeyDown == true)
                    {
                        userCharacter.LeftKeyDown = false;

                        // ����Ű false ����
                    }
                    break;
                case Keys.Right:
                    if (userCharacter.RightKeyDown == true)
                    {
                        userCharacter.RightKeyDown = false;

                        // ������Ű false ����
                    }
                    break;
                case Keys.Up:
                    if (userCharacter.UpKeyDown == true)
                    {
                        userCharacter.UpKeyDown = false;

                        // ��Ű false ����
                    }
                    break;
                case Keys.Down:
                    if (userCharacter.DownKeyDown == true)
                    {
                        userCharacter.DownKeyDown = false;

                        // �Ʒ�Ű false ����
                    }
                    break;
                default:
                    break;
            }
        }

        // ���� ��Ŀ���� Ǯ���� ( ��Ʈ ��, �ٸ� ������ ���ý� ) �̺�Ʈ �߻�
        private void Form_Deactivate(object sender, EventArgs e)
        {
            // �Է����� Ű ��� ����

            // ��� Ű ���� ����
        }
        #endregion

        
    }
}