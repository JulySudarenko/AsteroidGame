using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using AsteroidGame.VisualObjects;

//July_Sudarenko
namespace AsteroidGame
{
    /// <summary>Класс игровой логики</summary>
    internal static class Game
    {
        /// <summary>Интервал времени таймера формирования кадра игры</summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private static VisualObject[] __GameObjects;
        private static Bullet __Bullet;
        //private static SpaceShip __SpaceShip;

        /// <summary>Ширина игрового поля</summary>
        public static int Width { get; private set; }

        /// <summary>Высота игрового поля</summary>
        public static int Height { get; private set; }

        private static readonly Image Space1 = Image.FromFile("..\\..\\src\\Space1.jpg");

        /// <summary>Task 4
        /// Сделать проверку на задание размера экрана в классе Game. 
        /// Если высота или ширина (Width, Height) больше 1000 или принимает отрицательное значение, 
        /// выбросить исключение ArgumentOutOfRangeException(). 
        /// Инициализация игровой логики</summary>
        /// <param name="form">Игровая форма</param>
        public static void Initialize(Form form)
        {
            Width = form.Width;
            Height = form.Height;

            __Context = BufferedGraphicsManager.Current;
            Graphics g = form.CreateGraphics();
            __Buffer = __Context.Allocate(g, new Rectangle(0, 0, Width, Height));

            Timer timer = new Timer { Interval = __TimerInterval };
            timer.Tick += OnTimerTick;
            timer.Start();

            if (Width >= 1000 || Width < 0)
                throw new ArgumentOutOfRangeException(nameof(Width), Width, "Ширина экрана должна быть не меньше 0 и не больше 1000");
            if (Height >= 1000 || Height < 0)
                throw new ArgumentOutOfRangeException(nameof(Height), Height, "Высота экрана должна быть не меньше 0 и не больше 1000");

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
            TextureBrush texture1 = new TextureBrush(Space1);

            g.FillRectangle(texture1,
            new RectangleF(0, 0, Width, Height));
            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));

            foreach (var game_object in __GameObjects)
                game_object.Draw(g);

            //if (__Bullet != null)
            //    __Bullet.Draw(g);
            //__Bullet?.Draw(g);
            __Bullet.Draw(g);

            __Buffer.Render();//перенос изображения на экран
        }

        public static void Load()
        {
            List<VisualObject> game_objects = new List<VisualObject>();
            #region
            //for (var i = 0; i < 30; i++)
            //{
            //    game_objects.Add(new Asteroid(
            //        new Point(600, i * 20),
            //        new Point(15 - i, 20 - i),
            //        30));
            //}
            #endregion

            for (var i = 0; i < 12; i++)
            {
                game_objects.Add(new Star(
                    new Point(300, (int)(i * 50)),
                    new Point(-i, 0),
                    new Size(40, 30)));
            }

            var rnd = new Random();

            const int asteroid_count = 10;
            const int asteroid_size = 25;
            const int asteroid_max_speed = 20;

            for (var i = 0; i < asteroid_count; i++)
                game_objects.Add(new Asteroid(
                    new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
                    new Point(-rnd.Next(0, asteroid_max_speed), 0),
                    asteroid_size));

            game_objects.Add(
                new Asteroid(new Point(Width / 2, 200),
                new Point(-asteroid_max_speed, 0),
                asteroid_size));

            __Bullet = new Bullet(200);
            __GameObjects = game_objects.ToArray();

            #region Array VirtualObject
            //__GameObjects = new VisualObject[30];
            //for (int i = 0; i < __GameObjects.Length / 2; i++)
            //{
            //    __GameObjects[i] = new VisualObject(
            //        new Point(600, i * 20),
            //        new Point(15 - i, 20 - i),
            //        new Size(20, 20));
            //}

            //for (int i = __GameObjects.Length / 2; i < __GameObjects.Length; i++)
            //{
            //    __GameObjects[i] = new Star(
            //        new Point(600, i * 20),
            //        new Point(-i, 0),
            //        new Size(20, 20));
            //}
            #endregion
        }

        /// <summary> Task 3
        /// Сделать так, чтобы при столкновениях пули с астероидом 
        /// они регенерировались в разных концах экрана.
        /// </summary>
        public static void Update()
        {
            foreach (var game_object in __GameObjects)
                game_object.Update();

            __Bullet.Update();

            //if (__Bullet is null || __Bullet.Rect.Left > Width)
            if (__Bullet.Rect.Left > Width)
            {
                var rnd = new Random();
                __Bullet = new Bullet(rnd.Next(0, Height));
            }

            for (var i = 0; i < __GameObjects.Length; i++)
            {
                var obj = __GameObjects[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;
                    //if (__Bullet != null)

                    if (__Bullet.CheckCollision(collision_object))
                    {
                        var rnd = new Random();
                        __Bullet = new Bullet(rnd.Next(0, Height));

                        const int asteroid_size = 40;//будет отличаться размером
                        const int asteroid_max_speed = 20;
                        __GameObjects[i] = new Asteroid(
                            // поскольку пуля всегда летит слева на право, астероид будет перенесен вправо.
                            new Point(rnd.Next(Width - 50, Width), rnd.Next(0, Height)),
                            new Point(-rnd.Next(0, asteroid_max_speed), 0),
                            asteroid_size);
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
            }
        }
    }
}
