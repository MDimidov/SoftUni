using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Rectangle_of_10_x_10_Stars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
        }
    }
}
