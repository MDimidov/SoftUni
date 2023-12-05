using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Flower_Shop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата четем
            //      •	Брой магнолии – цяло число в интервала[0 … 50]
            int magnolia = int.Parse(Console.ReadLine());
            //      •	Брой зюмбюли – цяло число в интервала[0 … 50]
            int hyacinth = int.Parse(Console.ReadLine());
            //      •	Брой рози – цяло число в интервала[0 … 50]
            int rose = int.Parse(Console.ReadLine());
            //      •	Брой кактуси – цяло число в интервала[0 … 50]
            int cactus = int.Parse(Console.ReadLine());
            //      •	Цена на подаръка – реално число в интервала[0.00 … 500.00]
            double presentPrice = double.Parse(Console.ReadLine());

            //2. Изчисляваме колко ще струва всяко едно закупено звете
            double magnoliaPrice = magnolia * 3.25;
            double hyancinthPrice = hyacinth * 4;
            double rosePrice = rose * 3.5;
            double cactusPrice = cactus * 8;

            double totalPrice = (magnoliaPrice + hyancinthPrice + rosePrice + cactusPrice) * 0.95;
            double difference = totalPrice - presentPrice;

            if (difference >= 0)
            {
                Console.WriteLine($"She is left with {Math.Floor(difference)} leva.");
            }
            else 
            {
                Console.WriteLine($"She will have to borrow {Math.Ceiling(-difference)} leva.");
            }




        }
    }
}
