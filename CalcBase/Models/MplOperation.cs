using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class MplOperation : Operation
    {
        public override long Code
        {
            get
            {
                return 2;
            }
        }

        public override string Name
        {
            get
            {
                return "*";
            }
        }

        public override double Execute(double[] args)
        {
            double result = 1;
            foreach (int item in args)
            {
                result *= item;
            }
            return result;
        }
    }
}
