using System;
using System.Runtime.Serialization;
using System.Windows.Forms;

//July_Sudarenko
namespace AsteroidGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            Form game_form = new Form();
            //Screen.PrimaryScreen.WorkingArea.Height

            const int game_form_width = 1000;//именованые значения, константы
            const int game_form_height = 600;

            game_form.Width = game_form_width;
            game_form.Height = game_form_height;

            game_form.Show();

            try
            {
                Game.Initialize(game_form);
            }
            catch (ArgumentOutOfRangeException e)
            {
                System.Diagnostics.Debug.WriteLine("ArgumentOutOfRangeException", e);
            }

            Game.Load();
            Game.Draw();

            Application.Run(game_form);

            //System.Threading.Thread.Sleep(10000);
            //Application.Run();
        }
    }
}
