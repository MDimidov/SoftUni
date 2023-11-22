using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Diamond
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int leftRight = (n - 1) / 2;
            int mid = n - 2 * leftRight - 2;

            for (int i = 1; i <= n / 2; i++)
            {
                if (i == 1 && n % 2 == 0)
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write("**");
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                }
                else if (i == 1 && n % 2 != 0)
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write("*");
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                }
                else
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }

                    Console.Write('*');
                    
                    for (int k = 3; k <= n - 2 * (leftRight - i) - 2; k++)
                    {
                        Console.Write('-');
                    }
                        Console.Write('*');
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }


                }
                    Console.WriteLine();
            }

            int t;
            if (n % 2 != 0)
            {
                t = n + 1;
            }
            else
            {
                t = n - 1;
            }

            for (int i = t / 2; i >= 1; i--)
            {
                if (i == 1 && n % 2 == 0)
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write("**");
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                }
                else if (i == 1 && n % 2 != 0)
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                    Console.Write("*");
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }
                }
                else
                {
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }

                    Console.Write('*');

                    for (int k = 3; k <= n - 2 * (leftRight - i) - 2; k++)
                    {
                        Console.Write('-');
                    }
                    Console.Write('*');
                    for (int j = i; j <= leftRight; j++)
                    {
                        Console.Write('-');
                    }


                }
                Console.WriteLine();
            }
        }
    }
}
