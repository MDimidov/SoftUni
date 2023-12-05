using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Fuel_Tank___Part_2
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата четем
            //      •	Типа на горивото – текст с възможности: "Gas", "Gasoline" или "Diesel"
            string fuel = Console.ReadLine();
            //      •	Количество гориво – реално число в интервала[1.00 … 50.00]
            double liters = double.Parse(Console.ReadLine());
            //      •	Притежание на клубна карта – текст с възможности: "Yes" или "No"
            string discount = Console.ReadLine();

            double price = 0;
            double less = 0;

            //2. Изчисляваме колко ще струва всяко гориво със и без карта
            if (fuel == "Diesel")
            {
                price = liters * 2.33;
                less = liters * (2.33 - 0.12);

            }
            else if (fuel == "Gasoline")
            {
                price = liters * 2.22;
                less = liters * (2.22 - 0.18);
            }
            else if (fuel == "Gas")
            {
                price = liters * 0.93;
                less = liters * (0.93 - 0.08);
            }
           
            if (discount == "Yes")
            {
                price = less;
            }

            //3. проверяваме дали ще има допълнителна отстъпка в зависимост от литрите
            if (liters > 25)
            {
                price *= 0.9;
            }
            else if (liters >= 20)
            {
                price *= 0.92;
            }
            Console.WriteLine($"{price:f2} lv.");

        }
    }
}
