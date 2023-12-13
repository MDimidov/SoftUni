using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Number_sequence
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int max = int.MinValue;
            int min = int.MaxValue;
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (num > max)
                    max = num;
                if (num < min)
                    min = num;
            }
            Console.WriteLine($"Max number: {max}");
            Console.WriteLine($"Min number: {min}");
        }
    }
}
