
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class Wall:GameObject
    {
        private static Image img = Resources.wall;

        public Wall(int x,int y):base(x,y,img.Width,img.Height)
        { }

        public override void Draw(Graphics g)
        {
            g.DrawImage(img, this.X, this.Y);
        }
    }
}