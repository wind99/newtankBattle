
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class PlayerZD:ZDFather
    {
        private static Image img = Resources.tankmissile;

        public PlayerZD(TankFather tf,int speed,int life,int power):base(tf,speed,life,power,img)
        {

        }
        public override  void IsOver()
        {
            SingleObject.GetSingle().RemoveGameObject(this);
        }

    }
}