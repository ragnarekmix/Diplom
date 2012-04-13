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

        public AbonsResult(string number, string connected, string carier, string parent, string power, string g, string lf)
        {
            this.number = number;
            this.connected = connected;
            this.carier = carier;
            this.power = power;
            this.parent = parent;
            this.g = g;
            this.lf = lf;
        }
        public string number;
        public string power;
        public string connected;
        public string g;
        public string lf;
        public string carier;
        public string parent;
    }
}
