using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class ProgFour
    {   //4. Write a C# program to multiply all values from Array1 with all value from Array2 and display the results in a new Array.
        public static void Multiply()
        {
            int[] array1 = { 2, 4, 9, 12 };
            int[] array2 = { 1, 3, 7, 10 };
            int[] array = new int[array1.Length * array2.Length];
            int k = 0;
            for (int i = 0; i < array1.Length; i++)
            {
                for (int j = 0; j < array2.Length; j++)
                {
                    array[k++] = array1[i] * array2[j];

                }
            }
            Console.WriteLine("New Array: ");
            foreach (int i in array)
            {

                Console.Write(i + " ");
            }

        }
    }
}
