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
                Title = "집가고싶어",
                Time = 30,
                Answer = 1,
                QuizType = QuizTypes.OX_QUIZ
            };

            GameConfiguration config2 = new GameConfiguration()
            {
                Title = "집가고싶어",
                Time = 30,
                Answer = 1,
                QuizType = QuizTypes.MULTIPLE_QUIZ,
                Questions = new List<string>() { "11", "22", "33" }
            };
            GameServerForm GameServerForm = new GameServerForm(config2);
            GameServerForm.Start();
            Application.Run(GameServerForm);
        }
    }
}
