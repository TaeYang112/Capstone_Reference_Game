using Capstone_Reference_Game_Module;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone_Reference_GameServer
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            GameConfiguration config = new GameConfiguration()
            {
                Title = "C언어는 객체지향 언어이다.",
                Time = 30,
                Answer = 2,
                QuizType = QuizTypes.OX_QUIZ
            };

            GameConfiguration config2 = new GameConfiguration()
            {
                Title = "다음중 객체지향의 4대 특성으로 올바르지 않은 것은?",
                Time = 100,
                Answer = 2,
                QuizType = QuizTypes.MULTIPLE_QUIZ,
                Questions = new List<string>() { "캡슐화", "구체화", "상속", "다형성" }
            };

            GameConfiguration config3 = new GameConfiguration()
            {
                Title = "객체지향의 5가지 원칙에 대해 서술하시오.",
                Time = 100,
                QuizType = QuizTypes.DESCRIPTIVE_QUIZ
            };

            GameServerForm GameServerForm = new GameServerForm(config2);
            GameServerForm.Start();
            Application.Run(GameServerForm);
        }
    }
}
