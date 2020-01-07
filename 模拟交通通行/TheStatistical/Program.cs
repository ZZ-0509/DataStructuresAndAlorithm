using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    /// <summary>
    /// 计算人员平均年龄的算法，精确到：xx 周岁 xx 天。
    /// 按照人员姓氏统计人员总数（注意要处理复姓情况)
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            ///计算日期差值思路，此处本应为数轴举例更为合适，奈何不会，就以两日期，2018年10月1日、2020年1月2日；举例说明
            ///首先，计算2020-2019，作为年数；
            ///再其次计算2018年10月1日至20191月1日的天数，计算20201月2日至20201月1日的天数，两处计算的天数相加，作为天数
           
            List<Person> list = PersonRepository.InitialPersonCollection();//储存即将进行操作的数据
            int y;//定义一变量储存年数
            int d;//定义一变量储存天数
            int yz = 0;//定义一变量储存所有年数
            int dz = 0;//定义一变量储存所有天数
            int i = 0;//此变量用于统计人数

            foreach (var w in list)
            {
                y = DateTime.Now.Year - (w.Birthday.Year + 1);
                d = (12 - w.Birthday.Month) * 30 + (30 - w.Birthday.Day) + ((DateTime.Now.Month - 1) * 30) + DateTime.Now.Day;//此处以一个月30天计算
                yz = y + yz;//累加年数
                dz = d + dz;//累加天数
                i++;
            }
            if (dz / i > 365)//判断平均天数是否凑够一年（以一年365天计算）
            { Console.WriteLine("平均年龄{0}周年{1}天", (yz / i) + 1, (dz / i) - 365); }
            else {
                Console.WriteLine("平均年龄{0}周年{1}天", yz / i, dz / i);
            }
            Console.WriteLine();


            ///计算各个姓的个数
            ///借用Linq分组统计，难点在于要么以姓名的第一个字作为分组依据，要么以姓名的第一个字和第二个字作为分组依据
            ///思路，先判断姓氏是否为复姓，然后分离单复姓数据


            List<string> fxlist = Sz();//调用方法，得到一个包含百家姓81复姓的集合
            List<Person> nlist = new List<Person>();//用于储存复姓的集合
            List<Person> nlist1 = new List<Person>();//用于储存单姓的集合
            


            for (int x = 0; x < list.Count; x++)
            {
                //如果是一个复姓，放入一个集合
                string qq = list[x].Name.Substring(0, 2);
                if (fxlist.Contains (qq))
                {
                    nlist.Add(list[x]);
                }
                //不是复姓放入另一个集合
                else
                {
                    nlist1.Add(list[x]);
                }
            }
           //输出单姓
            var ww = nlist1.GroupBy(s => s.Name.Substring(0, 1));
            foreach (var w in ww)
            {
                Console.WriteLine("{0}姓：{1}人", w.Key, w.Count());
            }
            //输出复姓
            var ww1 = nlist.GroupBy(s => s.Name.Substring(0, 2));
            foreach (var w in ww1)
            {
                Console.WriteLine("{0}姓：{1}人", w.Key, w.Count());
            }
                Console.Read();



            
        }
       /// <summary>
       /// 创建一个包含百家姓81复姓的集合
       /// </summary>
       /// <returns></returns>
        public static  List <string> Sz()
        {
            int i = 0;
            List<string> stlist = new List<string>();
            string fx ="欧阳太史端木上官司马东方独孤南宫万俟闻人夏侯诸葛尉迟公羊赫连澹台皇甫宗政濮阳公冶太叔申屠公孙慕容仲孙钟离长孙宇文司徒鲜于司空闾丘子车亓官司寇巫马公西颛孙壤驷公良漆雕乐正宰父谷梁拓跋夹谷轩辕令狐段干百里呼延东郭南门羊舌微生公户公玉公仪梁丘公仲公上公门公山公坚左丘公伯西门公祖第五公乘贯丘公皙南荣东里东宫仲长子书子桑即墨达奚褚师";

            for (int yy=0;yy <=80;yy ++ )
            {
                string ww = fx.Substring(i ,2);
                stlist.Add(ww);
                i++;i++;
            }
            return stlist;
           
        }
    }
}
  