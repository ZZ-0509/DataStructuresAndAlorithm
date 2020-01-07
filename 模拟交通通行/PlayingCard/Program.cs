using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 创建一个单副 54 张牌的集合，随机排布显示；
    /// 创建四个待发牌的集合；
    ///程序开始后，以随机函数处理发牌结果，发牌完成后，按照四行从大到小显示到控制台
    /// </summary>
    class Program
    {
      
        static void Main()
        {
            ///向集合添加54张扑克牌，且添加之时就确定好扑克牌的大小，
            ///从大到小依次是（大王，小王，3，2，A，K，Q，J，10，9，8，7，6，5，4）花色从大到小依次为（黑桃,红桃，梅花，方块）
            
            /// 定义一个盒子的集合，并向其中添加一下盒子对象
            var bxList = new BoxCollection();
            //单独添加大王小王两张牌
            bxList.Add(new Box("", "大王", 1));//1 代表最大的一张牌
            bxList.Add(new Box("", "小王", 2));//2 代表第二大的一张牌
            //定义一个装有所有点数的字符串
            string countAll = "32AKQJ10987654";
            //定义一个字符串组装有所有花色
            List<string> Flist = new List<string>();
            Flist.Add("黑桃");
            Flist.Add("红桃");
            Flist.Add("梅花");
            Flist.Add("方块");

          //所以大小这个属性，从3开始添加
            int ra = 3;
            for (int i = 0; i <= 13; i++)
            {
                if (i == 6)
                {
                    string co1 = countAll.Substring(i, 2);//从countAll取出点数（因为10点，是两个字符）
                    for (int i1 = 0; i1 <= 3; i1++)//为同一点数的牌添加四个花色
                    {
                        string fl = Flist[i1];
                        bxList.Add(new Box(fl, co1, ra));
                        ra++;
                    }
                    i++;
                }
                else
                {
                    string co = countAll.Substring(i, 1);//从countAll取出点数
                    for (int i1 = 0; i1 <= 3; i1++)//为同一点数的牌添加四个花色
                    {
                        string fl = Flist[i1];
                        bxList.Add(new Box(fl, co, ra));
                        ra++;
                    }
                }

            }

            ///随机显示54张扑克牌
            ///六张牌为一行

            //调用方法得到一组属于[0,53]的随机数组（数组元素数54个）
            var nlist1 = RandomNumber(0, 53);

            //循环输出54张牌，一行六张牌
            //初始化一个变量，用于for循环时记录一行有几张牌
            int js6 = 0;
            for (int i = 0; i < nlist1.Count; i++)
            {
                var w = bxList[nlist1 [i ]];
                Console.Write("{0}{1}\t", w.Flower, w.Count);
                js6++;
                //一行满了6张牌，就换行，且初始化js6
                if (js6 == 6)
                {
                    Console.WriteLine();
                    js6 = 0;
                }
            }


            ///创建四个集合，即四个玩家
            
            var gatherList1 = new BoxCollection();
            var gatherList2 = new BoxCollection();
            var gatherList3 = new BoxCollection();
            var gatherList4 = new BoxCollection();

            ///将牌随机加到四个集合中
           
            //调用方法得到一组属于[0,53]的随机数组（数组元素数54个）
            var fourList = RandomNumber(0, 53);//此随机数组用于向bxList中随机取出牌
            for (int i=0;i<fourList.Count;i++,i ++,i++,i++)
            {
               
                if (i<=51)
                {
                        gatherList1.Add(bxList[fourList[i]]);
                        gatherList2.Add(bxList[fourList[i+1]]);
                        gatherList3.Add(bxList[fourList[i+2]]);
                        gatherList4.Add(bxList[fourList[i+3]]);   
                }
                //发牌到第53张牌时执行此操作
                else
                {
                    gatherList1.Add(bxList[fourList[i]]);
                    gatherList2.Add(bxList[fourList[i + 1]]);
                }
            }
            Console.WriteLine();
            Console.Write("按下回车开始发牌");
            Console.WriteLine();
            Console.ReadLine();

            ///对四个集合内的元素按大小排序
            var ranklist1 = gatherList1.OrderBy(s => s.Ranking);//借助扑克牌模型的大小属性
            var ranklist2 = gatherList2.OrderBy(s => s.Ranking);//借助扑克牌模型的大小属性
            var ranklist3 = gatherList3.OrderBy(s => s.Ranking);//借助扑克牌模型的大小属性
            var ranklist4 = gatherList4.OrderBy(s => s.Ranking);//借助扑克牌模型的大小属性

            //输出四个集合中的牌
            Console.Write("玩家一：");
            foreach (var w in ranklist1 )
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.Write("玩家二：");
            foreach (var w in ranklist2)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.Write("玩家三：");
            foreach (var w in ranklist3)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }
            Console.ReadLine();
            Console.WriteLine();
            Console.Write("玩家四：");
            foreach (var w in ranklist4)
            {
                Console.Write("{0}{1}\t", w.Flower, w.Count);
            }


          
            Console.ReadKey();


        }



        /// <summary>
        /// 创建一个得到随机数数组的方法(方法参数代表随机数范围）
        /// </summary>
        /// <returns></returns>
        private static List<Int32> RandomNumber(int begin,int end)
        {
            List<Int32> sjList = new List<Int32>();
            for (int i = 0; i < 1000; i++)
            {
                
                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                sjList.Add(random.Next(begin, end+1));
            }
            //去除数组重复值
            List<Int32> nlist = sjList;
            for (int i = 0; i < sjList.Count; i++)
            {

                for (int j = sjList.Count - 1; j > i; j--)
                {
                    if (sjList[i] == nlist[j])
                    {
                        sjList.RemoveAt(j);
                    }
                }

            }
            return sjList;
        }

     
        
    }
}
