using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Number_Pyramid
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int currentNum = 1;

            for (int row = 1; row <= n; row++)
            {
                for ( int col = 1; col <= row; col++)
                {
                    Console.Write($"{currentNum} ");
                    currentNum++;
                    if (currentNum > n)
                        return;
                }
                Console.WriteLine();
            }
        }
    }
}
