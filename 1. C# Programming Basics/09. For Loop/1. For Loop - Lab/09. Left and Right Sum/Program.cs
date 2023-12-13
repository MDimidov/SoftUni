using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Left_and_Right_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int sumLeft = 0;
            int sumRight = 0;
            for(int i = 0; i < n * 2; i++)
            {
                int num = int.Parse((Console.ReadLine()));
                if (i < n)
                {
                    sumLeft += num;
                }
                else
                {
                    sumRight += num;
                }

            }
            if (sumLeft == sumRight)
            {
                Console.WriteLine($"Yes, sum = {sumLeft}");
            }
            else
            {
                Console.WriteLine($"No, diff = {Math.Abs(sumLeft - sumRight)}");
            }
        }
    }
}
