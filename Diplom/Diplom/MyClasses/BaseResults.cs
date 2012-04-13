using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class BaseResults
    {
        public BaseResults()
        { }
        public BaseResults(string number, string isum, string ful, string fdl, string power, string g, string lf)
        {
            this.number = number;
            this.isum = isum;
            this.ful = ful;
            this.fdl = fdl;
            this.power = power;
            this.g = g;
            this.lf = lf;
        }
        public string number;
        public string isum;
        public string ful;
        public string fdl;
        public string power;
        public string g;
        public string lf;
    }
}
