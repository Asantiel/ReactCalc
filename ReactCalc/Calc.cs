using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc
{
    class Calc
    {
        public Calc(int x)
        {
            X = x;
        }

        public int X { get; private set; }

        public static int Y { get; set;}

        public string H
        {
            get
            {
                var f = X + Y;
                return string.Format("{0}", f);
            }
        }
    }
}
