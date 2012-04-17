using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    public class AbonsResult
    {
        public AbonsResult()
        { }
                
        public int number { get; set; }
        public double power { get; set; }
        public String connected { get; set; }
        public double g { get; set; }
        public double lf { get; set; }
        public double carier { get; set; }
        public double cin { get; set; }
        public int parent { get; set; }
        public int bedparents { get; set; }
    }
}
