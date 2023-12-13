using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Clock
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int h = 23;
            int m = 60;
            int s = 60;
            for (int i = 0; i <= h; i++)
            {
                for (int j = 0; j < m; j++)
                {
                    for (int k = 0; k < s; k++)
                    {
                    Console.WriteLine($"{i} : {j} : {k}");
                    }
                }
            }

        }
    }
}
