using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Songs_Queue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>(
                Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries));

            while(queue.Any())
            {
                string[] cmdArg = Console.ReadLine()
                    .Split();
                string command = cmdArg[0];
                if(command == "Play")
                {
                    queue.Dequeue();
                }
                else if(command == "Add")
                {
                    string newSong = String.Join(' ', cmdArg.Skip(1));
                    if(!queue.Contains(newSong))
                    {
                        queue.Enqueue(newSong);
                    }
                    else
                    {
                        Console.WriteLine($"{newSong} is already contained!");
                    }
                }
                else if(command == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
