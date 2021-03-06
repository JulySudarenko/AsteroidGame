﻿using System;
using System.Drawing;

//July Sudarenko
namespace AsteroidGame.VisualObjects
{
    /// <summary> Task 3 Lesson 3
    /// Разработать аптечки, которые добавляют энергию.
    /// </summary>
    internal class PowerAid : ImageObject, ICollision
    {
        private static readonly Image _PowerAid1 = Image.FromFile("..\\..\\src\\PowerAid3.png");

        public int MakeUpEnergy { get; set; } = 3;

        public PowerAid(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), _PowerAid1)
        {
        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);
        
        public override void Draw(Graphics g)
        {
            g.DrawImage(_PowerAid1, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }
        
        public override void Update()
        {
            var rnd = new Random();

            _Position.X += _Direction.X;
            if ((_Position.X < 0) || (_Position.X > Game.Width))
            {
                _Position.X = rnd.Next(Game.Width - 50, Game.Width);
                _Position.Y = rnd.Next(rnd.Next(0, Game.Height));
            }

        }
    }
}
