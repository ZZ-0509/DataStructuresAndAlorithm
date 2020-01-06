using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AI.Properties;

namespace 人工智能
{
    class Program
    {
        static void Main()
        {

            var keyString = "人工智能";
            TestStreamReaderEnumerable(keyString);
            Console.Read();
        }
        public static void TestStreamReaderEnumerable(string keyString)
        {
            //var memoryBefore = GC.GetTotalMemory(true);
            IEnumerable<String> stringsFound;
            // 使用 StreamReaderEnumerable 打开一个示例文件，检索对应的字符串
            try
            {
                stringsFound =from line in new StreamReaderEnumerable(@"/Users/chentiejun/Desktop/12-31/AI/Properties/tempFile.txt")
                              where line.Contains(keyString)
                              select line;
                int sum = 0;
                foreach (var i in stringsFound)
                {
                    sum++;

                    if (i.Contains(keyString))
                    {
                        int length = i.IndexOf("人工智能", StringComparison.Ordinal);
                        int len = i.IndexOf(".", StringComparison.Ordinal);
                        int len1 = length + 13;
                        if (len > length)
                        {
                            if (len - length >= 13)
                            {
                                
                                string text = i.Substring(length, len1);
                                Console.WriteLine("第:{0}行,第:{1}个字母", sum, length);
                                Console.WriteLine(text + ".");
                            }
                            else
                            {
                                string text = i.Substring(length, len);
                                Console.WriteLine(text + ".");
                            }
                        }

                    }
                }

            }
            catch (FileNotFoundException)
            {
                Console.WriteLine(@"这个例子需要一个名为 \tempFile.txt 的文件。");
                return;
            }


            Console.ReadLine();
        }
    }
}