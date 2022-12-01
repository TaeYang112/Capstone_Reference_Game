using Capstone_Reference_Game.Object;
using Capstone_Reference_Game.Other;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Capstone_Reference_Game.Form
{
    /*
    public partial class QuizBase : UserControl
    {
        // 매 프레임마다 Update를 호출시키는 타이머
        private System.Threading.Timer UpdateTimer;

        // 게임 시작 여부
        public bool IsStart { get; private set; }

        // 타이머 프로그레스바
        protected TimerProgress progressBar = new TimerProgress(new Point(0, 0), new Size(1024, 20));

        // 큰 제목 라벨
        private CustomLabel lbl_ProblemTitle = new CustomLabel(new Point(0, 18), new Size(1024, 97));

        // 문제 큰 제목
        private string _title = string.Empty;

        public DescriptiveQuiz()
        {
            InitializeComponent();
        }

        // 비관리 메모리 해제
        protected virtual void CustomDispose(object? sender, EventArgs e)
        {
            UpdateTimer.Dispose();
            lbl_ProblemTitle.Dispose();
            progressBar.Dispose();

        }

        private void QuizForm_Load(object sender, EventArgs e)
        {
            UpdateTimer.Change(0, 15);
        }



        // 게임 시작
        public virtual void Start()
        {
            // 게임이 시작되었거나 카운트가 진행중이면 나감
            if (IsStart)
            {
                return;
            }

            // 큰제목 라벨에 제목넣어줌
            lbl_ProblemTitle.Text = _title;
            lbl_ProblemTitle.Font = new Font(ResourceLibrary.Families[0], 25, FontStyle.Regular);

            IsStart = true;

            // 사용자가 타이머의 시간을 정했을 때만 타이머를 시작함
            if (progressBar.TargetTime > 0)
            {
                progressBar.Start();
            }
        }

        // 몇번 답을 골랐는지 반환
        public virtual string GetAnswer()
        {
            return "";
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
            if (IsStart)
            {
                lbl_ProblemTitle.Text = title;
            }
        }

        #region Graphic

        // 화면 다시그리기
        protected virtual void Update(object? temp)
        {
            Invalidate();
        }


        protected virtual void OnPaint(object? sender, PaintEventArgs e)
        {
            progressBar.Draw(e.Graphics);
            lbl_ProblemTitle.Draw(e.Graphics);
        }

        #endregion
    }
    */
}
