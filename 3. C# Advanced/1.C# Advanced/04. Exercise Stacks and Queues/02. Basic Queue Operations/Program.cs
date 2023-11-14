using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Basic_Queue_Operations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int[] input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int n = input[0];
            int elementsToDequeue = input[1];
            int findElement = input[2];

            Queue<int> queue = new Queue<int>(
                Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .Take(n)
                .ToArray());

            //Stack<int> stack = new Stack<int>();

            for(int i = 0; i < elementsToDequeue; i++)
            {
                queue.Dequeue();
            }

            if (!queue.Any())
            {
                Console.WriteLine(0);
            }
            else if (queue.Contains(findElement))
            {
                Console.WriteLine("true");
            }
            else
            {
                Console.WriteLine(queue.Min());
            }

        }
    }
}
