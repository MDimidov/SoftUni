// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double cenaZelen = double.Parse(Console.ReadLine());
            double cenaPlod = double.Parse(Console.ReadLine());
            double kgZelen = double.Parse(Console.ReadLine());
            double kgPlod = double.Parse(Console.ReadLine());

            double total = (cenaZelen*kgZelen + kgPlod*cenaPlod)/1.94;
            Console.WriteLine(String.Format("{0:0.00}", total));
        }
    }
}