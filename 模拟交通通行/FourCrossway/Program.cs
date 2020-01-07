using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FourCrossway
{
    class Prom
    {

        //class Program
        //{
        //    int TimesCalled = 0;
        //    void Display(object state)
        //    {
        //        Console.WriteLine("{0} {1} keep running.", (string)state, ++TimesCalled);
        //    }
        //    static void Main(string[] args)
        //    {
        //        Program p = new Program();
        //        //2秒后第一次调用，每1秒调用一次
        //        System.Threading.Timer myTimer = new System.Threading.Timer(p.Display, "Processing timer event", 2000, 1000);
        //        // 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

        //        Console.WriteLine("Timer started.");
        //        Console.ReadLine();
        //    }
        //}



        static List<Int32> dieList;//掌控车辆下部的骰子
        static List<Int32> dieList2;//掌控车辆上部的骰子
        static List<Int32> dieListy;//掌控车辆右部的骰子
        static List<Int32> dieListz;//掌控车辆左部的骰子
        static Queue laneUp= new Queue();//定义上车道队列
        static Queue laneDown= new Queue();//定义下车道队列
        static Queue laneLeft= new Queue();//定义左车道队列
        static Queue laneRight= new Queue();//定义右车道队列
        Queue qdata = new Queue();
        static DateTime lightState;//记录主干道红绿灯的开始时间
        static DateTime lightStateFu;//记录支干道红绿灯的开始时间
        static DateTime cardDownState;//记录下车道的开始时间
        static DateTime cardUpState;//记录上车道的开始时间
        static DateTime cardRightState;//记录右车道的开始时间
        static DateTime cardLeftState;//记录左车道的开始时间
        static DateTime ZhulvdengxingState;//用于主干道的绿灯行时间

        //static int lightCount;
        static Stack<string> light;
        static Stack<string> nulllight;
        static int  conu = 1;
        static string deng;//主干道红绿灯
        static string dengFu;//支干道红绿灯
        static System.Timers.Timer  t = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于主干道红绿灯的变换
        static System.Timers.Timer tFu = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于支干道红绿灯的变换

        static System.Timers.Timer tc = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于下车道内车辆的变换
        static System.Timers.Timer tcs = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于上车道内车辆的变换
        static System.Timers.Timer tcy = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于右车道内车辆的变换
        static System.Timers.Timer tcz = new System.Timers.Timer(1000);//实例化Timer类，设置间隔时间为10000毫秒；用于左车道内车辆的变换

        static System.Timers.Timer t1 = new System.Timers.Timer(30000);//实例化Timer类，设置间隔时间为10000毫秒；用于红绿灯的变换
        static System.Timers.Timer tsz = new System.Timers.Timer(10000);///实例化Timer类，设置间隔时间为10000毫秒；用于摇骰子
        static System.Timers.Timer tldx = new System.Timers.Timer(4000);///实例化Timer类，设置间隔时间为5000毫秒；用于主干道绿灯行
        static System.Timers.Timer tldxFu = new System.Timers.Timer(4000);///实例化Timer类，设置间隔时间为4000毫秒；用于支干道绿灯行

///四个骰子 下上右左
        static System.Timers.Timer szx = new System.Timers.Timer(10000);///实例化Timer类，设置间隔时间为10000毫秒；用于摇骰子
        static System.Timers.Timer szs = new System.Timers.Timer(10000);///实例化Timer类，设置间隔时间为10000毫秒；用于摇骰子
        static System.Timers.Timer szy = new System.Timers.Timer(10000);///实例化Timer类，设置间隔时间为10000毫秒；用于摇骰子
        static System.Timers.Timer szz = new System.Timers.Timer(10000);///实例化Timer类，设置间隔时间为10000毫秒；用于摇骰子


        /// <summary>
        /// 控制台显示十字路口
        /// </summary>
        /// <param name="args"></param>
        public void Crossroad(object state)
        {
            Console.Clear();
          

            //主干道上部
            for (int i =0;i<12;i ++)
            {
                for (int j=0;j<35;j++)
                {
                   
                    if ((i == 6 && j == 34)|| (i == 10 && j == 34))
                    {
                        if (i == 10 && j ==34 )
                        {
                            Console.Write(deng);
                        }
                        else {
                            Console.Write("主");
                        }
                       
                    }


                    if (j == 29 && i == 1)
                    {
                        foreach (var w in laneUp)
                        {
                            Console.Write(w);

                            if (laneUp.Count > 1)
                            {
                                for (int y = 0; y < 3; y++)
                                {
                                    Console.Write("  ");
                                    if (y == 2)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                Console.WriteLine("");
                                for (int k = 0; k < 33; k++)
                                {
                                    if ((k >= 0 && k <= 25) || (k > 26 && k < 30))
                                    {
                                        Console.Write("  ");
                                    }

                                    if (k == 26)
                                    {
                                        Console.Write("|");

                                    }



                                }
                            }

                        }
                    }







                    else { Console.Write("  "); }
                 
                    if (j == 25||j==32)
                    {
                        Console.Write("|");
                    }
                   
                   
                }
                Console.WriteLine("");
                
            }

            //支干道
            for (int i = 0; i < 6; i++)
            {
                if (i==0||i==4||i==2||i==3)
                {
                   
                  
                        for (int j = 0; j < 50; j++)
                        {

                        if (i==0)
                        {
                            if ((j > 25 && j < 34) || (j < 10)) { Console.Write("  "); }
                            else
                            {
                                Console.Write("—");
                            }
                        }
                        else if (i==2)
                        {
                            
                            
                                if (j < 34) { Console.Write("  "); }
                                if (j == 35)
                                {
                                    foreach (var w in laneRight)
                                    {
                                        Console.Write(w);
                                    }
                                }
                            
                           
                        }
                        else if (i==3)
                        {if (laneLeft.Count > 0)
                            {
                                if (j < 15)
                                {
                                    Console.Write("  ");
                                }
                                if (j==15)
                                {
                                    foreach (var w in laneLeft)
                                    {
                                        Console.Write(w);
                                    }
                                }
                            }

                        }

                        else if (i==4)
                        {

                            if ((j > 25 && j < 34) || (j < 10)) { Console.Write("  "); }
                            else
                            {
                                Console.Write("—");
                            }
                        }
                           



                        }
                    
                    
                }
                if (i == 5)
                {
                    for (int j=0;j<50;j++)
                    {
                        Console.Write("  ");
                        if (j == 15)
                        {
                            Console.Write("支");
                        }
                        else if(j==22)
                            {
                            Console.Write(dengFu);
                        }
                    }
                }
              
                 Console.WriteLine(""); 


            }


            //主干道下部
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 33; j++)
                {
                    if (j == 29&&i==1)
                    {
                        foreach(var w in laneDown)
                        {
                            Console.Write(w);

                            if (laneDown.Count > 1)
                            {
                                for (int y =0;y<3;y++)
                                {
                                    Console.Write("  ");
                                    if (y == 2)
                                    {
                                        Console.Write("|");
                                    }
                                }
                                Console.WriteLine("");
                                for (int k = 0; k < 33; k++)
                                {
                                    if ((k>=0&&k <= 25)||(k>26&&k<30))
                                    {
                                        Console.Write("  ");
                                    }
                                   
                                    if (k == 26)
                                    {
                                        Console.Write("|");

                                    }



                                }
                            }
                         
                        }
                    }
                    else { Console.Write("  "); }  
                  

                    if (j == 25 || j == 32)
                    {
                        Console.Write("|");
                    }


                }
                Console.WriteLine("");

            }
          
           
        }
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="args"></param>
       //public Prom()
       // {
       //     System.Timers.Timer t = new System.Timers.Timer(10000);//实例化Timer类，设置间隔时间为10000毫秒；
       //     t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；
       //     t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
       //     t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
       //     t.Start(); //启动定时器
       //                //上面初始化代码可以写到构造函数中




       //     //System.Timers.Timer t = new System.Timers.Timer();
       //     //t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
       //     //t.Interval = 1000;
       //     //t.Enabled = true;
       // }

        static void Main(string[] args)
        {

            //主干道红绿灯刷新
            deng = "绿";
            t.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);//到达时间的时候执行事件；
            t.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            t.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            t.Start(); //启动定时器
            lightState = DateTime.Now;        //上面初始化代码可以写到构造函数中


            //支干道红绿灯刷新
            dengFu = "红";
            tFu.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEventFu);//到达时间的时候执行事件；
            tFu.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tFu.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tFu.Start(); //启动定时器
            lightStateFu = DateTime.Now;        //上面初始化代码可以写到构造函数中




            ///全局刷新
            Prom p = new Prom();
            //2秒后第一次调用，每1秒调用一次
            System.Threading.Timer myTimer = new System.Threading.Timer(p.Crossroad, "Processing timer event", 0, 1000);
            // 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            //主车道下部车辆刷新
            tc.Elapsed += new System.Timers.ElapsedEventHandler(CardDown);//到达时间的时候执行事件；
            tc.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tc.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tc.Start(); //启动定时器
            cardDownState = DateTime.Now;

            //支车道右部车辆刷新
            tcy.Elapsed += new System.Timers.ElapsedEventHandler(CardRight);//到达时间的时候执行事件；
            tcy.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tcy.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tcy.Start(); //启动定时器
            cardRightState = DateTime.Now;

            //主车道上部刷新
            tcs.Elapsed += new System.Timers.ElapsedEventHandler(CardUp);//到达时间的时候执行事件；
            tcs.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tcs.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tcs.Start(); //启动定时器
            cardUpState = DateTime.Now;

            //支车道左部刷新
            tcz.Elapsed += new System.Timers.ElapsedEventHandler(CardLeft);//到达时间的时候执行事件；
            tcz.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tcz.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tcz.Start(); //启动定时器
            cardLeftState = DateTime.Now;


            //4骰子初始值
             dieList=RandomNumber(2,10);//掌控车辆下部的骰子
         dieList2 = RandomNumber(2, 10);//掌控车辆上部的骰子
            dieListy = RandomNumber(2, 10);//掌控车辆右部的骰子
             dieListz = RandomNumber(2, 10);//掌控车辆左部的骰子



            //骰子下摇
            szx.Elapsed += new System.Timers.ElapsedEventHandler(Die);//到达时间的时候执行事件；
            szx.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            szx.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            szx.Start(); //启动定时器

            //骰子上摇
            szs.Elapsed += new System.Timers.ElapsedEventHandler(Die2);//到达时间的时候执行事件；
            szs.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            szs.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            szs.Start(); //启动定时器

            //骰子右摇
            szy.Elapsed += new System.Timers.ElapsedEventHandler(Diey);//到达时间的时候执行事件；
            szy.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            szy.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            szy.Start(); //启动定时器

            //骰子左摇
            szz.Elapsed += new System.Timers.ElapsedEventHandler(Diey);//到达时间的时候执行事件；
            szz.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            szz.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            szz.Start(); //启动定时器


            ////下部骰子摇
            ////2秒后第一次调用，每1秒调用一次
            //System.Threading.Timer myTimer1 = new System.Threading.Timer(Die, "Processing timer event", 1000, 10000);
            //// 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            ////上部骰子
            ////2秒后第一次调用，每1秒调用一次
            //System.Threading.Timer myTimer2 = new System.Threading.Timer(Die2, "Processing timer event", 1000, 10000);
            //// 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            ////支干道右部车辆的骰子
            ////2秒后第一次调用，每1秒调用一次
            //System.Threading.Timer myTimer3 = new System.Threading.Timer(Diey, "Processing timer event", 1000, 10000);
            //// 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            ////支干道左部车辆的骰子
            ////2秒后第一次调用，每1秒调用一次
            //System.Threading.Timer myTimer4 = new System.Threading.Timer(Diez, "Processing timer event", 1000, 10000);
            //// 第一个参数是：回调方法，表示要定时执行的方法，第二个参数是：回调方法要使用的信息的对象，或者为空引用，第三个参数是：调用 callback 之前延迟的时间量（以毫秒为单位），指定 Timeout.Infinite 以防止计时器开始计时。指定零 (0) 以立即启动计时器。第四个参数是：定时的时间时隔，以毫秒为单位

            //掌控绿灯时下到上的（每5秒刷新一次）
            tldx.Elapsed += new System.Timers.ElapsedEventHandler(lvdengxing);//到达时间的时候执行事件；
            tldx.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tldx.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tldx.Start(); //启动定时器
            //ZhulvdengxingState = DateTime.Now;


            //掌控绿灯时右到左的（每五秒刷新一次）
            tldxFu.Elapsed += new System.Timers.ElapsedEventHandler(lvdengxingFu);//到达时间的时候执行事件；
            tldxFu.AutoReset = true;//设置是执行一次（false）还是一直执行(true)；
            tldxFu.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
            tldxFu.Start(); //启动定时器


            Console.Read();
        }

        /// <summary>
        /// 骰子变换（掌握支干道左部车辆的移除）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        //private static void Diez(object state)
        //{
        //    dieListz = new List<Int32>();
        //    dieListz = RandomNumber(2, 10);

        //}
        private static void Diez(object source, ElapsedEventArgs e)
        {
            szz.Stop(); //先关闭定时器
            dieListz = new List<Int32>();
            dieListz = RandomNumber(2, 10);
            szz.Start(); //执行完毕后再开启器
        }
        /// <summary>
        /// 骰子变换（掌握主干道下部车辆的进入）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        //private static void Die(object state)
        //{
        //    dieList = new List<Int32>();
        //    dieList= RandomNumber(2, 10);

        //}
        private static void Die(object source, ElapsedEventArgs e)
        {
            szx.Stop(); //先关闭定时器
            dieList = new List<Int32>();
            dieList = RandomNumber(2, 10);
            szx.Start(); //执行完毕后再开启器
        }
        /// <summary>
        /// 骰子变换（掌握支干道右部车辆的进入）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        //private static void Diey(object state)
        //{
        //    dieListy = new List<Int32>();
        //    dieListy = RandomNumber(2, 10);

        //}
        private static void Diey(object source, ElapsedEventArgs e)
        {
            szy.Stop(); //先关闭定时器
            dieListy = new List<Int32>();
            dieListy = RandomNumber(2, 10);
            szy.Start(); //执行完毕后再开启器
        }
        /// <summary>
        /// 第二个骰子变换（掌控主干道上部车辆的移除）
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        //private static void Die2(object state)
        //{
        //    dieList2 = new List<Int32>();
        //    dieList2 = RandomNumber(2, 10);

        //}
        private static void Die2(object source, ElapsedEventArgs e)
        {
            szs.Stop(); //先关闭定时器
            dieList2 = new List<Int32>();
            dieList2 = RandomNumber(2, 10);
            szs.Start(); //执行完毕后再开启器
        }

        /// <summary>
        /// 主干道绿灯行
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void lvdengxing(object source, ElapsedEventArgs e)
        {
            if (laneDown.Count != 0 && deng == "绿")
            {
                laneUp.Enqueue(laneDown.Dequeue());
            }
        }
        /// <summary>
        /// 支干道绿灯行
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void lvdengxingFu(object source, ElapsedEventArgs e)
        {
            if (laneRight.Count != 0 && dengFu == "绿")
            {
                laneLeft.Enqueue(laneRight.Dequeue());
            }
        }


        /// <summary>
        /// 主干道下部车辆变换
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void CardDown(object source, ElapsedEventArgs e)
        {

            ////取出最先加进去的元素，并删除，充分体现队列的先进先出的特性
            ///如队列中无元素，则会引发异常
            //string mes = strList.Dequeue();
            tc.Stop(); //先关闭定时器
                      ///2到10秒内有车辆入车道，即2345678910这八秒每一秒的概率为八分之一
            int jige1 = (DateTime.Now - cardDownState).Seconds;
            if (jige1 >= 2)
            {
                if (dieList.Count>0&& dieList[0] == jige1)
                { 
                    laneDown.Enqueue("车");
                    //foreach (var s in laneDown)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }
            



            if (jige1== 10)
            {
                cardDownState = DateTime.Now;
            }
            tc.Start(); //执行完毕后再开启器





        }
        /// <summary>
        /// 支干道右部车辆变换
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void CardRight(object source, ElapsedEventArgs e)
        {

            ////取出最先加进去的元素，并删除，充分体现队列的先进先出的特性
            ///如队列中无元素，则会引发异常
            //string mes = strList.Dequeue();
            tcy.Stop(); //先关闭定时器
                       ///2到10秒内有车辆入车道，即2345678910这八秒每一秒的概率为八分之一
            int jige2 = (DateTime.Now - cardDownState).Seconds;
            if (jige2 >= 2)
            {
                if (dieListy.Count > 0 && dieListy[0] == jige2)
                {
                    laneRight.Enqueue("车");
                    //foreach (var s in laneDown)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }




            if (jige2 == 10)
            {
                cardRightState = DateTime.Now;
            }
            tcy.Start(); //执行完毕后再开启器





        }
        /// <summary>
        /// 主干道上部车辆移除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void CardUp(object source, ElapsedEventArgs e)
        {

            ////取出最先加进去的元素，并删除，充分体现队列的先进先出的特性
            ///如队列中无元素，则会引发异常
            //string mes = strList.Dequeue();
            tcs.Stop(); //先关闭定时器
                       ///2到10秒内有车辆入车道，即2345678910这八秒每一秒的概率为八分之一
            int jige3 = (DateTime.Now - cardUpState).Seconds;
            if (jige3 >= 2 )
            {
                if (dieList2.Count > 0 && dieList2[0] == jige3)
                {
                    if (laneUp.Count!=0)
                    {
                        laneUp.Dequeue();
                    }
                   
                    //foreach (var s in laneDown)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }




            if (jige3 == 10)
            {
                cardUpState = DateTime.Now;
            }
            tcs.Start(); //执行完毕后再开启器





        }
        /// <summary>
        /// 主干道左部车辆移除
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void CardLeft(object source, ElapsedEventArgs e)
        {

            ////取出最先加进去的元素，并删除，充分体现队列的先进先出的特性
            ///如队列中无元素，则会引发异常
            //string mes = strList.Dequeue();
            tcz.Stop(); //先关闭定时器
                        ///2到10秒内有车辆入车道，即2345678910这八秒每一秒的概率为八分之一
            int jige4 = (DateTime.Now - cardLeftState).Seconds;
            if (jige4 >= 2)
            {
                if (dieListz.Count > 0 && dieListz[0] == jige4)
                {
                    if (laneLeft.Count != 0)
                    {
                        laneLeft.Dequeue();
                    }

                    //foreach (var s in laneDown)
                    //{
                    //    Console.WriteLine(s);
                    //}
                }
            }




            if (jige4 == 10)
            {
                cardLeftState = DateTime.Now;
            }
            tcz.Start(); //执行完毕后再开启器





        }


        /// <summary>
        /// 主干道红绿灯变换
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            t.Stop(); //先关闭定时器



            //Console.Clear();
            int jige5 = (DateTime.Now - lightState).Seconds;
            if (/*conu>=1&&conu<=27*/jige5<=27)
            {
                deng = "绿";
                //Console.Write("绿");
                //conu++;
            }
           else if (/*conu>27&&conu<=30*/jige5> 27&&jige5<=30)
            {
                deng = "黄";
                //Console.Write("黄");
                //conu++;
            }
          else  if (jige5>30&& jige5 <60)
            {
                deng = "红";
                //Console.Write("红");
                //conu++;
            }
           else if (jige5==60)
            {
                deng = "红";
                //Console.Write("红");
                lightState = DateTime.Now;
            }
           
            t.Start(); //执行完毕后再开启器
            //Console.Clear();
            //Console.Write(deng);

            //Console.Clear();
            ////Stack<string> light = new Stack<string>();
            ////light.Push("红");
            ////light.Push("黄");
            ////light.Push("绿");
            ////Stack<string> nulllight = new Stack<string>();
            ////nulllight.Push( light.Pop());
            //if (light=="红")
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //else
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //Console.Write(light);



            //Console.Clear();
            //Console.Write(light);
            //Console.Clear();
            //Console.WriteLine(DateTime.Now);
        }
        /// <summary>
        /// 支干道红绿灯变换
        /// </summary>
        /// <param name="source"></param>
        /// <param name="e"></param>
        private static void OnTimedEventFu(object source, ElapsedEventArgs e)
        {
            tFu.Stop(); //先关闭定时器



            //Console.Clear();
            int jige6= (DateTime.Now - lightStateFu).Seconds;
            if (/*conu>=1&&conu<=27*/jige6 <= 30)
            {
                dengFu = "红";
                //Console.Write("绿");
                //conu++;
            }
            else if (/*conu>27&&conu<=30*/jige6 <=57 && jige6 > 30)
            {
                dengFu = "绿";
                //Console.Write("黄");
                //conu++;
            }
            else if (jige6 > 57 && jige6 < 60)
            {
                dengFu = "黄";
                //Console.Write("红");
                //conu++;
            }
            else if (jige6 == 60)
            {
                dengFu = "黄";
                //Console.Write("红");
                lightStateFu = DateTime.Now;
            }

            tFu.Start(); //执行完毕后再开启器
            //Console.Clear();
            //Console.Write(deng);

            //Console.Clear();
            ////Stack<string> light = new Stack<string>();
            ////light.Push("红");
            ////light.Push("黄");
            ////light.Push("绿");
            ////Stack<string> nulllight = new Stack<string>();
            ////nulllight.Push( light.Pop());
            //if (light=="红")
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent1);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //else
            //{
            //    light = "黄";
            //    System.Timers.Timer t = new System.Timers.Timer();
            //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent2);
            //    t.Interval = 3000;
            //    t.Enabled = true;
            //}
            //Console.Write(light);



            //Console.Clear();
            //Console.Write(light);
            //Console.Clear();
            //Console.WriteLine(DateTime.Now);
        }
        //private static void OnTimedEvent1(object source, ElapsedEventArgs e)
        //{
        //    light = "绿";
        //    Console.Write(light);

        //    System.Timers.Timer t = new System.Timers.Timer();
        //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    t.Interval = 27000;
        //    t.Enabled = true;
        //}
        //private static void OnTimedEvent2(object source, ElapsedEventArgs e)
        //{
        //    light = "红";
        //    Console.Write(light);

        //    System.Timers.Timer t = new System.Timers.Timer();
        //    t.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        //    t.Interval = 27000;
        //    t.Enabled = true;
        //}
        //public static void deng()
        //{
        //    Stack<string> light = new Stack<string>();
        //    light.Push("红");
        //    light.Push("黄");
        //    light.Push("绿");
        //    Stack<string> nulllight = new Stack<string>();
        //}
        private static void OnTimedEvent4(object source, ElapsedEventArgs e)
        {
            Console.Clear();
            Console.Write(deng);
        }

        /// <summary>
        /// 创建一个得到随机数数组的方法(方法参数代表随机数范围）
        /// </summary>
        /// <returns></returns>
        private static List<Int32> RandomNumber(int begin, int end)
        {
            List<Int32> sjList = new List<Int32>();
            for (int i = 0; i < 100; i++)
            {

                byte[] buffer = Guid.NewGuid().ToByteArray();
                int iSeed = BitConverter.ToInt32(buffer, 0);
                Random random = new Random(iSeed);
                sjList.Add(random.Next(begin, end + 1));
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
