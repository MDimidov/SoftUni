using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Snake_Moves
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

            char[] charArray = Console.ReadLine()
                .ToCharArray();
            Queue<char> queue = new Queue<char>(charArray);

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (row % 2 == 0)
                    {
                        matrix[row, col] = queue.Peek();
                    }
                    else
                    {
                        matrix[row, matrix.GetLength(1) - 1 - col] = queue.Peek();
                    }
                    queue.Enqueue(queue.Dequeue());
                }
                queue.Reverse();
            }

            for(int row = 0; row < matrix.GetLength(0); row++)
            {
                for(int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
