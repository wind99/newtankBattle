using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 坦克大战实验
{
   
    enum Direction {Up,Down,Right,Left }
   abstract class GameObject
    { 
        #region 父类属性
        public int X { get; set; }
        public int Y { get; set; }
        public  int life { get; set; }
        public  int width { get; set; }
        public  int height { get; set; }
        public int speed { get; set; }
        public  Direction dir { get; set; }
        #endregion

        public GameObject(int x,int y,int width,int height,int speed,int life,Direction dir)
        {
            this.X = x;
            this.Y = y;
            this.life = life;
            this.height = height;
            this.width = width;
            this.dir = dir;
            this.speed = speed;
        }

        public GameObject(int x,int y) : this(x, y, 0, 0, 0, 0, 0) { }
       
        public GameObject(int x,int y,int width,int height) : this(x, y, width, height, 0, 0,0) { }
        public abstract void Draw(Graphics g);
        public virtual void Move()
        {
            switch(this.dir)
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
                this.X = 0;
            if (this.Y <= 0)
                this.Y = 0;
            if (this.X >= 680)
                this.X = 680 ;
            if (this.Y >=615)
                this.Y = 615;

        }
        public Rectangle GetRectangle()
        {
            return new Rectangle(this.X, this.Y, this. width, this.height);
        }

    }
    
    


}
