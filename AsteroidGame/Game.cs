﻿using System;
using System.Windows.Forms;
using System.Drawing;
using System.Collections.Generic;
using AsteroidGame.VisualObjects;
using AsteroidGame.GameLoggers;
using System.Linq;


//July_Sudarenko
namespace AsteroidGame
{
    internal delegate void Log(int count);

    //internal delegate void Logs(Log, int count);

    /// <summary>Класс игровой логики</summary>
    internal static class Game
    {
        /// <summary>Интервал времени таймера формирования кадра игры</summary>
        private const int __TimerInterval = 100;

        private static BufferedGraphicsContext __Context;
        private static BufferedGraphics __Buffer;

        private const int _ObjectSize = 25;
        private const int _ObjectMaxSpeed = 20;
        //private static VisualObject[] __GameObjects;
        private static readonly List<Bullet> __Bullets = new List<Bullet>();
        private static int _AsteroidCount = 10;
        private const int _PowerAidCount = 3;
        private const int _StarCount = 3;
        private static readonly List<PowerAid> __PowerAids = new List<PowerAid>();
        private static readonly List<Asteroid> __Asteroids = new List<Asteroid>();
        private static readonly List<Star> __Stars = new List<Star>();
        //private static Bullet __Bullet;
        //private const int _SpaceShipSize = 50;
        private static SpaceShip __SpaceShip;

        private static Timer __Timer;

        /// <summary> Task 4 Lesson 3 Добавить подсчет очков за сбитые астероиды./// </summary>
        private static int _Counter = 0;

        private static Random _Random = new Random();

        private static GameLogger __GameLog = new GameLogger();
        private static GameLogger __GameLogFile = new TextFileGameLog("game.log");

        //private static Log _LogStart = new Log(__GameLog.LogGameStart);

        /// <summary>Ширина игрового поля</summary>
        public static int Width { get; private set; }

        /// <summary>Высота игрового поля</summary>
        public static int Height { get; private set; }

        private static readonly TextureBrush _Texture1 = new TextureBrush(Image.FromFile("..\\..\\src\\Space1.jpg"));

        /// <summary>Task 4 Lesson 2
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

            __GameLog.LogGameStart(_Counter);
            __GameLogFile.LogGameStart(_Counter);
            __GameLog.Flush();
            __GameLogFile.Flush();

            __Timer = new Timer { Interval = __TimerInterval };
            __Timer.Tick += OnTimerTick;
            __Timer.Start();

            form.KeyDown += OnFormKeyDown;

            if (Width >= 1000 || Width < 0)
                throw new ArgumentOutOfRangeException("Ширина экрана должна быть не меньше 0 и не больше 1000");
            if (Height >= 1000 || Height < 0)
                throw new ArgumentOutOfRangeException("Высота экрана должна быть не меньше 0 и не больше 1000");
        }

        private static void OnFormKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.ControlKey:
                    __Bullets.Add(new Bullet(__SpaceShip.Rect.Y + _ObjectSize - 4));
                    //__Bullet = new Bullet(__SpaceShip.Rect.Y + _SpaceShipSize / 2 - 4);
                    break;

                case Keys.Up:
                    __SpaceShip.MoveUp();
                    break;

                case Keys.Down:
                    __SpaceShip.MoveDown();
                    break;
            }
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
            g.DrawString($"{_Counter}", new Font(FontFamily.GenericSerif, 20, FontStyle.Bold), Brushes.LightBlue, 10, 10);
            //g.DrawString()
            //g.DrawString($"Game over!!!\nResult\n{_Counter} points", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 100, 100);

            #region old code
            //g.DrawRectangle(Pens.White, new Rectangle(50, 50, 200, 200));
            //g.FillEllipse(Brushes.Red, new Rectangle(100, 50, 70, 120));
            //foreach (var game_object in __GameObjects)
            //    game_object.Draw(g);
            //if (__Bullet != null)
            //    __Bullet.Draw(g);
            //__Bullet?.Draw(g);
            //__PowerAid.Draw(g);
            #endregion

            __SpaceShip.Draw(g);
            __Bullets.ForEach(bullet => bullet.Draw(g));
            __PowerAids.ForEach(poweraid => poweraid.Draw(g));
            __Asteroids.ForEach(asteroid => asteroid.Draw(g));
            __Stars.ForEach(star => star.Draw(g));

            if (!__Timer.Enabled) return;
            __Buffer.Render();
        }

        public static void Load()
        {

            #region old code
            //    List<VisualObject> game_objects = new List<VisualObject>();

            //    //for (var i = 0; i < 30; i++)
            //    //{
            //    //    game_objects.Add(new Asteroid(
            //    //        new Point(600, i * 20),
            //    //        new Point(15 - i, 20 - i),
            //    //        30));
            //    //}

            //    for (var i = 0; i < 12; i++)
            //    {
            //        game_objects.Add(new Star(
            //            //new Point(300, (int)(i * 50)),
            //    new Point(rnd.Next(60, Width), rnd.Next(0, Height)),
            //            new Point(-i, 0),
            //            new Size(40, 30)));
            //}

            //const int asteroid_count = 10;
            //    //const int asteroid_size = 25;
            //    //const int asteroid_max_speed = 20;

            //    for (var i = 0; i < asteroid_count; i++)
            //        game_objects.Add(new Asteroid(
            //            new Point(rnd.Next(60, Width), rnd.Next(0, Height)),
            //            new Point(-rnd.Next(0, _ObjectMaxSpeed), 0),
            //            _ObjectSize));

            //    //game_objects.Add(
            //    //    new Asteroid(new Point(Width / 2, 200),
            //    //    new Point(-asteroid_max_speed, 0),
            //    //    asteroid_size));

            //    //__Bullet = new Bullet(200);

            //    __PowerAid = new PowerAid(
            //        new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
            //        new Point(-rnd.Next(0, _ObjectMaxSpeed), 10),
            //        _ObjectSize);

            //    __GameObjects = game_objects.ToArray();
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
            #endregion

            for (int a = 0; a < _AsteroidCount; a++)
                __Asteroids.Add(new Asteroid(
                    new Point(_Random.Next(60, Width), _Random.Next(0, Height - _ObjectSize)),
                    new Point(-_Random.Next(1, _ObjectMaxSpeed), 0),
                    _Random.Next(_ObjectSize - 5, _ObjectSize + 10)));

            for (int s = 0; s < _StarCount; s++)
                __Stars.Add(new Star(
                    new Point(_Random.Next(60, Width), _Random.Next(0, Height - _ObjectSize)),
                    new Point(-_Random.Next(1, _ObjectMaxSpeed), 0),
                    new Size(_ObjectSize, _ObjectSize)));

            for (int p = 0; p < _PowerAidCount; p++)
                __PowerAids.Add(new PowerAid(
                    new Point(_Random.Next(0, Width), _Random.Next(0, Height - _ObjectSize)),
                    new Point(-_Random.Next(1, _ObjectMaxSpeed), 0),
                    _ObjectSize));

            //__Asteroids.ToArray();
            //__Stars.ToArray();//может сразу сделать массив?
            //__PowerAids.ToArray();

            __SpaceShip = new SpaceShip(
                new Point(20, 400),
                new Point(10, 10),
                _ObjectSize * 2);
            __SpaceShip.Destroyed += OnShipDestroyed;
        }

        private static void OnShipDestroyed(object sender, EventArgs e)
        {
            __Timer.Stop();

            __GameLog.LogGameOver(_Counter);
            __GameLogFile.LogGameOver(_Counter);
            __GameLog.Flush();
            __GameLogFile.Flush();

            var g = __Buffer.Graphics;
            g.Clear(Color.DarkBlue);
            g.DrawString($"Game over!!!\nResult\n{_Counter} points", new Font(FontFamily.GenericSerif, 60, FontStyle.Bold), Brushes.Red, 100, 100);
            __Buffer.Render();
        }

        /// <summary> Task 3 Lesson 2
        /// Сделать так, чтобы при столкновениях пули с астероидом 
        /// они регенерировались в разных концах экрана.
        /// </summary>
        public static void Update()
        {
            #region old code

            //foreach (var game_object in __GameObjects)
            //    game_object.Update();
            //__Bullet?.Update();
            //__PowerAid.Update();
            ////if (__Bullet is null || __Bullet.Rect.Left > Width)
            ////if (__Bullet.Rect.Left > Width)
            ////{
            ////    var rnd = new Random();
            ////    __Bullet = new Bullet(rnd.Next(0, Height));
            ////}

            //for (var i = 0; i < __GameObjects.Length; i++)
            //{
            //    var obj = __GameObjects[i];
            //    if (obj is ICollision)
            //    {
            //        var collision_object = (ICollision)obj;

            //        if (__SpaceShip.CheckCollision(collision_object))
            //        {
            //            __GameLog.LogEnergyDown(_Counter);
            //            __GameLogFile.LogEnergyDown(_Counter);
            //            __GameLog.Flush();
            //            __GameLogFile.Flush();
            //        }

            //        if (__PowerAid.CheckCollision(collision_object))
            //        {
            //            __GameLog.LogEnergyUp(_Counter);
            //            __GameLogFile.LogEnergyUp(_Counter);
            //            __GameLog.Flush();
            //            __GameLogFile.Flush();


            //            var rnd = new Random();
            //            __PowerAid = new PowerAid(
            //                new Point(rnd.Next(0, Width), rnd.Next(0, Height)),
            //                new Point(-rnd.Next(0, _ObjectMaxSpeed), 10),
            //                _ObjectSize);
            //        }

            //        if (__Bullet != null)
            //        {
            //            if (__Bullet.CheckCollision(collision_object))
            //            {
            //                _Counter++;
            //                __GameLog.LogAsteroidShotDown(_Counter);
            //                __GameLogFile.LogAsteroidShotDown(_Counter);
            //                __GameLog.Flush();
            //                __GameLogFile.Flush();

            //                __GameObjects[i] = null;
            //                __Bullet = null;

            //                var rnd = new Random();
            //                ////__Bullet = new Bullet(rnd.Next(0, Height));

            //                ////const int asteroid_size = 40;
            //                ////const int asteroid_max_speed = 20;
            //                __GameObjects[i] = new Asteroid(
            //                    // поскольку пуля всегда летит слева на право, астероид будет перенесен вправо.
            //                    new Point(rnd.Next(Width - 50, Width), rnd.Next(0, Height)),
            //                    new Point(-rnd.Next(0, _ObjectMaxSpeed), 0),
            //                    _ObjectSize + 15);//будет отличаться размером
            //                System.Media.SystemSounds.Beep.Play();
            //            }
            //        }
            //    }
            //}
            #endregion
            __SpaceShip?.Update();
            __Bullets?.ForEach(bullet => bullet.Update());
            __PowerAids?.ForEach(poweraid => poweraid.Update());
            __Asteroids?.ForEach(asteroid => asteroid.Update());
            __Stars?.ForEach(star => star.Update());

            foreach (var bullet_to_remove in __Bullets.Where(b => b.Rect.Left > Width).ToArray())
                __Bullets.Remove(bullet_to_remove);

            for (int i = 0; i < __Asteroids.Count; i++)
            {
                var obj = __Asteroids[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;

                    if (__SpaceShip.CheckCollision(collision_object))
                    {
                        __GameLog.LogEnergyDown(_Counter);
                        __GameLogFile.LogEnergyDown(_Counter);
                        __GameLog.Flush();
                        __GameLogFile.Flush();

                        if (i < __Asteroids.Count)
                            __Asteroids.Remove(__Asteroids[i]);
                    }

                    foreach (var bullet in __Bullets.ToArray())
                        if (bullet.CheckCollision(collision_object))
                        {
                            _Counter++;

                            __Bullets.Remove(bullet);
                            if (i < __Asteroids.Count)
                                __Asteroids.Remove(__Asteroids[i]);
                            System.Media.SystemSounds.Beep.Play();

                            __GameLog.LogAsteroidShotDown(_Counter);
                            __GameLogFile.LogAsteroidShotDown(_Counter);
                            __GameLog.Flush();
                            __GameLogFile.Flush();
                        }
                }
            }

            for (int i = 0; i < __PowerAids.Count; i++)
            {
                var obj = __PowerAids[i];
                if (obj is ICollision)
                {
                    var collision_object = (ICollision)obj;

                    if (__SpaceShip.CheckCollision(collision_object))
                    {
                        __GameLog.LogEnergyUp(_Counter);
                        __GameLogFile.LogEnergyUp(_Counter);
                        __GameLog.Flush();
                        __GameLogFile.Flush();

                        __PowerAids.Remove(__PowerAids[i]);
                        System.Media.SystemSounds.Beep.Play();

                        __PowerAids.Add(new PowerAid(
                            new Point(_Random.Next(0, Width), _Random.Next(0, Height - _ObjectSize)),
                            new Point(-_Random.Next(1, _ObjectMaxSpeed), 10),
                            _ObjectSize));
                        System.Media.SystemSounds.Beep.Play();
                    }
                }
            }

            if (__Asteroids.Count == 0)
            {
                _AsteroidCount++;
                for (int a = 0; a < _AsteroidCount; a++)
                    __Asteroids.Add(new Asteroid(
                        new Point(_Random.Next(Width - 70, Width), _Random.Next(0, Height - _ObjectSize)),
                        new Point(-_Random.Next(1, _ObjectMaxSpeed), 0),
                        _Random.Next(_ObjectSize - 5, _ObjectSize + 10)));
            }
        }
    }
}
