using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Unique_PIN_Codes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());

            for (int i = 2; i <= a; i += 2)
            {
                for (int j = 2; j <= b; j++)
                {
                    bool isPrime = true;
                    for (int p = 2; p < j; p++)
                    {
                        if (j % p == 0)
                            isPrime = false;
                    }
                    if (isPrime)
                    {
                        for (int k = 2; k <= c; k += 2)
                        {
                            Console.WriteLine($"{i} {j} {k}");
                        }
                    }
                }
            }
        }
    }
}
