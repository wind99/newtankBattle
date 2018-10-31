
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class EnemyZD:ZDFather
    {
        private static Image img = Resources.enemymissile;

        public EnemyZD(TankFather tf, int speed, int life, int power) : base(tf, speed, life, power, img)
        {

        }
        public override void IsOver()
        {
            throw new NotImplementedException();
        }
    }
}