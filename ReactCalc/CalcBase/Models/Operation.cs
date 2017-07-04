using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public abstract class Operation : IDisplayOperation
    {
        public abstract long Code { get; }

        public abstract string Name { get; }

        public abstract double Execute(double[] args);

        public virtual string DisplayName { get { return ""; } }

        public virtual string Description { get { return ""; } }

        public virtual string Author { get { return "Facebook inc."; } }
    }
}
