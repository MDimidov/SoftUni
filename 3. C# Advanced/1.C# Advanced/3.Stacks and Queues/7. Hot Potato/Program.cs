using System;
using System.Collections.Generic;
using System.Linq;

namespace _7.Hot_Potato
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(
                Console.ReadLine()
                .Split());
            int n = int.Parse(Console.ReadLine());
            int copyN = n;
            while(queue.Count > 1)
            {
                if(copyN-- == 1)
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                    copyN = n;
                }
                else
                {
                    queue.Enqueue(queue.Dequeue());
                }
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
