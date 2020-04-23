using System;
using System.Windows.Forms;
using System.Drawing;

namespace AsteroidGame
{
    internal static class Game
    {
        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;
        private static VisualObject[] __GameObjects;
        public static int Width { get; set; }
        public static int Height { get; set; }
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = 50 };
            timer.Tick += OnTimerTick;
            timer.Start();
        }

        private static void OnTimerTick(object sender, EventArgs e)
        {
            Update();
            Draw();
        }

        public static void Draw()
        {
            Graphics g = __Buffer.Graphics;

            Image Space1 = Image.FromFile("..\\Images\\OuterSpace2.jpg");

            g.Clear(Color.Black);//очистить экран
            TextureBrush texture1 = new TextureBrush(Space1);
            
            g.FillRectangle(texture1,
            new RectangleF(0, 0, 800, 600));
            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var game_object in __GameObjects)
                game_object.Draw(g);

            __Buffer.Render();//перенос изображения на экран
        }

        public static void Load()
        {
            __GameObjects = new VisualObject[30];
            for (int i = 0; i < __GameObjects.Length / 2; i++)
            {
                __GameObjects[i] = new VisualObject(
                    new Point(600, i * 20),
                    new Point(15 - i, 20 - i),
                    new Size(20, 20));
            }

            for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            {
                __GameObjects[i] = new Star(
                    new Point(600, i * 20),
                    new Point(- i, 0),
                    new Size(20, 20));
            }
        }

        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();
        }
    }
}
