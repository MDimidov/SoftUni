using System;
using System.Collections.Generic;
using System.Linq;

namespace _9.Miner
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            string[] cmdArg = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            char[,] matrix = new char[size, size];

            for(int row = 0; row < size; row++)
            {
                char[] charArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s[0])
                    .ToArray();
                for(int col = 0; col < size; col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }
            MoveBetweenCells(ref matrix, cmdArg);
        }
        static void MoveBetweenCells(ref char[,] matrix, string[] cmdArg)
        {
            (int, int) startPosition = StartPostition(matrix);
            int row = startPosition.Item1;
            int col = startPosition.Item2;

            for(int i = 0; i < cmdArg.Length; i++)
            {
                var conditionElements = IsValidDirection(cmdArg[i], row, col, matrix);
                if (conditionElements.Item1)
                {
                    matrix[row, col] = '*';
                    row = conditionElements.Item2;
                    col = conditionElements.Item3;
                    if (char.ToLower(matrix[row, col]) == 'e')
                    {
                        Console.WriteLine($"Game over! ({row}, {col})");
                        return;
                    }
                    else
                    {
                        matrix[row, col] = 's';
                    }
                }
            }
            int totalCoals = 0;
            foreach(char ch in matrix)
            {
                if(char.ToLower(ch) == 'c')
                {
                    totalCoals++;
                }
            }
            if(totalCoals == 0)
            {
                Console.WriteLine($"You collected all coals! ({row}, {col})");
            }
            else
            {
                Console.WriteLine($"{totalCoals} coals left. ({row}, {col})");
            }
        }

        static (int, int) StartPostition(char[,] matrix)
        {
            int rows = -1;
            int cols = -1;
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.ToLower(matrix[row, col]) == 's')
                    {
                        rows = row;
                        cols = col; 
                        break;
                    }
                }
                if(rows != -1)
                {
                    break;
                }
            }
            return (rows, cols);
        }
        static (bool, int, int) IsValidDirection(string direction, int row, int col, char[,] matrix)
        {
            if(direction == "up")
            {
                return (row - 1 >= 0
                && col >= 0
                && row - 1 < matrix.GetLength(0)
                && col < matrix.GetLength(1),
                row - 1, col);
            }
            else if (direction == "down")
            {
                return (row + 1 >= 0
                && col >= 0
                && row + 1 < matrix.GetLength(0)
                && col < matrix.GetLength(1),
                row + 1, col);
            }
            else if (direction == "left")
            {
                return (row >= 0
                && col - 1 >= 0
                && row < matrix.GetLength(0)
                && col - 1 < matrix.GetLength(1),
                row, col - 1);
            }
            else if (direction == "right")
            {
                return (row >= 0
                && col + 1 >= 0
                && row < matrix.GetLength(0)
                && col + 1 < matrix.GetLength(1),
                row, col + 1);
            }
            return (false, row, col);
        }
    }
}
