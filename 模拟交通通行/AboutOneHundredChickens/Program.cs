using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructuresAlgorithm
{
    class Program
    {
        /// <summary>
        /// 题目：100块钱买100只鸡，其中小鸡一元三只，母鸡三元一只，公鸡五元一只
        /// 解题思路：1/ 3c+3b+5a=100;a+b+c=100;a的范围为[0,100],b的范围为[0,100],b的范围为[0,100],c,b,a分别代表小鸡，母鸡，公鸡数量，由for循环语句将0-100的值一一代入方程求解，输出符合方程式关系的值
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
           for (int a=0;a<=100;a++)
            {
                for (int b=0;b<=100;b++)
                {
                    for (int c=0;c<=100;c++)
                    {
                        int x = 5 * a + 3 * b + c / 3;
                        int y = a + b + c;
                        if (x == 100 && y == 100 && c %3== 0)//条件为 总价100，数量100，小鸡数必须为三的整数倍
                        {
                            Console.WriteLine("公鸡数：{0}\t母鸡数：{1}\t小鸡数：{2}", a, b, c);
                        }
                    }
                }
            }
            Console.Read();
        }
    }
}
