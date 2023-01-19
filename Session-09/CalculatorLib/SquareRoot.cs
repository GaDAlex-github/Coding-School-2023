using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLib {
    public class SquareRoot {
        public decimal Do(decimal? x) {

            double ret = 0;

            if (x != null) {
                ret = (double)(decimal?)Math.Sqrt((double)x.Value);
            }

            return (decimal)ret;
        }
    }
}
