using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Sum_of_Two_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int start = int.Parse(Console.ReadLine());
            int finish = int.Parse(Console.ReadLine());
            int magicNumber = int.Parse(Console.ReadLine());
            int cnter = 0;
            
            for (int i = start; i <= finish; i++)
            {
                for (int j = start; j <= finish; j++)
                {
                    cnter++;
                    if (i + j == magicNumber)
                    {
                        Console.WriteLine($"Combination N:{cnter} ({i} + {j} = {magicNumber})");
                        return;
                    }
                }
            }
            Console.WriteLine($"{cnter} combinations - neither equals {magicNumber}");
        }
    }
}
