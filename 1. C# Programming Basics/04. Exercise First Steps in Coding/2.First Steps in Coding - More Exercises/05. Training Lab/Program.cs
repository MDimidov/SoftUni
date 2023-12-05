// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double w = double.Parse(Console.ReadLine()); //в метри
            double h = double.Parse(Console.ReadLine()); //в метри
            double a = w * 100;                          // преобразуваме дължината в см
            double b = (h * 100) - 100;                          // преобразуваме ширината в см
            double sh = (b - b % 70) / 70;
            double d = (a - a % 120) / 120;



            Console.WriteLine(d * sh - 3);

        }
    }
}