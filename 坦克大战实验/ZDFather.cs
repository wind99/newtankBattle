using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;

namespace 坦克大战实验
{
   abstract class ZDFather:GameObject
    {
        private static Image img;

        public Image Img
        {
            get { return img; }
            set { img = value; }
        }

        public int power { get; set; }

        public ZDFather(TankFather tf, int speed, int life,int power, Image img) : base(tf.X + tf.width / 2 - 6, tf.height / 2 - 6 + tf.Y, img.Width,img.Height, speed, life, tf.dir)
        {
            this.Img = img;
            this.power = power;
        }


        public abstract void IsOver();
        public override void Draw(Graphics g)
        {
            switch (this.dir)
            {
                case Direction.Up:
                    this.Y -= this.speed;
                    break;
                case Direction.Down:
                    this.Y += this.speed;
                    break;
                case Direction.Right:
                    this.X += this.speed;
                    break;
                case Direction.Left:
                    this.X -= this.speed;
                    break;


            }
            if (this.X <= 0)
                this.X = -100;
            if (this.Y <= 0)
                this.Y = -100;
            if (this.X >= 800)
                this.X =900;
            if (this.Y >= 800)
                this.Y = 800;
            g.DrawImage(img, this.X, this.Y);
        }

    }
}