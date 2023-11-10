using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Sum_of_Two_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int end = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int unvalidTries = 0;

            for (int i = start; i <= end; i++)
            {
                for (int j = start; j <= end; j++)
                {
                    unvalidTries++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{unvalidTries} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{unvalidTries} combinations - neither equals {magicNumber}");
        }
    }
}
