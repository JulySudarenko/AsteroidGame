using System;
using System.Drawing;

namespace AsteroidGame.VisualObjects
{
    class Star : VisualObject
    {
        private static readonly Image Star1 = Image.FromFile("..\\..\\src\\Star1.png");
        private static readonly Image Star2 = Image.FromFile("..\\..\\src\\Star2.png");
        private static readonly Image Star3 = Image.FromFile("..\\..\\src\\Star3.png");
        private static readonly Image Star4 = Image.FromFile("..\\..\\src\\Star4.png");

        private Random _Random = new Random();
        //Image[] _Images = new[](Star1, Star2, Star3, Star4);

        public Star(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size)
        {

        }

        public override void Draw(Graphics g)
        {
            //g.RotateTransform(90);
            g.DrawImage(
                Star3,
                _Position.X, _Position.Y,
                _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            if ((_Position.X < 0) || (_Position.X > Game.Width))
            {
                _Position.X = _Random.Next(Game.Width - 50, Game.Width);
                _Position.Y = _Random.Next(_Random.Next(0, Game.Height));
            }
            //_Position.X += _Direction.X;
            //if (_Position.X < 0)
            //    _Position.X = Game.Width + _Size.Width;
        }
    }
}
