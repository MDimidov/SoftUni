using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace _03.Logistics
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат поредица от числа, всяко на отделен ред:
            //      •	На първия ред – броя на товарите за превоз – цяло число в интервала[1...1000]
            int n = int.Parse(Console.ReadLine());

            int tonnage;
            int bus = 0;
            int truck = 0;
            int train = 0;
            double sum = 0;
            double price = 0;
            int totalTons = 0;
            int busTons = 0;
            int truckTons = 0;
            int trainTons = 0;
            //      •	За всеки един товар на отделен ред – тонажа на товара – цяло число в интервала[1...1000]
            for (int i = 0; i < n; i++)
            {
                tonnage = int.Parse(Console.ReadLine());
                if (tonnage <= 3)
                {
                    bus++;
                    price = tonnage * 200;
                    busTons += tonnage;
                    totalTons += tonnage;
                }
                else if (tonnage >= 12)
                {
                    train++;
                    price = tonnage * 120;
                    trainTons += tonnage;
                    totalTons += tonnage;
                }
                else
                {
                    truck++;
                    price = tonnage * 175;
                    truckTons += tonnage;
                    totalTons += tonnage;
                }
                sum += price;
            }
            Console.WriteLine($"{sum / (totalTons):f2}");
            Console.WriteLine($"{(double)busTons / totalTons * 100:f2}%");
            Console.WriteLine($"{(double)truckTons / totalTons * 100:f2}%");
            Console.WriteLine($"{(double)trainTons / totalTons * 100:f2}%");
        }
    }
}
