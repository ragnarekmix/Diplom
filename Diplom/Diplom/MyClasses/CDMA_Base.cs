using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class CDMA_Base: Point
    {
        public CDMA_Base(int y, int x)
            : base(y, x)
        {
        }
        public static Double Ful { get; set; } // МГц
        public static Double Fdl { get; set; } // МГц
        public static Double P { get; set; }   // Ват
        public static Double G { get; set; }   // дБ
        public static Double Lf { get; set; }  // дБ
       
    }
}
