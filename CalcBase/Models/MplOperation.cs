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

        public override string DisplayName
        {
            get
            {
                return "Умножение ";
            }
        }

        public override string Author
        {
            get
            {
                return base.Author;
            }
        }

        public override string Description
        {
            get
            {
                return "Умножение";
            }
        }

        public override bool DisplayOper
        {
            get
            {
                return false;
            }
        }
    }
}
