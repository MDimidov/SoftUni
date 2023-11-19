using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Symbol_in_Matrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                char[] chars = Console.ReadLine()
                    .ToCharArray();
                for(int col = 0; col < matrix.GetLength(0); col++)
                {
                    matrix[row, col] = chars[col];
                }
            }

            char symbol = Console.ReadLine()[0];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == symbol)
                    {
                        Console.WriteLine($"({row}, {col})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{symbol} does not occur in the matrix");
        }
    }
}
