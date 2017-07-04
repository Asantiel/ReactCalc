using ReactCalc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactorialLibrary
{
    public class FactorialOperation : IOperation
    {
        public long Code
        {
            get { return 1000; }
        }

        public string Name
        {
            get { return "factorial"; }
        }

        public double Execute(double[] args)
        {
            var x = args[0];
            var count = 1d;
            var result = 1d;

            while (count < x)
            {
                result *= count++;
            }
            return result;
        }
    }
}
