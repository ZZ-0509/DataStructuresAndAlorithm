using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDS003.ICollectionWithGenericsDemo
{
    /// <summary>
    /// 相同的尺寸定义为相同的盒子（不懂）
    /// </summary>
    public class BoxSameDimensions : EqualityComparer<Box>
    {
        public override bool Equals(Box b1, Box b2) => 
            b1.Flower == b2.Flower && 
            b1.Count == b2.Count && 
            b1.Ranking == b2.Ranking 
            ? true : false;

        public override int GetHashCode(Box bx)
        {
            var hCode = bx.Ranking;
            return hCode.GetHashCode();
        }
    }
}
