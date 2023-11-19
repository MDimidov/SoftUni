using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Square_With_Maximum_Sum
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] matrixSize = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();
            int rows = matrixSize[0];
            int cols = matrixSize[1];
            int[,] matrix = new int[rows, cols];

            int subRows = 2;
            int subCols = 2;

            for(int row = 0; row < rows; row++)
            {
                int[] array = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();
                for(int col = 0; col < cols; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int maxSum = 0;
            int maxRow = -1;
            int maxCol = -1;
            for(int row = 0; row < rows - subRows + 1; row++)
            {
                for (int col = 0; col < cols - subCols + 1; col++)
                {
                    int sum = 0;
                    for(int subRow = row; subRow < subRows + row; subRow++)
                    {
                        for(int subCol = col; subCol < subCols + col; subCol++)
                        {
                            sum += matrix[subRow, subCol];
                        }
                    }
                    if(maxSum < sum)
                    {
                        maxSum = sum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            for (int subRow = maxRow; subRow < subRows + maxRow; subRow++)
            {
                for (int subCol = maxCol; subCol < subCols + maxCol; subCol++)
                {
                    Console.Write($"{matrix[subRow, subCol]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine(maxSum);
        }
    }
}
