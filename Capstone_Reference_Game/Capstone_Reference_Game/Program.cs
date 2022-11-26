using Capstone_Reference_Game.Form;

namespace Capstone_Reference_Game
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
            
            
            MultipleQuizForm form = new MultipleQuizForm(false);
            form.SetTitle("2 + 2 X 2�� ����?");
            form.SetQuestions(new List<string> {"6","8","4","1"});
            form.SetTargetTime(30);
            form.StartWithCount(3); // ī��Ʈ �ٿ����� ����
            //form.Start();         // ī��Ʈ �ٿ� ���� ����
            

            /*
            OXQuizForm form = new OXQuizForm(false);
            form.SetTitle("2 + 2 X 2�� ���� 8�̴�.");
            form.SetTargetTime(30);
            form.Start();
            */

            Application.Run(form);
        }
    }
}