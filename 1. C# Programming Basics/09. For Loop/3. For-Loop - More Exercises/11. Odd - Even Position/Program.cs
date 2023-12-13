using System;
using System.Collections.Generic;
using System.Linq;

namespace _11.Odd___Even_Position
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            double oddSum = 0;
            double oddMin = double.MaxValue;
            double oddMax = double.MinValue;

            double evenSum = 0;
            double evenMin = double.MaxValue;
            double evenMax = double.MinValue;

            for (int i = 1; i <= n; i++)
            {
                double num = double.Parse(Console.ReadLine());
                if (i % 2 != 0)
                {
                    oddSum += num;
                    if (oddMax < num)
                        oddMax = num;
                    if (oddMin > num)
                        oddMin = num;
                }
                else
                {
                    evenSum += num;
                    if (evenMax < num)
                        evenMax = num;
                    if (evenMin > num)
                        evenMin = num;
                }
            }
            Console.WriteLine($"OddSum={oddSum:f2},");
            if (oddMin != double.MaxValue)
            {
                Console.WriteLine($"OddMin={oddMin:f2},");
            }
            else
            {
                Console.WriteLine($"OddMin=No,");
            }

            if (oddMax != double.MinValue)
            {
                Console.WriteLine($"OddMax={oddMax:f2},");
            }
            else
            {
                Console.WriteLine($"OddMax=No,");
            }
            Console.WriteLine($"EvenSum={evenSum:f2},");
            if (evenMin != double.MaxValue)
            {
                Console.WriteLine($"EvenMin={evenMin:f2},");
            }
            else
            {
                Console.WriteLine($"EvenMin=No,");
            }

            if (evenMax != double.MinValue)
            {
                Console.WriteLine($"EvenMax={evenMax:f2}");
            }
            else
            {
                Console.WriteLine($"EvenMax=No");
            }
        }
    }
}
