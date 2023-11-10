using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Secret_Door_s_Lock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int a = int.Parse(Console.ReadLine());
            int b = int.Parse(Console.ReadLine());
            int c = int.Parse(Console.ReadLine());
            int prime = 0;

            for (int i = 2; i <= a; i += 2)
            {
                for (int j = 2; j <= b; j++)
                {
                    bool isPrime = true;
                    for (int k = 2; k < j; k++)
                    {
                        if (j % k == 0)
                        {
                            isPrime = false;
                            break;
                        }
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
