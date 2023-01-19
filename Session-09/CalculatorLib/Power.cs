using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib {
    public class Power {
        public decimal Do(decimal? x, decimal? y) {
            
            double ret = 0;

            if (x != null && y != null) {
                ret = (double)(decimal?)Math.Pow((double)x.Value,(double)y.Value);
            }
         
            return (decimal)ret;
        }
    }
}
