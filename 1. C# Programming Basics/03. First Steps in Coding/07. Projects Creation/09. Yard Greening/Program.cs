// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double a = double.Parse(Console.ReadLine());
            double b1 = 7.61;
            double dis = 0.18;
            double total = (a * b1 - (a * b1) * dis);
            double discount = ((a * b1) * dis);
            Console.WriteLine($"The final price is: {total} lv.");
            Console.WriteLine($"The discount is: {discount} lv.");

        }
    }
}