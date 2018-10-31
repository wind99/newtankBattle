
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class Boom:GameObject
    {
        private Image[] imgs =
        {
            Resources.blast1,
            Resources.blast2,
            Resources.blast3,
            Resources.blast4,
            Resources.blast5,
            Resources.blast6,
            Resources.blast7,
            Resources.blast8,
          
        };

        public Boom(int x,int y):base(x,y)
        {

        }
        public override void Draw(Graphics g)
        {
            for (int i = 0; i < imgs.Length; i++)
                g.DrawImage(imgs[i], this.X, this.Y);
            SingleObject.GetSingle().RemoveGameObject(this);
        }



    }
}