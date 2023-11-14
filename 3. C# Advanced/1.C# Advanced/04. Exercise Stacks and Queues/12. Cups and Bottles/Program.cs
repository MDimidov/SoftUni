using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Cups_and_Bottles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stack<int> cups = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Reverse()
                .ToArray());

            Stack<int> bottles = new Stack<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int wastedLittersOfWater = 0;

            while (cups.Any() && bottles.Any())
            {
                int cupsCapacity = cups.Pop();
                int bottlesCapacity = bottles.Pop();

                if(bottlesCapacity - cupsCapacity >= 0)
                {
                    wastedLittersOfWater += (bottlesCapacity - cupsCapacity);
                }
                else
                {
                    cupsCapacity -= bottlesCapacity;
                    cups.Push(cupsCapacity);
                }
            }

            if (cups.Any())
            {
                Console.WriteLine($"Cups: {string.Join(' ', cups)}");
            }
            else
            {
                Console.WriteLine($"Bottles: {string.Join(' ', bottles)}");
            }
            Console.WriteLine($"Wasted litters of water: {wastedLittersOfWater}");
        }
    }
}
