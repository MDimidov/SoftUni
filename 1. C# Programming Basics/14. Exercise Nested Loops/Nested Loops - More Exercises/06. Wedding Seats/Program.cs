using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Wedding_Seats
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char area = Console.ReadLine()[0];
            int rowsA = int.Parse(Console.ReadLine());
            int oddPositions = int.Parse(Console.ReadLine());
            int totalPositions = 0;

            for (int i = 0; i <= (int)area - (int)'A'; i++)
            {
                for (int j = 1; j <= rowsA + i; j++)
                {
                    if ( j % 2 == 0)
                    {
                        for (int k = 1; k <= oddPositions + 2; k++)
                        {
                            Console.WriteLine($"{(char)(i + (int)'A')}{j}{(char)(k + 96)}");
                            totalPositions++;
                        }

                    }
                    else
                    {
                        for (int k = 1; k <= oddPositions; k++)
                        {
                            Console.WriteLine($"{(char)(i + (int)'A')}{j}{(char)(k + 96)}");
                            totalPositions++;
                        }
                    }
                }
            }
            Console.WriteLine(totalPositions);
        }
    }
}
