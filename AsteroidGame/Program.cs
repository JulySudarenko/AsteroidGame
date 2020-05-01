using System;
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

            Form splashscreen_form = new Form();

            const int splashscreen_form_width = 800;//именованые значения, константы
            const int splashscreen_form_height = 600;

            //Timer timer = new Timer { Interval = 1000 };
            //timer.Enabled = false;

            splashscreen_form.Width = splashscreen_form_width;
            splashscreen_form.Height = splashscreen_form_height;

            splashscreen_form.Show();

            SplashScreen.Initialize(splashscreen_form);
            SplashScreen.Load();
            SplashScreen.Draw();

            //timer.Interval = 10000;
            //timer.Enabled = true;
            //System.Threading.Thread.SpinWait(100000);
            //Application.Run(splashscreen_form); //картинка стала моргать
            //System.Threading.Thread.Sleep(1000); //картинка не двигается
            //splashscreen_form.Close();// проблема rendring...
            //Application.Exit();// проблема rendring...

            Form game_form = new Form();
            //Screen.PrimaryScreen.WorkingArea.Height

            const int game_form_width = 800;//именованые значения, константы
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
                System.Diagnostics.Debug.WriteLine("Возникло исключение ArgumentOutOfRangeException", e);
            }

            Game.Load();
            Game.Draw();

            Application.Run(game_form);

        }
    }
}
