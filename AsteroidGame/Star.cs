using System;
using System.Drawing;

namespace AsteroidGame
{
    class Star : VisualObject
    {
        public Star(Point Position, Point Direction, Size Size)
            : base(Position, Direction, Size)
        {

        }

        public override void Draw(Graphics g)
        {
            Image Star1 = Image.FromFile("..\\Images\\Star6.png");
            g.DrawImage(
                Star1,
                _Position.X, _Position.Y,
                _Size.Width, _Size.Height);
        }

        public override void Update()
        {
            _Position.X += _Direction.X;
            if (_Position.X < 0)
                _Position.X = Game.Width + _Size.Width;
        }
    }
}
