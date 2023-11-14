using System;
using System.Collections.Generic;
using System.Linq;

namespace _10.Crossroads
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int greenLightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>();
            int counter = 0;

            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                int greenLight = greenLightDuration;
                int freeWindow = freeWindowDuration;

                if(input == "green")
                {
                    while (queue.Any() && greenLight > 0)
                    {
                        int time = queue.Peek().Length;
                        if(greenLight - time >= 0)
                        {
                            greenLight -= time;
                            counter++;
                        }
                        else if(greenLight + freeWindow - time >= 0)
                        {
                            counter++;
                            greenLight -= time;
                            queue.Dequeue();
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"A crash happened!");
                            Console.WriteLine($"{queue.Peek()} was hit at {queue.Peek()[greenLight + freeWindow]}.");
                            return;
                        }
                        queue.Dequeue();
                    }
                }
                else
                {
                    queue.Enqueue(input);
                }
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{counter} total cars passed the crossroads.");
        }
    }
}
