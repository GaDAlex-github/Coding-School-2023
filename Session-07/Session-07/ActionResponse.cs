using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class ActionResponse : Action {
       
        public Guid ResponseID { get; set; }
        public string? Output { get; set; }

        public ActionResponse(Guid id) : base(id) {

        }
        public ActionResponse(Guid id, string? output) :base(id) {
            Output = output;
        }
    }
}
