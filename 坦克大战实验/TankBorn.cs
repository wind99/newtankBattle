﻿
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class TankBorn:GameObject
    {
        private Image[] imgs =
        {
            Resources.born1,
           Resources.born2,
           Resources.born3,
           Resources.born4,
        };

        public TankBorn(int x,int y) : base(x, y)
        {

        }
        int time = 0;
        public override void Draw(Graphics g)
        {
            time++;
            for (int i = 0; i < imgs.Length; i++)
            {
                switch(time%10)
                {
                    case 1:
                    g.DrawImage(imgs[0], this.X, this.Y);
                        break;
                    case 3:
                        g.DrawImage(imgs[1], this.X, this.Y);
                        break;

                    case 5:
                        g.DrawImage(imgs[2], this.X, this.Y);
                        break;
                    case 7:
                        g.DrawImage(imgs[3], this.X, this.Y);
                        break;
                }
            }
            if(time%15==0)
            SingleObject.GetSingle().RemoveGameObject(this);
        }
    }
}