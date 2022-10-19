using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SummativeSums
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array1 = { 1, 90, -33, -55, 67, -16, 28, -55, 15 };
            int[] array2 = { 999, -60, -77, 14, 160, 301 };
            int[] array3 = { 10, 20, 30, 40, 50, 60, 70, 80, 90, 100, 110, 120, 130,
            140, 150, 160, 170, 180, 190, 200, -99 };

            int Sum1 = arrayAdder(array1);
            int Sum2 = arrayAdder(array2);
            int Sum3 = arrayAdder(array3);


            
            Console.WriteLine("The sum of the first array is " + Sum1);
            
            Console.WriteLine("The sum of the second array is " + Sum2);
            
            Console.WriteLine("The sum of the third array is " + Sum3);
            Console.ReadLine();

        }
        public static int arrayAdder(int [] thisArray)
        {
            int sum = 0;


            foreach (int i in thisArray)
            {
                sum += i;
                
            }
            return sum;


        }
    }
}
