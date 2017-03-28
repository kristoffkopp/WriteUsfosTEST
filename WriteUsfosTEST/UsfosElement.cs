using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteUsfosTEST
{
    public class UsfosElement
    {
        public int[] IndexElement { get; set; } 
        public int[] ElementType { get; set; }
        public int[] PropertyNumberElement { get; set; }
        public int[] MaterialNumberElement { get; set; }
        public int[,] NodeNumbersElements { get; set; }
        public double[][] xVec { get; set; }
    }
}
