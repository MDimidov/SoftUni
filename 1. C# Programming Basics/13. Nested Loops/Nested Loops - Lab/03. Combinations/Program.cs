using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Combinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int totalSuccessfulCases = 0;
            for (int i = 0; i <= n; i++)
            {
                for (int j = 0; j <= n; j++)
                {
                    for (int k = 0; k <= n; k++)
                    {
                        if (i + j + k == n)
                            totalSuccessfulCases++;
                    }
                }
            }
            Console.WriteLine(totalSuccessfulCases);
        }
    }
}
