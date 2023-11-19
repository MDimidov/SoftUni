using System;
using System.Collections.Generic;
using System.Linq;

namespace _3.Maximal_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[,] matrix = new int[size[0], size[1]];

            int subRows = 3;
            int subCols = 3;

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int maxSum = int.MinValue;
            int startRowMax = -1;
            int startColMax = -1;
            for(int row = 0; row <= matrix.GetLength(0) - subRows; row++)
            {
                for(int col = 0; col <= matrix.GetLength(1) - subCols; col++)
                {
                    int sum = 0;
                    for(int subRow = row; subRow < row + subRows; subRow++)
                    {
                        for(int subCol = col; subCol < col + subCols; subCol++)
                        {
                            sum += matrix[subRow, subCol];
                        }
                    }
                    if(maxSum < sum)
                    {
                        maxSum = sum;
                        startRowMax = row;
                        startColMax = col;
                    }
                }
            }
            Console.WriteLine($"Sum = {maxSum}");
            for(int row = startRowMax; row < startRowMax + subRows; row++)
            {
                for(int col = startColMax; col < startColMax + subCols; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }

        }
    }
}
