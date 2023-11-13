using System;
using System.Collections.Generic;
using System.Linq;

namespace _8.Traffic_Jam
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int numberOfCarsThatCanPass = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();

            int passedCars = 0;
            
            string input;
            while ((input = Console.ReadLine()) != "end")
            {
                if(input == "green")
                {
                    for (int i = 0; i < numberOfCarsThatCanPass; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            passedCars++;
                            continue;
                        }
                        break;
                    }
                    continue;
                }
                queue.Enqueue(input);
            }
            Console.WriteLine($"{passedCars} cars passed the crossroads.");
        }
    }
}
