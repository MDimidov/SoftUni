using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Fast_Food
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int totalFood = int.Parse(Console.ReadLine());

            Queue<int> queue = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray());

            int maxOrder = queue.Max();

            while(queue.Any() && totalFood >= queue.Peek())
            {
                int currOrder = queue.Dequeue();
                totalFood -= currOrder;
            }

            Console.WriteLine(maxOrder);
            if(queue.Any())
            {
                Console.WriteLine($"Orders left: {String.Join(' ',queue)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
