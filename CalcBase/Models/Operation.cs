using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public abstract class Operation : IOperation
    {
        public abstract long Code { get; }

        public abstract string Name { get; }

        public abstract double Execute(double[] args);
    }
}
