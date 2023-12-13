using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Football_League
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We Read from Console
            //      - maximum capacity of stadium
            int capacity = int.Parse(Console.ReadLine());
            //      - All fen on the event
            int fans = int.Parse(Console.ReadLine());

            char sector;
            int a = 0;
            int b = 0;
            int v = 0;
            int g = 0;

            double totalFans = (double)fans / capacity * 100;
            //      - For each fan we read which area prefer
            for (int i = 0; i < fans; i++)
            {
                sector = Console.ReadLine()[0];
                if (sector == 'A')
                    a++;
                else if (sector == 'B')
                    b++;
                else if (sector == 'V')
                    v++;
                else
                    g++;
            }
            Console.WriteLine($"{(double)a / fans * 100:f2}%");
            Console.WriteLine($"{(double)b / fans * 100:f2}%");
            Console.WriteLine($"{(double)v / fans * 100:f2}%");
            Console.WriteLine($"{(double)g / fans * 100:f2}%");
            Console.WriteLine($"{totalFans:f2}%");

        }
    }
}
