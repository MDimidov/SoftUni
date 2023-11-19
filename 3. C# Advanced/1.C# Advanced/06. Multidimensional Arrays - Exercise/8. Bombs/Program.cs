using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Bombs
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
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
                for(int col = 0; col < size; col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            int[] coordinates = Console.ReadLine()
                .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();
            for(int i = 0; i < coordinates.Length - 1; i += 2)
            {
                int row = coordinates[i];
                int col = coordinates[i + 1];

                PassThroughCells(row, col, ref matrix);
            }

            int aliveCells = 0;
            int sumOfCells = 0;
            foreach(int cell in matrix)
            {
                if(cell > 0)
                {
                    aliveCells++;
                    sumOfCells += cell;
                }
            }

            Console.WriteLine($"Alive cells: {aliveCells}");
            Console.WriteLine($"Sum: {sumOfCells}");
            for(int row = 0; row < size; row++) 
            {
                for(int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }
                Console.WriteLine();
            }
        }

        static void PassThroughCells(int row, int col, ref int[,] matrix)
        {
            int cellPower = matrix[row, col];
            // Center cell
            if (IsCellValid(row, col, matrix))
            {
                matrix[row, col] -= cellPower;
            }
            else
            {
                return;
            }
            // Upper cell
            if (IsCellValid(row - 1, col, matrix))
            {
                matrix[row - 1, col] -= cellPower;
            }
            // Upper-right cell
            if (IsCellValid(row - 1, col + 1, matrix))
            {
                matrix[row - 1, col + 1] -= cellPower;
            }
            // Right cell
            if (IsCellValid(row, col + 1, matrix))
            {
                matrix[row, col + 1] -= cellPower;
            }
            // Down-Right cell
            if (IsCellValid(row + 1, col + 1, matrix))
            {
                matrix[row + 1, col + 1] -= cellPower;
            }
            // Down cell
            if (IsCellValid(row + 1, col, matrix))
            {
                matrix[row + 1, col] -= cellPower;
            }
            // Down-Left cell
            if (IsCellValid(row + 1, col - 1, matrix))
            {
                matrix[row + 1, col - 1] -= cellPower;
            }
            // Left cell
            if (IsCellValid(row, col - 1, matrix))
            {
                matrix[row, col - 1] -= cellPower;
            }
            // Upper-Left cell
            if (IsCellValid(row - 1, col - 1, matrix))
            {
                matrix[row - 1, col - 1] -= cellPower;
            }
        }

        static bool IsCellValid(int row, int col, int[,] matrix)
        {
            return row >= 0
                && col >= 0
                && row <  matrix.GetLength(0)
                && col < matrix.GetLength(1)
                && matrix[row, col] > 0;
        }
    }
}
