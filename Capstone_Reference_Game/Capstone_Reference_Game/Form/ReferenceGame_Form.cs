using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Manager;
using Capstone_Reference_Game_Module;
using System.Collections.Concurrent;

namespace Capstone_Reference_Game.Form
{
    public partial class ReferenceGame_Form : System.Windows.Forms.Form
    {
        // 메인 매니저
        public GameManager GameManager { get; private set; }

        // 유저 캐릭터
        public ClientCharacter? UserCharacter { get; private set; }

        // 다른 클라이언트들의 캐릭터
        public ConcurrentDictionary<int, ClientCharacter> Clients { get; } = new ConcurrentDictionary<int, ClientCharacter>();

        // 동기화를 위해 자신의 좌표를 서버에게 알려주는 타이머
        private System.Threading.Timer? syncTimer;

        // 시작 여부
        public bool IsStart { get; set; }

        public ReferenceGame_Form()
        {
            InitializeComponent();
            
            // 프로세스 시작시 들어온 매개변수 분석
            string[] commands = Environment.GetCommandLineArgs();
            string ip = "127.0.0.1";
            string studentID = "GUEST";
            string studentName = " ";

            if (commands.Length >= 2)
            {
                ip = commands[1];
            }

            if(commands.Length >= 4)
            {
                studentID = commands[2];
                studentName = commands[3];

                UserCharacter = new ClientCharacter(-1, 0);
                TimerCallback tc = new TimerCallback(LocationSync);
                syncTimer = new System.Threading.Timer(tc,null,Timeout.Infinite, Timeout.Infinite);
            }

            GameManager = new GameManager(this,ip);
            GameManager.StudentID = studentID;
            GameManager.StudentName = studentName;
            KeyPreview = true;
        }

        private void ReferecneGame_Form_Load(object sender, EventArgs e)
        {
            GameManager.Start();
        }
        
        private void LocationSync(object? o)
        {
            if (UserCharacter != null)
            {
                MessageGenerator generator = new MessageGenerator(Protocols.C_LOCATION_SYNC);
                generator.AddInt(UserCharacter.Location.X);
                generator.AddInt(UserCharacter.Location.Y);

                GameManager.SendMessage(generator.Generate());
            }
        }

        public void GameStart(GameConfiguration config, int currentTime)
        {
            GameManager.Config = config;
            Control? screen;
            if (config.QuizType == QuizTypes.DESCRIPTIVE_QUIZ)
            {
                DescriptiveQuiz dQuiz = new DescriptiveQuiz(this);

                dQuiz.SetTitle(config.Title);
                dQuiz.SetTargetTime(config.Time, currentTime);
                
                dQuiz.Start();

                screen = dQuiz;
            }
            else
            {
                QuizBase? quiz;
                if (config.QuizType == QuizTypes.OX_QUIZ)
                {
                    quiz = new OXQuiz(UserCharacter, Clients);
                }
                else
                {
                    MultipleQuiz mQuiz = new MultipleQuiz(UserCharacter, Clients);
                    mQuiz.SetQuestions(config.Questions);
                    quiz = mQuiz;
                }

                quiz.SetTitle(config.Title);
                quiz.SetTargetTime(config.Time, currentTime);

                quiz.Start();
                
                screen = quiz;
            }

            IsStart = true;
            syncTimer?.Change(0, 500);


            // 화면 전환
            Invoke(new Action(delegate () {
                this.Controls.Clear();
                this.Controls.Add(screen);
            }));

        }

        #region Input Process

        // 키가 눌렸을 때
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            // 관전자 모드일경우 키처리 X
            if (IsStart && UserCharacter != null)
            {
                // 메시지 생성기 생성
                MessageGenerator generator = new MessageGenerator(Protocols.C_KEY_INPUT);

                byte downKey;
                switch (keyData)
                {
                    case Keys.Left:
                        downKey = Keyboard.LEFT;
                        break;
                    case Keys.Right:
                        downKey = Keyboard.RIGHT;
                        break;
                    case Keys.Up:
                        downKey = Keyboard.UP;
                        break;
                    case Keys.Down:
                        downKey = Keyboard.DOWN;
                        break;
                    default:
                        return base.ProcessCmdKey(ref msg, keyData);
                }

                if (UserCharacter.Keys[downKey] == false)
                {
                    UserCharacter.Keys[downKey] = true;
                    generator.AddByte(downKey);
                    generator.AddBool(true);

                    // 눌린 키를 서버에 알려줌
                    GameManager.SendMessage(generator.Generate());
                }
            }
            else
            {
                return base.ProcessCmdKey(ref msg, keyData);
            }
            return true;
        }

        // 키가 떼어졌을 때
        private void Form_KeyUp(object sender, KeyEventArgs e)
        {
            // 관전자 일경우 키처리 X
            if (IsStart && UserCharacter != null)
            {
                // 메시지 생성기 생성
                MessageGenerator generator = new MessageGenerator(Protocols.C_KEY_INPUT);

                byte downKey;
                switch (e.KeyData)
                {
                    case Keys.Left:
                        downKey = Keyboard.LEFT;
                        break;
                    case Keys.Right:
                        downKey = Keyboard.RIGHT;
                        break;
                    case Keys.Up:
                        downKey = Keyboard.UP;
                        break;
                    case Keys.Down:
                        downKey = Keyboard.DOWN;
                        break;
                    default:
                        return;
                }

                if (UserCharacter.Keys[downKey] == true)
                {
                    UserCharacter.Keys[downKey] = false;
                    generator.AddByte(downKey);
                    generator.AddBool(false);

                    // 떼진 키를 서버에 알려줌
                    GameManager.SendMessage(generator.Generate());
                }
            }
            
        }

        // 폼의 포커스가 풀리면 ( 알트 탭, 다른 윈도우 선택시 ) 이벤트 발생
        private void Form_Deactivate(object sender, EventArgs e)
        {
            if (UserCharacter != null)
            {
                MessageGenerator generator = new MessageGenerator(Protocols.C_KEY_INPUT);
                // 입력중인 키 모두 해제
                for(byte i = 0; i < UserCharacter.Keys.Length; i++)
                {
                    UserCharacter.Keys[i] = false;
                    generator.AddByte(i);
                    generator.AddBool(false);

                    // 서버에 전송
                    GameManager.SendMessage(generator.Generate());
                    generator.Clear();
                }
            }
        }


        #endregion Input Process
    }
}
