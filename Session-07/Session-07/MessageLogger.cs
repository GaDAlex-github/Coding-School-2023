using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class MessageLogger {
        public Message[] messages = new Message[1000];
        public int pos = 0;

        public void ReadAll() {
            foreach (Message message in messages) {
                if (message != null) {
                    Console.WriteLine(message.Msg);
                }
            }
        }
        public void Clear() {
            messages = new Message[1000];

        }

        public void Write(Message message) {
            messages[pos++]= message;

        }
    }
}
