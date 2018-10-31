using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 坦克大战实验.Properties;


namespace 坦克大战实验
{
    class PlayerTank : TankFather
    {
        private static Image[] imgs = { Resources.p1tankU, Resources.p1tankD, Resources.p1tankL, Resources.p1tankR };

        public PlayerTank(int x, int y, int speed, int life, Direction dir) : base(x, y, imgs, speed, life, dir)
        {
            Born();
        }

        public int ZDLeval { get; set; }
        public void KeyDown(KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    this.dir = Direction.Up;
                    base.Move();
                    break;
                case Keys.S:
                    this.dir =Direction.Down;
                    base.Move();
                    break;
                case Keys.A:
                    this.dir = Direction.Left;
                    base.Move();
                    break;
                case Keys.D:
                    this.dir = Direction.Right;
                    base.Move();
                    break;
                case Keys.K:
                    Fire();
                    break;
            }
        }

        public override void Fire()
        {
            switch (ZDLeval)
            {
                case 0:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 15, 10, 1));
                    break;
                case 1:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 25, 10, 1));
                    break;
                case 2:
                    SingleObject.GetSingle().AddGameObject(new PlayerZD(this, 35, 10, 1));
                    break;
            }
        }

        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }
        public override void IsOver()
        {
            SoundPlayer sp = new SoundPlayer(Resources.hit);
            sp.Play();
            SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
        }
    }
}