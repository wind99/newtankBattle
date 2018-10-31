
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Text;
using 坦克大战实验.Properties;

namespace 坦克大战实验
{
    class SingleObject
    {
        private SingleObject()
        { }
        public static SingleObject singleObject = null;

        public static SingleObject GetSingle()
        {
            if (singleObject == null)
            {
                singleObject = new SingleObject();
               
            }
            return singleObject;
        }

        public PlayerTank PT { get; set; }

        List<EnemyTank> listEnemyTank = new List<EnemyTank>();
        List<PlayerZD> listPlayerZD = new List<PlayerZD>();
        List<EnemyZD> listEnemyZD = new List<EnemyZD>();
        List<Boom> listBoom = new List<Boom>();
        List<TankBorn> listTankBorn = new List<TankBorn>();
        List<Basement> listBasement = new List<Basement>();
        List<Wall> listWall = new List<Wall>();


        public void AddGameObject(GameObject go)
        {
            if (go is PlayerTank)
            {
                PT = go as PlayerTank;
            }
            else if (go is EnemyTank)
            {
                listEnemyTank.Add(go as EnemyTank);
            }
            else if (go is PlayerZD)
            {

                listPlayerZD.Add(go as PlayerZD);
            }
            else if (go is EnemyZD)
            {

                listEnemyZD.Add(go as EnemyZD);
            }
            else if (go is Boom)
                listBoom.Add(go as Boom);
            else if (go is TankBorn)
                listTankBorn.Add(go as TankBorn);
            else if (go is Basement)
                listBasement.Add(go as Basement);
            else if (go is Wall)
                listWall.Add(go as Wall);

        }
        public void Draw(Graphics g)
        {
            PT.Draw(g);
            for(int i=0;i<listEnemyTank.Count;i++)
            {
                listEnemyTank[i].Draw(g);
            }
            for(int i=0;i<listPlayerZD.Count;i++)
            {
                listPlayerZD[i].Draw(g);
            }
            for (int i = 0; i < listEnemyZD.Count; i++)
                listEnemyZD[i].Draw(g);
            for (int i = 0; i < listBoom.Count; i++)
                listBoom[i].Draw(g);
            for (int i = 0; i < listTankBorn.Count; i++)
                listTankBorn[i].Draw(g);
            for (int i = 0; i < listBasement.Count; i++)
                listBasement[i].Draw(g);
            for (int i = 0; i < listWall.Count; i++)
                listWall[i].Draw(g);

        }

        public void HitMonitor()
        {
            for(int i=0;i<listPlayerZD.Count;i++)
            {
                for(int j=0;j<listEnemyTank.Count;j++)
                {
                    if(listPlayerZD[i].GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    {
                        listEnemyTank[j].life -= listPlayerZD[i].power;
                        listEnemyTank[j].IsOver();
                        listPlayerZD[i].IsOver();
                        break;
                    }
                }
            }

            for(int i = 0; i < listEnemyZD.Count; i++)
            {
                if(listEnemyZD[i].GetRectangle().IntersectsWith(PT.GetRectangle()))
                {
                    PT.IsOver();
                    listEnemyZD.Remove(listEnemyZD[i]);
                    break;
                
                }
            }

            for(int i=0;i<listBasement.Count;i++)
            {
                if(listBasement[i].GetRectangle().IntersectsWith(PT.GetRectangle()))
                {
                    JudgeZB(listBasement[i].ZBtype);
                    listBasement.Remove(listBasement[i]);
                    
                    SoundPlayer sp = new SoundPlayer(Resources.add);

                    sp.Play();
                }
            }
            
            //判断敌人和墙体是否有碰撞
            for(int i=0;i<listWall.Count;i++)
            {
                for(int j=0;j<listEnemyTank.Count;j++)
                {
                    if(listWall[i].GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    {
                        switch(listEnemyTank[j].dir)
                        {
                            case Direction.Up:
                                listEnemyTank[j].Y = listWall[i].Y + listWall[i].height;
                                break;
                            case Direction.Down:
                                listEnemyTank[j].Y = listWall[i].Y - listWall[i].height;
                                break;
                            case Direction.Left:
                                listEnemyTank[j].X = listWall[i].X - listWall[i].width;
                                break;
                            case Direction.Right:
                                listEnemyTank[j].X = listWall[i].X - listWall[i].width;
                                break;

                        }


                    }
                }
            }
           //判断敌人和万家坦克是否有碰撞
            for (int j = 0; j < listEnemyTank.Count; j++)
                {
                    if (PT.GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle()))
                    {
                        switch (listEnemyTank[j].dir)
                        {
                            case Direction.Up:
                                listEnemyTank[j].Y = PT.Y + PT.height;
                                break;
                            case Direction.Down:
                                listEnemyTank[j].Y = PT.Y - PT.height;
                                break;
                            case Direction.Left:
                                listEnemyTank[j].X = PT.X - PT.width;
                                break;
                            case Direction.Right:
                                listEnemyTank[j].X = PT.X - PT.width;
                                break;

                        }


                    }
                }

            //判断敌人和敌人是否有碰撞

            for (int i = 0; i < listEnemyTank.Count; i++)
            {
                for (int j = 0; j < listEnemyTank.Count; j++)
                {
                    if (listEnemyTank[i].GetRectangle().IntersectsWith(listEnemyTank[j].GetRectangle())&&i!=j)
                    {
                        switch (listEnemyTank[j].dir)
                        {
                            case Direction.Up:
                                listEnemyTank[j].Y = listEnemyTank[i].Y + listEnemyTank[i].height;
                                break;
                            case Direction.Down:
                                listEnemyTank[j].Y = listEnemyTank[i].Y - listEnemyTank[i].height;
                                break;
                            case Direction.Left:
                                listEnemyTank[j].X = listEnemyTank[i].X - listEnemyTank[i].width;
                                break;
                            case Direction.Right:
                                listEnemyTank[j].X = listEnemyTank[i].X - listEnemyTank[i].width;
                                break;

                        }


                    }
                }
            }
            //让子弹能够消除墙体
            for (int i=0;i<listPlayerZD.Count;i++)
            {
                for(int j=0;j<listWall.Count;j++)
                {
                    if(listPlayerZD[i].GetRectangle().IntersectsWith(listWall[j].GetRectangle()))
                    {
                        listPlayerZD.Remove(listPlayerZD[i]);
                        listWall.Remove(listWall[j]);
                        break;
                    }


                }
            }

            //让敌人子弹和玩家子弹碰撞的时候消失
            for(int i=0;i<listPlayerZD.Count;i++)
            {
                for(int j=0;j<listEnemyZD.Count;j++)
                {
                    if (listPlayerZD[i].GetRectangle().IntersectsWith(listEnemyZD[j].GetRectangle()))
                    {
                        listEnemyZD.Remove(listEnemyZD[j]);
                        listPlayerZD.Remove(listPlayerZD[i]);
                        break;
                    }
                }
            }
        }

        public void JudgeZB(int type)
        {
            switch(type)
            {
                case 0://星星，让玩家速度变快
                    if (PT.ZDLeval < 2)
                        PT.ZDLeval++;
                    break;
                case 1:
                    for(int i=0;i<listEnemyTank.Count;i++)
                    {
                        listEnemyTank[i].life = 0;
                        listEnemyTank[i].IsOver();
                    }
                    break;
                case 2:
                    for (int i = 0; i < listEnemyTank.Count; i++)
                    {
                        listEnemyTank[i].IsStop =false;
                        
                    }

                    break;
            }
        }

        public void RemoveGameObject(GameObject go)
        {
            if(go is Boom)
            {
                listBoom.Remove(go as Boom);
            }
            if (go is PlayerZD)
            {
                listPlayerZD.Remove(go as PlayerZD);
            }

            if(go is EnemyZD)
            {
                listEnemyZD.Remove(go as EnemyZD);

            }
            if (go is EnemyTank)
                listEnemyTank.Remove(go as EnemyTank);
          
              if(go is TankBorn)
            {
                listTankBorn.Remove(go as TankBorn);
            }

            if (go is Basement)
                listBasement.Remove(go as Basement);
            if (go is Wall)
                listWall.Remove(go as Wall);
        }

    }
}