using System;
using System.Collections.Generic;
using System.Linq;

namespace _2.Squares_in_Matrix
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] size = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(n => int.Parse(n))
                .ToArray();

            char[,] matrix = new char[size[0], size[1]];

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] charArray = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();
                for ( int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = charArray[col];
                }
            }

            int subRows = 2;
            int subCols = 2;
            int totalMatches = 0;

            for(int row = 0; row < matrix.GetLength(0) - subRows + 1; row++)
            { 
                for(int col = 0; col < matrix.GetLength(1) - subCols + 1; col++)
                {
                    char symbol = matrix[row, col];
                    bool isMatchedSquare = true;
                    for(int subRow = row; subRow < subRows + row; subRow++)
                    {
                        for(int subCol = col; subCol < subCols + col; subCol++)
                        {
                            if (matrix[subRow, subCol] != symbol)
                            {
                                isMatchedSquare = false;
                                break;
                            }
                        }
                        if(!isMatchedSquare)
                        {
                            break;
                        }
                    }
                    if(isMatchedSquare)
                    {
                        totalMatches++;
                    }
                }
            }
            Console.WriteLine(totalMatches);

        }
    }
}
