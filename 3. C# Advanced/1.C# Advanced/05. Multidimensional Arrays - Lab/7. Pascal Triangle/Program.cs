using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Pascal_Triangle
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());

            long[][] jaggedArray = new long[rows][];

            for(int row = 0; row < rows; row++)
            {
                jaggedArray[row] = new long[row + 1];
                for(int col = 0; col <= row; col++)
                {
                    if(row == 0 || col == 0 || col == jaggedArray[row].Length - 1)
                    {
                        jaggedArray[row][col] = 1;
                    }
                    else
                    {
                        jaggedArray[row][col] = jaggedArray[row - 1][col] + jaggedArray[row - 1][col - 1];
                    }

                }
            }

            foreach (long[] row in jaggedArray)
            {
                Console.WriteLine(String.Join(' ', row));
            }
        }
    }
}
