using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Sum_Matrix_Columns
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = rowsCols[0];
            int cols = rowsCols[1];

            int[,] matrix = new int[rows, cols];

            for(int row = 0; row < rows; row++)
            {
                int[] array = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }
            for(int col = 0; col < cols; col++)
            {
                int sum = 0;
                for(int row = 0; row < rows; row++)
                {
                    sum += matrix[row, col];
                }
                Console.WriteLine(sum);
            }
        }
    }
}
