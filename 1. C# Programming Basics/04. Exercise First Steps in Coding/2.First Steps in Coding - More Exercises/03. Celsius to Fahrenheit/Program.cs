// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double F = (a * 9 / 5 + 32);
            Console.WriteLine(String.Format("{0:0.00}", F));
        }
    }
}