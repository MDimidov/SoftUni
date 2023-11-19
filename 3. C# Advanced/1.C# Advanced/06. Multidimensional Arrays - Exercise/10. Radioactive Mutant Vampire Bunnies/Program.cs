using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Radioactive_Mutant_Vampire_Bunnies
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char[,] matrix = InitializedMatrix();

            MovePlayer(ref matrix);

        }
        static char[,] InitializedMatrix()
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = size[0];
            int cols = size[1];

            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string chars = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = chars[col];
                }
            }
            return matrix;
        }

        static (int, int) StartPostition(char[,] matrix)
        {
            int rows = -1;
            int cols = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.ToUpper(matrix[row, col]) == 'P')
                    {
                        rows = row;
                        cols = col;
                        break;
                    }
                }
                if (rows != -1)
                {
                    break;
                }
            }
            return (rows, cols);
            static void ReplacedBunnies(ref char[,] matrix)
            {

            }
        }
        static void MovePlayer(ref char[,] matrix)
        {
            var startRowCol = StartPostition(matrix);
            int row = startRowCol.Item1;
            int col = startRowCol.Item2;

            string commands = Console.ReadLine().ToUpper();

            foreach (char ch in commands)
            {
                var isMoveValid = IsMoveValid(ch, row, col, matrix);
                if (IsPlayerThere(matrix))
                {
                    if (isMoveValid.Item1)
                    {
                        matrix[row, col] = '.';
                        row = isMoveValid.Item2;
                        col = isMoveValid.Item3;
                        if (char.ToUpper(matrix[row, col]) == 'B')
                        {
                            matrix = MultiplicateBunnies(matrix);
                            PrintMatrix(matrix);
                            Console.WriteLine($"dead: {row} {col}");
                            return;
                        }
                        else
                        {
                            matrix[row, col] = 'P';
                            matrix = MultiplicateBunnies(matrix);
                        }
                    }
                    else
                    {
                        matrix[row, col] = '.';
                        matrix = MultiplicateBunnies(matrix);
                        PrintMatrix(matrix);
                        Console.WriteLine($"won: {row} {col}");
                        return;
                    }
                }
                else
                {
                    PrintMatrix(matrix);
                    Console.WriteLine($"dead: {row} {col}");
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
        static char[,] MultiplicateBunnies(char[,] matrix)
        {
            char[,] newMatrix = new char[matrix.GetLength(0),matrix.GetLength(1)];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    newMatrix[row, col] = matrix[row, col];
                }
            }

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (char.ToUpper(matrix[row, col]) == 'B')
                    {
                        newMatrix = MultiplicateBunnies(newMatrix, matrix, row, col);
                    }
                }
            }
            return newMatrix;
        }

        static bool IsPlayerThere(char[,] matrix)
        {
            foreach (char ch in matrix)
            {
                if (char.ToUpper(ch) == 'P')
                {
                    return true;
                }
            }
            return false;
        }
        static char[,] MultiplicateBunnies(char[,] newMatrix, char[,] matrix, int row, int col)
        {
            if(row - 1 >= 0
                    && col >= 0
                    && row - 1 < matrix.GetLength(0)
                    && col < matrix.GetLength(1))
            {
                //IsPlayerThere(matrix, row - 1, col);
                newMatrix[row - 1, col] = 'B';
            }
            if(row + 1 >= 0
                    && col >= 0
                    && row + 1 < matrix.GetLength(0)
                    && col < matrix.GetLength(1))
            {
                //IsPlayerThere(matrix, row + 1, col);
                newMatrix[row + 1, col] = 'B';
            }
            if(row >= 0
                    && col - 1 >= 0
                    && row < matrix.GetLength(0)
                    && col - 1 < matrix.GetLength(1))
            {
                //IsPlayerThere(matrix, row, col - 1);
                newMatrix[row, col - 1] = 'B';
            }
            if(row >= 0
                    && col + 1 >= 0
                    && row < matrix.GetLength(0)
                    && col + 1 < matrix.GetLength(1))
            {
                //IsPlayerThere(matrix, row, col + 1);
                newMatrix[row, col + 1] = 'B';
            }
            return newMatrix;
        }
        static (bool, int, int) IsMoveValid(char direction, int row, int col, char[,] matrix)
        {
            if(direction == 'U')
            {
                return (row - 1 >= 0
                    && col >= 0
                    && row - 1 < matrix.GetLength(0)
                    && col < matrix.GetLength(1),
                    row - 1,
                    col);
            }
            else if (direction == 'D')
            {
                return (row + 1 >= 0
                    && col >= 0
                    && row + 1 < matrix.GetLength(0)
                    && col < matrix.GetLength(1),
                    row + 1,
                    col);
            }
            else if (direction == 'L')
            {
                return (row >= 0
                    && col - 1 >= 0
                    && row < matrix.GetLength(0)
                    && col - 1 < matrix.GetLength(1),
                    row,
                    col - 1);
            }
            else if (direction == 'R')
            {
                return (row >= 0
                    && col + 1 >= 0
                    && row < matrix.GetLength(0)
                    && col + 1 < matrix.GetLength(1),
                    row,
                    col + 1);
            }
            return (false,
                    row,
                    col);
        }
    }
}
    