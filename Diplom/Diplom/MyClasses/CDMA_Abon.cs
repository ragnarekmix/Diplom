using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class CDMA_Abon : Point
    {
        public CDMA_Abon(int y, int x)
            : base(y, x)
        {
        }
        public static Double P { get; set; }   // Ват
        public static Double G { get; set; }   // дБ
        public static Double Lf { get; set; }  // дБ
        public Boolean Orphan { get; set; }
    }
}
