using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Diplom.MyClasses
{
    class Connected
    {
        public String Label { get; set; }
        public int Value { get; set; }
        public Connected(string label, int value)
        {
            Label = label;
            Value = value;
        }
    }
}
