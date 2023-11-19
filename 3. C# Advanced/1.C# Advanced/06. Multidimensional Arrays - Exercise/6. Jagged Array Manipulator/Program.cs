using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Jagged_Array_Manipulator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int[][] jaggedArray = new int[rows][];

            for(int row = 0; row < rows; row++)
            {
                jaggedArray[row] = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.Parse(n))
                    .ToArray();
            }

            for(int row = 0; row < rows - 1; row++)
            {
                if (jaggedArray[row].Length == jaggedArray[row + 1].Length)
                {
                    jaggedArray[row] = MultiplyArray(jaggedArray[row]);
                    jaggedArray[row + 1] = MultiplyArray(jaggedArray[row + 1]);
                }
                else
                {
                    jaggedArray[row] = DevideArray(jaggedArray[row]);
                    jaggedArray[row + 1] = DevideArray(jaggedArray[row + 1]);
                }
            }

            string input;
            while ((input = Console.ReadLine()) != "End")
            {
                string[] cmdArg = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string command = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);

                if(row >= 0 && col >= 0 && row < jaggedArray.Length && col < jaggedArray[row].Length)
                {
                    if(command == "Add")
                    {
                        jaggedArray[row][col] += value;
                    }
                    else if(command == "Subtract")
                    {
                        jaggedArray[row][col] -= value;
                    }
                }
            }

            foreach (int[] row in jaggedArray)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }

        static int[] DevideArray(int[] col)
        {
            return col
                .Select(n => n / 2)
                .ToArray();
        }
        static int[] MultiplyArray(int[] col)
        {
            return col
                .Select(n => n * 2)
                .ToArray();
        }
    }
}
