using Capstone_Reference_Game.Client;
using Capstone_Reference_Game.Form;
using System.Collections.Concurrent;

namespace Capstone_Reference_Game
{
    // 가로 1024  /  세로 600
    public partial class OXQuiz : QuizBase
    {
        public OXQuiz(ClientCharacter? user, ConcurrentDictionary<int, ClientCharacter> clients) : base(user,clients)
        {
            InitializeComponent();
        }


        // 몇번 답을 골랐는지 반환
        public override int GetAnswer()
        {
            // 관전자 일경우 -2 반환
            if(userCharacter == null)
            {
                return -2;
            }

            // 캐릭터 중앙 x좌표
            int Character_X = userCharacter!.Location.X + userCharacter.Size.Width / 2;

            // 만약 캐릭터가 화면의 절반보다 왼쪽에 있으면 1번( O ) 아니면 2번( X ) 가운데 라인은 -1을 보냄
            if (Character_X < ClientRectangle.Width / 2 - 15)
            {
                return 1;
            }
            else if (Character_X < ClientRectangle.Width / 2 + 15)
            {
                return -1;
            }
            else
            {
                return 2;
            }
        }

        // 자신이 고른 정답 표시
        protected override string GetAnswerString()
        {
            string answer = string.Empty;
            switch(GetAnswer())
            {
                case 1:
                    answer = "O";
                    break;
                case 2:
                    answer = "X";
                    break;
                case -1:
                    answer = "정답을 골라주세요!";
                    break;
                default:
                    answer = "";
                    break;
            }
            return answer;
        }


    }
}
