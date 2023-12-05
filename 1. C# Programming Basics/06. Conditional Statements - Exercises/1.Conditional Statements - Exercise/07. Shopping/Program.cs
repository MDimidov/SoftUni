using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Shopping
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме в конзолата
            //      1.Бюджетът на Петър -реално число в интервала[0.0…100000.0]
            double budget = double.Parse(Console.ReadLine());
            //      2.Броят видеокарти - цяло число в интервала[0…100]
            int videoCard = int.Parse(Console.ReadLine());
            //      3.Броят процесори - цяло число в интервала[0…100]
            int cpu = int.Parse(Console.ReadLine());
            //      4.Броят рам памет -цяло число в интервала[0…100]
            int ram = int.Parse(Console.ReadLine());

            //2. Пресмятаме цените за отделните покупки
            int videoCardPrice = videoCard * 250;
            double cpuPrice = (videoCardPrice * 0.35) * cpu;
            double ramPrice = (videoCardPrice * 0.1) * ram;

            double total = videoCardPrice + cpuPrice + ramPrice;
            if (videoCard > cpu)
            {
                total -= total * 0.15;
            }

            double difference = budget - total;
          /*Console.WriteLine(videoCardPrice);
            Console.WriteLine(cpuPrice);
            Console.WriteLine(ramPrice); */
            if (difference >= 0)
            {
                Console.WriteLine($"You have {difference:f2} leva left!");
            }
            else
            {
                Console.WriteLine($"Not enough money! You need {Math.Abs(difference):f2} leva more!");
            }


        }
    }
}
