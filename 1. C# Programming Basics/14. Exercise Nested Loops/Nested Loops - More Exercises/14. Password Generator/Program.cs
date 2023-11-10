using System;
using System.Collections.Generic;
using System.Linq;

namespace _14.Password_Generator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int L = int.Parse(Console.ReadLine()) + 96;

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    for (int k = 97; k <= L; k++)
                    {
                        for (int l = 97; l <= L; l++)
                        {
                            for (int m = j + 1; m <= n; m++)
                            {
                                if (m > i)
                                    Console.Write($"{i}{j}{(char)k}{(char)l}{m} ");
                            }
                        }
                    }
                }
            }
        }
    }
}
