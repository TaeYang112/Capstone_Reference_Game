using Capstone_Reference_Game.Object;
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
    public partial class MultipleQuizForm : QuizBaseForm
    {
        private Question[] questions = new Question[1];

        public MultipleQuizForm(bool isSpectator) : base(isSpectator)
        {
            InitializeComponent();
        }

        public MultipleQuizForm() : base(false)
        {
        }

        // 몇번 답을 골랐는지 반환
        public override int GetAnswer()
        {
            // 관전자 모드일경우 -2 반환
            if (Spectator)
                return -2;

            // 캐릭터 중앙 좌표
            Point point = new Point(userCharacter!.Location.X + userCharacter.Size.Width / 2,userCharacter!.Location.Y + userCharacter.Size.Height / 2);

            for(int i = 0; i<questions.Length; i++)
            {
                Rectangle rect = new Rectangle(questions[i].Location, questions[i].Size);

                // 만약 질문 사각형 내에 캐릭터가 존재하면
                if(rect.Contains(point))
                {
                    return i + 1;
                }
            }
            
            return -1;
        }

        // 자신이 고른 정답 표시
        protected override string GetAnswerString()
        {
            int answerInt = GetAnswer();
            if (answerInt == -1) return "정답을 골라주세요!";
            else if(answerInt == -2) return "";

            return questions[answerInt - 1].Text;
        }

        // 문제 ( 1번, 2번...) 생성
        public void SetQuestions(List<string> context)
        {
            // 최대 5개까지 가능
            int count = Math.Min(context.Count,5);

            // 초기화
            questions = new Question[count];

            // 문제의 개수가 짝수일 때 정사각형으로 배치
            if(count % 2 == 0)
            {
                if(count == 2)
                {
                    // 한 변의 길이
                    int sideDist = 300;

                    // 중앙으로 부터 떨어진 거리
                    int distFromCenter = 80;

                    // y좌표
                    int y = 480 / 2 - sideDist / 2 + 120;

                    for (int i = 0; i < 2; i++)
                    {
                        int sign = ((i % 2) == 0 ? -1 : 1);
                        int x = 512 + ( (i + 1) % 2 * sideDist + distFromCenter ) * sign;

                        questions[i] = new Question(new Point(x, y), new Size(sideDist, sideDist));
                        questions[i].Text = context[i];
                    }
                }
                else
                {
                    // 한 변의 길이
                    int sideDist = 190;

                    // 중앙 좌표
                    Point center = new Point(512, 360);

                    // 중앙으로 부터 떨어진 거리
                    int distFromCenter = 20;

                    for (int i = 0; i < 4; i++)
                    {
                        int y, x;
                        if(i < 2) y = center.Y - distFromCenter - sideDist;
                        else y = center.Y + distFromCenter;

                        if(i % 2 == 1) x = center.X - distFromCenter - sideDist;
                        else x = center.X + distFromCenter;

                        questions[i] = new Question(new Point(x, y), new Size(sideDist, sideDist));
                        questions[i].Text = context[i];
                    }
                }
            }
            // 홀수일 때 긴 직사각형으로 배치
            else
            {
                // 각 문제사이의 간격
                int interval = (480 - 80 * count) / (count + 1);

                int nextY = 120 + interval;
                Size tmp_Size = new Size(800, 80);

                for (int i = 0; i < count; i++)
                {
                    Question question = new Question(new Point(112, nextY), tmp_Size);
                    question.Text = context[i];

                    nextY += 80 + interval;
                    questions[i] = question;
                }
            }
        }


        // 화면 출력
        protected override void OnPaint(object? sender, PaintEventArgs e)
        {
            foreach (var item in questions)
            {
                item.Draw(e.Graphics);
            }
            
            base.OnPaint(sender, e);
        }

        

    }
}
