using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReactCalc.Models
{
    public class SumOperation : Operation
    {
        public override long Code
        {
            get { return 1; }
        }

        public override string Name
        {
            get { return "+"; }
        }

        public override double Execute(double[] args)
        {
            return args.Sum();
        }

        public override string DisplayName
        {
            get { return "Сумма"; }
        }

        public override string Description
        {
            get
            {
                return "Немецкая денежная единица. В письменных источниках слово «пфенниг» появляется в IX—X столетиях. Сам термин рассматривается как изначальное германоязычное обозначение денария.";
            }
        }

    }
}
