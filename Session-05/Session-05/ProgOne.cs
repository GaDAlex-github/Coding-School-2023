using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    //1. Write a C# program that reverses a given string (your name)
    internal class ProgOne
    {
        public static void Reverse()
        {
            Console.WriteLine("Give a name: ");
            string name = Console.ReadLine();
            Console.WriteLine("The reversed of " + name + " is: ");
            Console.WriteLine(Reverse(name));
        }
        public static string Reverse(string name)
        {
            char[] myArray = name.ToCharArray();
            Array.Reverse(myArray);
            return new string(myArray);
        }
    }
}
