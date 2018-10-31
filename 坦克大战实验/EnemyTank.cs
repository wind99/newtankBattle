using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class EnemyTank:TankFather
    {
        private static Image[] imgs1 = { Resources.enemy1U, Resources.enemy1D, Resources.enemy1L, Resources.enemy1R };
        private static Image[] imgs2 = { Resources.enemy2U, Resources.enemy2D, Resources.enemy2L, Resources.enemy2R };
        private static Image[] imgs3 = { Resources.enemy3U, Resources.enemy3D, Resources.enemy3L, Resources.enemy3R };

        private static int _speed;
        private static int _life;
        public bool IsStop = true;
        public int stopTime = 0;


        public int EnemyTankType 
        {
            get;set;
        }

        public static int SetSpeed(int type)
        {
            switch(type)
            {
                case 0:
                    _speed = 5;
                    break;
                case 1:
                    _speed = 8;
                    break;
                case 2:
                    _speed = 10;
                    break;
                    
            }
            return _speed;
        }


        public override void Fire()
        {
            SingleObject.GetSingle().AddGameObject(new EnemyZD(this, 15, 10, 1));
        }

        public static int SetLife(int type)
        {
            switch (type)
            {
                case 0:
                    _life = 2;
                    break;
                case 1:
                    _life = 3;
                    break;
                case 2:
                    _life = 4;
                    break;
                    
            }
            return _life;
        }

        public EnemyTank(int x,int y,int type,Direction dir):base(x,y,imgs1,SetSpeed(type),SetLife(type),dir)
        {
            this.EnemyTankType = type;
            Born();
        }

        public override void Draw(Graphics g)
        {
            bornTime++;
            if (bornTime % 20 == 0)
            {
                isMove = true;
            }
            if (isMove)
            {
                if (IsStop)
                {
                    if (r.Next(0, 100) < 2)
                        Fire();
                    Move();
                }
                else
                {
                    stopTime++;
                    if (stopTime % 50 == 0)
                        IsStop = true;
                }
                switch (EnemyTankType)
                {
                    case 0:
                        switch (this.dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs1[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs1[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs1[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs1[3], this.X, this.Y);
                                break;
                        }

                        break;
                    case 1:
                        switch (this.dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs2[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs2[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs2[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs2[3], this.X, this.Y);
                                break;
                        }
                        break;
                    case 2:
                        switch (this.dir)
                        {
                            case Direction.Up:
                                g.DrawImage(imgs3[0], this.X, this.Y);
                                break;
                            case Direction.Down:
                                g.DrawImage(imgs3[1], this.X, this.Y);
                                break;
                            case Direction.Left:
                                g.DrawImage(imgs3[2], this.X, this.Y);
                                break;
                            case Direction.Right:
                                g.DrawImage(imgs3[3], this.X, this.Y);
                                break;
                        }
                        break;
                }
            }
        }

        static Random r = new Random();

        public override void Move()
        {
            base.Move();
            if(r.Next(0,100)<5)
            switch(r.Next(4))
            {
                case 0:
                    this.dir = Direction.Up;
                    break;
                case 1:
                    this.dir = Direction.Down;
                    break;
                case 2:
                    this.dir = Direction.Left;
                    break;
                case 3:
                    this.dir = Direction.Right;
                    break;
            }
           
        }

        public override void IsOver()
        {
            if (this.life <= 0)
            {
                SingleObject.GetSingle().AddGameObject(new Boom(this.X - 25, this.Y - 25));
                SingleObject.GetSingle().RemoveGameObject(this);
                SoundPlayer sp = new SoundPlayer(Resources.fire);
                sp.Play();

                if(r.Next(0,100)>=55)
                {
                    SingleObject.GetSingle().AddGameObject(new EnemyTank(r.Next(0, 700), r.Next(0, 600), r.Next(0, 3), Direction.Down));
                }
                if (r.Next(0, 100) >= 70)
                {
                    SingleObject.GetSingle().AddGameObject(new Basement(this.X,this.Y,r.Next(0,3)));
                }


            }
            else
            {
                SoundPlayer sp = new SoundPlayer(Resources.hit);
                sp.Play();
            }
        }

        public override void Born()
        {
            SingleObject.GetSingle().AddGameObject(new TankBorn(this.X, this.Y));
        }

        
    }
}
