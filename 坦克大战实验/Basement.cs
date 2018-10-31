
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class Basement:GameObject
    {
        private static Image imgStar = Resources.star;
        private static Image imgBomb = Resources.bomb;
        private  static Image imgTimer = Resources.timer;


        public int ZBtype { get; set; }
        public Basement(int x,int y,int type):base(x,y,imgStar.Width,imgStar.Height)
        { this.ZBtype = type; }

        public override void Draw(Graphics g)
        {
            switch(ZBtype)
            {
                case 0:
                    g.DrawImage(imgStar, this.X, this.Y);
                    break;

                case 1:
                    g.DrawImage(imgBomb, this.X, this.Y);
                    break;
                case 2:
                    g.DrawImage(imgTimer, this.X, this.Y);
                    break;
            }

        }
    }
}