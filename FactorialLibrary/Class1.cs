using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;

namespace FactorialLibrary
{
    public class FactorialOperation : Operation
    {
        public override long Code
        {
            get { return 1000; }
        }

        public override string Name
        {
            get { return "factorial"; }
        }

        public override double Execute(double[] args)
        {
            var x = args[0];
            var count = 1d;
            var result = 1d;
            while (count <= x)
            {
                result *= count++;
            }
            return result;
        }
    }
}
