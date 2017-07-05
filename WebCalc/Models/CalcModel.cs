using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebCalc.Models
{
    public class CalcModel
    {

        public string Operation { get; set; }
        
        public double? X { get; set; }
        
        public double? Y { get; set; }

        public double[] Arguments
        {
            get
            {
                return new[] { X ?? 0, Y ?? 0 };
            }
        }
        
        public double? Result { get; set; } 
        public bool IsCompute { get; set; }
    }
}