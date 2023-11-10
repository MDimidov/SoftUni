using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Profit
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int m1 = int.Parse(Console.ReadLine());
            int m2 = int.Parse(Console.ReadLine());
            int m5 = int.Parse(Console.ReadLine());
            int sum = int.Parse(Console.ReadLine());

            for (int i = 0; i <= m1; i++)
            {
                for (int k = 0; k <= m2; k++)
                {
                    for (int j = 0; j <= m5; j++)
                    {
                        if (i + k * 2 + j * 5 == sum)
                        Console.WriteLine($"{i} * 1 lv. + {k} * 2 lv. + {j} * 5 lv. = {sum} lv.");
                    }
                }
            }
        }
    }
}
