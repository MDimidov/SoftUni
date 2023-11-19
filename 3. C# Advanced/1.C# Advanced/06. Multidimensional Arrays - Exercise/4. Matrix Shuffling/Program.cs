using System;
using System.Collections.Generic;
using System.Linq;

namespace _4.Matrix_Shuffling
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            string[,] matrix = new string[size[0], size[1]];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] array = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = array[col];
                }
            }

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArg = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                if (command == "swap" && cmdArg.Length == 5)
                {
                    int row1 = int.Parse(cmdArg[1]);
                    int col1 = int.Parse(cmdArg[2]);
                    int row2 = int.Parse(cmdArg[3]);
                    int col2 = int.Parse(cmdArg[4]);
                    if(row1 >= 0 && col1 >= 0 && row2 >= 0 && col2 >= 0
                        && row1 < matrix.GetLength(0) && col1 < matrix.GetLength(1)
                        && row2 < matrix.GetLength(0) && col2 < matrix.GetLength(1))
                    {
                        string firstElement = matrix[row1, col1];
                        matrix[row1, col1] = matrix[row2, col2];
                        matrix[row2, col2] = firstElement;

                        PrintMatrix(matrix);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input!");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

            }
        }
        static void PrintMatrix(string[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
