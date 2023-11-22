using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Square_Frame
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                if (i == 1 || i == n)
                {
                    Console.Write("+ ");
                    for (int j = 1; j <= n - 2; j++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write("+\n");
                }
                else
                {
                    Console.Write("| ");
                    for (int j = 1; j <= n - 2; j++)
                    {
                        Console.Write("- ");
                    }
                    Console.Write("|\n");
                }
            }
        }
    }
}
