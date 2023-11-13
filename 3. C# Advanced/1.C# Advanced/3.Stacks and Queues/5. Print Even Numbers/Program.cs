using System;
using System.Collections.Generic;
using System.Linq;

namespace _5.Print_Even_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<int> queue = new Queue<int>(
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(x => int.Parse(x))
                .Where(x => x % 2 == 0)
                .ToArray());

            Console.WriteLine(String.Join(", ", queue));


        }
    }
}
