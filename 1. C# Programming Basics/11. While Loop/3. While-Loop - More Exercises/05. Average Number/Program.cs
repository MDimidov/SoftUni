using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Average_Number
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int num = 0;
            int sum = 0;
            for (int i = 0; i < n; i++)
            {
                num = int.Parse(Console.ReadLine());
                sum += num;
            }
            Console.WriteLine($"{(double)sum / n:f2}");
        }
    }
}
