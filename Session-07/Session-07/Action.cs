using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class Action {
        public virtual Guid RequestID { get; set; }

        public Action(Guid requestID) {
            RequestID = requestID;  
        }
    }
}
