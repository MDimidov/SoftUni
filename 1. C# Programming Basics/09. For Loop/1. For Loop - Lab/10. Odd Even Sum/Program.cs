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
            int even = 0;
            int odd = 0;
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse((Console.ReadLine()));
                if (i % 2 == 0)
                {
                    even += num;
                }
                else
                {
                    odd += num;
                }

            }
            if (even == odd)
            {
                Console.WriteLine($"Yes\nSum = {odd}");
            }
            else
            {
                Console.WriteLine($"No\nDiff = {Math.Abs(even - odd)}");
            }
        }
    }
}
