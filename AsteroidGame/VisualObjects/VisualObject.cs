using System.Drawing;

//July Sudarenko
namespace AsteroidGame.VisualObjects
{
    internal abstract class VisualObject
    {
        protected Point _Position;
        protected Point _Direction;
        protected Size _Size;

        protected VisualObject(Point Position, Point Direction, Size Size)
        {
            _Position = Position;
            _Direction = Direction;
            _Size = Size;
        }

        public abstract void Draw(Graphics g);
        #region         
        //{
        //g.DrawEllipse(
        //    Pens.White,
        //    _Position.X, _Position.Y,
        //    _Size.Width, _Size.Height
        //    );

        //Image Asteroid1 = Image.FromFile("..\\Images\\Ast1.png");
        //g.DrawImage(
        //    Asteroid1,
        //    _Position.X, _Position.Y,
        //    _Size.Width, _Size.Height);
        //}
        #endregion

        /// <summary> Task 2
        /// Переделать виртуальный метод Update в BaseObject в абстрактный 
        /// и реализовать его в наследниках.
        /// </summary>
        public abstract void Update();
        #region virtual
        //{
        //    _Position.X += _Direction.X;
        //    _Position.Y += _Direction.Y;

        //    if ((_Position.X < 0) || (_Position.X > Game.Width))
        //        _Direction.X *= -1;
        //    if ((_Position.Y < 0) || (_Position.Y > Game.Height))
        //        _Direction.Y *= -1;
        //}
        #endregion
    }
}
