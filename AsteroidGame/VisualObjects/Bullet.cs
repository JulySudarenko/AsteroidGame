using System.Drawing;


namespace AsteroidGame.VisualObjects
{
    internal class Bullet : CollisionObject
    {
        private static readonly Image _Bullet1 = Image.FromFile("..\\..\\src\\Bullet1.png");
        private const int __BulletSizeX = 30;
        private const int __BulletSizeY = 10;
        private const int __BulletSpeed = 15;

        public Bullet(int Position)
            : base(new Point(45, Position), Point.Empty, new Size(__BulletSizeX, __BulletSizeY))
        {
        }

        public override void Draw(Graphics g)
        {
            var rect = new Rectangle(_Position, _Size);
            g.DrawImage(_Bullet1, rect);
            //g.FillEllipse(Brushes.Red, rect);
            //g.DrawEllipse(Pens.White, rect);
        }

        public override void Update()
        {
            _Position = new Point(_Position.X + __BulletSpeed, _Position.Y);
        }
    }
}
