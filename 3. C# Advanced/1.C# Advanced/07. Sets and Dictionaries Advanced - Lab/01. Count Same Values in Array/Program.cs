using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Count_Same_Values_in_Array
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<double, int> numbers = new Dictionary<double, int>();

            double[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse)
                .ToArray();

            for(int i = 0; i < array.Length; i++)
            {
                if (!numbers.ContainsKey(array[i]))
                {
                    numbers[array[i]] = 0;
                }
                numbers[array[i]]++;
            }

            foreach(var (key, pair) in numbers)
            {
                Console.WriteLine($"{key} - {pair} times");
            }
        }
    }
}
