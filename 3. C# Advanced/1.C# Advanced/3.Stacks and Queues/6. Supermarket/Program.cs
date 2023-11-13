using System;
using System.Collections.Generic;
using System.Linq;

namespace _6.Supermarket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            string input;
            while((input = Console.ReadLine()) != "End")
            {
                if(input == "Paid")
                {
                    while(queue.Count > 0)
                    {
                        Console.WriteLine(queue.Dequeue());
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine($"{queue.Count} people remaining.");
        }
    }
}
