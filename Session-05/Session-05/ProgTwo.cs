using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    /*2. Write a C# program that asks the user for an integer (n) and gives them the possibility 
     * to choose between computing the sum and computing the product of 1,…,n*/
    internal class ProgTwo
    {
        public static void Result()
        {

            Console.WriteLine("Give an int: ");
            string? s = Console.ReadLine();
            int n = Int32.Parse(s);
            Console.WriteLine("sum or product?");
            string sop = Console.ReadLine();
            while (sop != "sum" || sop != "product")
            {

                if (sop == "sum")
                {
                    Console.WriteLine(CalcSum(n));
                    break;
                }
                if (sop == "product")
                {
                    Console.WriteLine(CalcProduct(n));
                    break;
                }
                else
                {
                    Console.WriteLine("Please choose sum or product!");
                    sop = Console.ReadLine();
                }
            }
        }
        public static int CalcSum(int n)
        {
            int sum = 0;
            for (int i = 1; i <= n; i++)
                sum += i;
            return sum;
        }
        public static int CalcProduct(int n)
        {
            int product = 1;
            for (int i = 1; i <= n; i++)
                product *= i;
            return product;
        }
    }
}
