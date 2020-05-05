using System.Drawing;
using System;

namespace AsteroidGame.VisualObjects
{
    internal class Asteroid : ImageObject, ICollision
    {
        private static readonly Image __Ast1 = Image.FromFile("..\\..\\src\\Ast1.png");

        public int Power { get; set; } = 3;

        public Asteroid(Point Position, Point Direction, int ImageSize)
            //: base(Position, Direction, new Size(ImageSize, ImageSize), __Image)
            : base(Position, Direction, new Size(ImageSize, ImageSize), __Ast1)// Properties.Resources.Ast)
        {
        }

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public bool CheckCollision(ICollision obj) => Rect.IntersectsWith(obj.Rect);

        public override void Update()
        {
            var rnd = new Random();

            _Position.X += _Direction.X;
            if ((_Position.X < 0) || (_Position.X > Game.Width))
            {
                _Position.X = rnd.Next(Game.Width - 50, Game.Width);
                _Position.Y = rnd.Next(rnd.Next(0, Game.Height));
            }

            //_Position.X += _Direction.X;
            //_Position.Y += _Direction.Y;

            //if ((_Position.X < 0) || (_Position.X > Game.Width))
            //    _Direction.X *= -1;
            //if ((_Position.Y < 0) || (_Position.Y > Game.Height))
            //    _Direction.Y *= -1;
        }
    }
}
