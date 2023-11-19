using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Jagged_Array_Modification
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
                    .Split()
                    .Select(int.Parse)
                    .ToArray();
            }

            string input;
            while((input = Console.ReadLine()) != "END")
            {
                string[] cmdArg = input.Split();
                string command = cmdArg[0];
                int row = int.Parse(cmdArg[1]);
                int col = int.Parse(cmdArg[2]);
                int value = int.Parse(cmdArg[3]);

                if(command == "Add")
                {
                    if(IsCoordinatesValid(row, col, jaggedArray))
                    {
                        jaggedArray[row][col] += value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
                if (command == "Subtract")
                {
                    if (IsCoordinatesValid(row, col, jaggedArray))
                    {
                        jaggedArray[row][col] -= value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid coordinates");
                    }
                }
            }

            foreach(var row in jaggedArray)
            {
                Console.WriteLine(string.Join(' ', row));
            }
        }
        static bool IsCoordinatesValid(int row, int col, int[][] jaggedArray)
        {
            if(row >= 0 && col >= 0 && row < jaggedArray.Length && col < jaggedArray[row].Length)
            {
                return true;
            }
            return false;
        }
    }
}
