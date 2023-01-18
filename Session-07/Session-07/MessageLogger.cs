using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class MessageLogger {
        public Message[] Messages = new Message[1000];
        private int _pos = 0;

        public void ReadAll() {
            foreach (Message message in Messages) {
                if (message != null) {
                    Console.WriteLine(message.Msg);
                }
            }
        }
        public void Clear() {
            Messages = new Message[1000];

        }

        public void Write(Message message) {
            Messages[_pos++]= message;

        }
    }
}
