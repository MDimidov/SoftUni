using System;
using System.Collections.Generic;
using System.Linq;

namespace _1.Diagonal_Difference
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int[,] matrix = new int[size, size];
            
            for(int row = 0; row < size; row++)
            {
                int[] array = Console.ReadLine()
                    .Split()
                    .Select(n => int.Parse(n))
                    .ToArray();
                for (int col = 0; col < size; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int sumPrimaryDiagonal = 0;
            int sumSecondaryDiagonal = 0;
            for (int i = 0, j = size - 1; i < size; i++, j--)
            {
                sumPrimaryDiagonal += matrix[i, i];
                sumSecondaryDiagonal += matrix[i, j];
            }
            Console.WriteLine(Math.Abs(sumSecondaryDiagonal - sumPrimaryDiagonal));
        }
    }
}
