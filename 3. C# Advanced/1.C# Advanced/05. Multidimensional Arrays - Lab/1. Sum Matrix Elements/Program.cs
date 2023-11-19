using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Sum_Matrix_Elements
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] rowsColums = Console.ReadLine()
                .Split(", ")
                .Select(x => int.Parse(x))
                .ToArray();
            int rows = rowsColums[0];
            int cols = rowsColums[1];

            int[,] matrix = new int[rows, cols];

            for(int i = 0; i < rows; i++)
            {
                int[] array = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(x => int.Parse(x))
                    .ToArray();

                for(int j = 0; j < cols; j++)
                {
                    matrix[i,j] = array[j];
                }
            }

            int sum = 0;
            foreach(int elemnt in matrix)
            {
                sum += elemnt;
            }
            Console.WriteLine(rows);
            Console.WriteLine(cols);
            Console.WriteLine(sum);
        }
    }
}
