using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 相同的体积定义为相同的盒子（不懂）
    /// </summary>
    public class BoxSameVolume : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2) => 
            ( b1.Ranking) == (b2.Ranking)
            ? true : false;

        public override int GetHashCode(Box bx)
        {
            var hCode = 1111^ bx.Ranking;
            Console.WriteLine("HC: {0}", hCode.GetHashCode());
            return hCode.GetHashCode();
        }
    }
}
