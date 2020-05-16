using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using AsteroidGame.VisualObjects;

//July_Sudarenko
namespace AsteroidGame
{
    internal class SplashScreen
    {
        /// <summary>Интервал времени таймера формирования кадра игры</summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;

        //private static SpaceShip __SpaceShip;

        /// <summary>Ширина игрового поля</summary>
        public static int Width { get; private set; }

        /// <summary>Высота игрового поля</summary>
        public static int Height { get; private set; }

        private static readonly TextureBrush _Texture1 = new TextureBrush(Image.FromFile("..\\..\\src\\Space1.jpg"));

        public static Button btnGameStart;
        public static Button btnResults;
        public static Button btnExit;

        const int ButtonWidth = 100;
        const int ButtonHeight = 40;

        public void GameStart_Click(object sender, System.EventArgs e)
        {
        }

        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            btnGameStart = new Button();
            btnGameStart.Width = ButtonWidth;
            btnGameStart.Height = ButtonHeight;
            btnGameStart.Top = 20;
            btnGameStart.Left = 20;
            btnGameStart.Text = "Играть";
            btnGameStart.BackColor = Color.AliceBlue;
            //btnGameStart.Click = GameStart_Click();
            //btnGameStart.Visible = true;
            form.Controls.Add(btnGameStart);
            btnResults = new Button();
            btnExit = new Button();

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };
            timer.Tick += OnTimerTick;
            timer.Start();
            //timer.Enabled = false;

            //timer.Interval = 100000;
            //timer.Enabled = true;
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            g.Clear(Color.Black);//очистить экран
            g.FillRectangle(_Texture1, new RectangleF(0, 0, Width, Height));

            foreach (var game_object in __GameObjects)
                game_object.Draw(g);

            __Buffer.Render();//перенос изображения на экран
        }

        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();

            var rnd = new Random();

            for (var i = 0; i < 3; i++)
            {
                game_objects.Add(new Star(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-i, 0),
                    new Size(40, 30)));
            }

            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;

            for (var i = 0; i < asteroid_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), -10),
                    asteroid_size));

            __GameObjects = game_objects.ToArray();

        }
        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();
        }
    }
}
