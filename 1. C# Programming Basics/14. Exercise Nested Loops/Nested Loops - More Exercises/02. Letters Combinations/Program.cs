using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Letters_Combinations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            char start = Console.ReadLine()[0];
            char finish = Console.ReadLine()[0];
            char without = Console.ReadLine()[0];
            int cnter = 0;

            for (int i = (int)start; i <= (int)finish; i++)
            {
                bool isWithout = true;
                for (int j = (int)start; j <= (int)finish; j++)
                {
                    for(int k = (int)start; k <= (int)finish; k++)
                    {
                        if (i == (int)without || j == (int)without || k == (int)without)
                        {
                            isWithout = false;
                        }
                        else
                        {
                            Console.Write($"{(char)i}{(char)j}{(char)k} ");
                            cnter++;
                        }
                    }
                }
            }
            Console.Write($"{cnter}");
        }
    }
}
