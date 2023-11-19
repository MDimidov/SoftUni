using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Largest_3_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(String.Join(' ', array
                .OrderByDescending(x => x)
                .Take(3)));
        }
    }
}
