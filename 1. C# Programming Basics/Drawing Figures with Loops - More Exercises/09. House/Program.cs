using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.House
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= (n + 1) / 2; i++)
            {
                for (int j = i; j < (n + 1) / 2; j++)
                {
                    Console.Write('-');
                }

                for (int j = 2; j <= i; j++)
                {
                    Console.Write("**");
                }

                if (n % 2 == 0)
                {
                    Console.Write("**");
                }
                else
                {
                    Console.Write('*');
                }


                for (int j = i; j < (n + 1) / 2; j++)
                {
                    Console.Write('-');
                }
                Console.WriteLine();
            }
            for (int i = 1; i <= n - ((n + 1) / 2); i++)
            {
                Console.Write("|");
                for (int j = 1; j <= n - 2; j++)
                {
                    Console.Write('*');
                }
                Console.Write("|\n");
            }

        }
    }
}
