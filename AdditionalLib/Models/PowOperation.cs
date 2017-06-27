using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReactCalc.Models;

namespace AdditionalLib
{
    public class PowOperation : Operation
    {
        public override long Code
        {
            get { return 999; }
        }

        public override string Name
        {
            get { return "pow"; }
        }

        public override double Execute(double[] args)
        {
            return Math.Pow(args[0], args[1]);
        }
    }


}
