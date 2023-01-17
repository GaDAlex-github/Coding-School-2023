using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class ActionRequest : Action {
        private Guid _id;
        public override Guid RequestID {
            get { return _id; }
            set { _id = value; }
        }

        public string Input { get; set; }
        public enum ActionEnum {
            Convert,
            Uppercase,
            Reverse
        }
        public ActionEnum? Action { get; set; }

        public ActionRequest(Guid id) : base(id) {

        }
        public ActionRequest(Guid id,string input,ActionEnum e) : base(id) {
            Input = input;
            Action = e;
        }


    }
}
