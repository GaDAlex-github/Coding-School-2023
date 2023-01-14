using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session_05
{
    internal class ProgFive
    {
        //5.Write a C# program to sort the given array of integers from the lowest to the highest number.
        public static void Sort()
        {
            int[] array = { 0, -2, 1, 20, -31, 50, -4, 17, 89, 100 };
            Boolean sortCorrect = false;
            do
            {
                sortCorrect = false;
                for (int i = 0; i < array.Count() - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        int lowerValue = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = lowerValue;
                        sortCorrect = true;
                    }
                }
            } while (sortCorrect);
            Console.WriteLine("Array Sorted by min: ");
            foreach (int item in array)
            {
                Console.Write(item + " ");
            }
        }
    }
}
