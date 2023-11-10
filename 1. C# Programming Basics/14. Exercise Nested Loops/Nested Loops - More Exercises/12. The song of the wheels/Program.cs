using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.The_song_of_the_wheels
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int m = int.Parse(Console.ReadLine());
            int fourthCombination = 0;
            string password = String.Empty;

            for (int a = 1; a <= 9; a++)
            {
                for (int b = 1; b <= 9; b++)
                {
                    for (int c = 1; c <= 9; c++)
                    {
                        for (int d = 1; d <= 9; d++)
                        {
                            if (a < b && c > d && ((a * b) + (c * d) == m))
                            {
                                Console.Write($"{a}{b}{c}{d} ");
                                fourthCombination++;
                                if (fourthCombination == 4)
                                {
                                    password = $"\nPassword: {a}{b}{c}{d}";
                                }
                            }
                        }
                    }
                }
            }
            if (fourthCombination >= 4)
            {
                Console.WriteLine(password);
            }
            else
                Console.WriteLine("\nNo!");
        }
    }
}
