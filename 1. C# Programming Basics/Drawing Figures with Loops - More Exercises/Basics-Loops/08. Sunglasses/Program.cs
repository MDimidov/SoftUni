using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Sunglasses
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                //first glass
                if (i == 0 || i == n - 1)
                {
                    for (int j = 1; j <= n * 2; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write('*');
                    for (int j = 1; j <= n * 2 - 2; j++)
                    {
                        Console.Write('/');
                    }
                    Console.Write('*');
                }

                //middle
                if ((n - 1) / 2 - 1 == i - 1)
                {
                    for (int j = 0; j < n; j++)
                    {
                        Console.Write("|");
                    }
                }
                else
                {
                    for(int j = 0; j < n; j++)
                    {
                        Console.Write(" ");
                    }
                }

                //second glasss
                if (i == 0 || i == n - 1)
                {
                    for (int j = 1; j <= n * 2; j++)
                    {
                        Console.Write("*");
                    }
                }
                else
                {
                    Console.Write('*');
                    for (int j = 1; j <= n * 2 - 2; j++)
                    {
                        Console.Write('/');
                    }
                    Console.Write('*');
                }
                Console.WriteLine();
            }
        }
    }
}
