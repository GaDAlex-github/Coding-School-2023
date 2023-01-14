using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class ProgThree
    {
        //3. Write a C# program that asks the user for an integer (n) and finds all the prime numbers from 1 to n.
        public static void Prime()
        {
            Console.WriteLine("Give an int for Primes: ");
            string s = Console.ReadLine();
            int num = Int32.Parse(s);

            Console.WriteLine("Prime numbers till " + num + " are: ");
            for (int i = 2; i < num + 1; i++)
            {
                PrimeNumber(i);
            }
        }
        public static void PrimeNumber(int num)
        {
            int n = 0;
            for (int i = 2; i < (num / 2 + 1); i++)
            {
                if (num % i == 0)
                {
                    n++;
                    break;
                }
            }
            if (n == 0)
            {
                Console.Write(num + " ");
            }

        }

    }

}