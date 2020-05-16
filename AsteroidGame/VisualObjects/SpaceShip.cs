using System;
using System.Drawing;

//July Sudarenko
namespace AsteroidGame.VisualObjects
{
    /// <summary> Task 1 Lesson 3
    /// Добавить космический корабль, как описано в уроке.
    /// </summary>
    internal class SpaceShip : ImageObject
    {
        public event EventHandler Destroyed;

        private int _Energy = 20;

        public int Energy => _Energy;

        private static readonly Image __SpaceShip1 = Image.FromFile("..\\..\\src\\SpaceShip1.png");

        public Rectangle Rect => new Rectangle(_Position, _Size);

        public SpaceShip(Point Position, Point Direction, int ImageSize)
            : base(Position, Direction, new Size(ImageSize, ImageSize), __SpaceShip1)
        {
        }

        public override void Draw(Graphics g)
        {
            g.DrawImage(__SpaceShip1, _Position.X, _Position.Y, _Size.Width, _Size.Height);
        }

        public override void Update() 
        {
            _Position.X += _Direction.X;
            _Position.Y += _Direction.Y;

            if ((_Position.X < 0) || (_Position.X > Game.Width))
                _Direction.X *= -1;
            if ((_Position.Y < 0) || (_Position.Y > Game.Height))
                _Direction.Y *= -1;
        }

        public bool CheckCollision(ICollision obj)
        {
            var is_collision = Rect.IntersectsWith(obj.Rect);

            if (is_collision && obj is Asteroid asteroid)
            {
                ChangeEnergy(-asteroid.Power);
            }

            if (is_collision && obj is PowerAid poweraid)
            {
                ChangeEnergy(+poweraid.MakeUpEnergy);
            }

            return is_collision;
        }

        public void ChangeEnergy(int delta)
        {
            _Energy += delta;

            if (_Energy < 0) 
                Destroyed?.Invoke(this, EventArgs.Empty);
        }

        public void MoveUp()
        {
            if (_Position.Y > 0)
                _Position.Y -= _Direction.Y;
        }

        public void MoveDown()
        {
            if (_Position.Y - _Size.Height < Game.Height)
                _Position.Y += _Direction.Y;
        }
    }
}
