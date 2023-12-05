using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Harvest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      •	1ви ред: X кв.м е лозето – цяло число в интервала[10 … 5000]
            int area = int.Parse(Console.ReadLine());
            //      •	2ри ред: Y грозде за един кв.м – реално число в интервала[0.00 … 10.00]
            double grapes = double.Parse(Console.ReadLine());
            //      •	3ти ред: Z нужни литри вино – цяло число в интервала[10 … 600]
            int liters = int.Parse(Console.ReadLine());
            //      •	4ти ред: брой работници – цяло число в интервала[1 … 20]
            int workers = int.Parse(Console.ReadLine());

            //2. За 1 литър вино са нужни 2.5 кг грозде
            double totalKg = grapes * area * 0.4;
            double totalLiters = totalKg / 2.5;
            double differense = totalLiters - liters;

            double wineForWorkers = differense / workers;

            if (differense < 0)
            {
                Console.WriteLine($"It will be a tough winter! More {Math.Floor(Math.Abs(differense))} liters wine needed.");
            }
            else
            {
                Console.WriteLine($"Good harvest this year! Total wine: {Math.Floor(totalLiters)} liters.");
                Console.WriteLine($"{Math.Ceiling(differense)} liters left -> {Math.Ceiling(wineForWorkers)} liters per person.");
            }

        }
    }
}
