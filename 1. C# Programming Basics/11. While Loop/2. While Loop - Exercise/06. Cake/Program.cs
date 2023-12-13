using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Cake
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We read from the console
            //      - length of the cake
            int lenght = int.Parse(Console.ReadLine());
            //      - width of the cake
            int width = int.Parse(Console.ReadLine());

            int leftPeaces = lenght * width;
            string input;
            int tokenPeaces;

            while (leftPeaces > 0)
            {
                input = Console.ReadLine();
                if (input == "STOP")
                {
                    Console.WriteLine($"{leftPeaces} pieces are left.");
                    return;
                }
                tokenPeaces = int.Parse(input);
                leftPeaces -= tokenPeaces;

            }
            Console.WriteLine($"No more cake left! You need {Math.Abs(leftPeaces)} pieces more.");

        }
    }
}
