using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class DivOperation : Operation
    {
        public override long Code
        {
            get
            {
                return 3;
            }
        }

        public override string Name
        {
            get
            {
                return "/";
            }
        }

        public override double Execute(double[] args)
        {
            return args[0] / args[1];
        }
    }
}
