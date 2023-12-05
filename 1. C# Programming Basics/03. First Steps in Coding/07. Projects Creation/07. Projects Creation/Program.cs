// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            int h = n * 3;
            Console.WriteLine($"The architect {name} will need {h} hours to complete {n} project/s.");
        }
    }
}