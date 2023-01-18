using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_07 {
    public class ActionResolver {


        public MessageLogger Logger { get; set; }

        public ActionResolver() {
            Logger = new MessageLogger();
        }
        public ActionResponse Execute(ActionRequest request) {
            ActionResponse response = new ActionResponse(Guid.NewGuid());
            decimal number;
            Message message = new Message();
            try {
                switch (request.Action) {
                    case ActionRequest.ActionEnum.Convert:
                        if (Decimal.TryParse(request.Input, out number)) {
                            string arr = Convert(Decimal.ToInt32(number));
                            message = new Message {
                                Msg = "The binary of the number is: " + arr
                            };
                            response.Output = arr;
                        }
                        else {
                            message = new Message {
                                Msg = "Input is not a decimal."
                            };
                            response.Output = "Wrong Output";
                        }
                        break;
                    case ActionRequest.ActionEnum.Uppercase:
                        message = new Message {
                            Msg = Words(request.Input)
                        };
                        response.Output = Words(request.Input);
                        break;
                    case ActionRequest.ActionEnum.Reverse:
                        message = new Message {
                            Msg = "The reversed word is : " + Reverse(request.Input)
                        };
                        response.Output = Reverse(request.Input);
                        break;
                    default:
                        break;

                }
            }

            catch (Exception ex) {
                Console.WriteLine(ex.ToString());
            }
            finally {
                Logger.Write(message);
            }
            return response;
        }

        public string Convert(int number) {
            int remainder;
            string result = string.Empty;
            while (number > 0) {
                remainder = number % 2;
                number /= 2;
                result = remainder.ToString() + result;
            }
            return result;
        }

        public string Words(string str) {
            string s;
            if (str.Contains(" ")) {
                string longest = Uppercase(str);
                s = "the longest word is: " + longest;
            }
            else {
                s = "Has only 1 word";
            }
            return s;
        }

        public string Uppercase(string str) {
            string[] arr = str.Split(" ");
            string longest = arr.Where(s => s.Length == arr.Max(m => m.Length)).First();
            longest = longest.ToUpper();
            return longest;
        }

        public string Reverse(string str) {
            if (str.Length > 0)
                return str[str.Length - 1] + Reverse(str.Substring(0, str.Length - 1));
            else
                return str;

        }


    }
}
