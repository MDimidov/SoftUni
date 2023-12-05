using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace _04.Transport_Price
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме от конзолата
            //      •	Първият ред съдържа числото n – брой километри – цяло число в интервала[1…5000]
            int km = int.Parse(Console.ReadLine());
            //      •	Вторият ред съдържа дума “day” или “night” – пътуване през деня или през нощта
            string tripTime = Console.ReadLine();

            double total = 0;

            //2. Съобразяваме се със следните условия:
            if (km >= 100)
            {
                //      •	Влак.Дневна / нощна тарифа: 0.06 лв. / км.Може да се използва за разстояния минимум 100 км.
                total = km * 0.06;
            }
            else if (km >= 20)
            {
                //      •	Автобус.Дневна / нощна тарифа: 0.09 лв. / км.Може да се използва за разстояния минимум 20 км.
                total = (km * 0.09);
            }
            else
            {
                //      •	Такси.Начална такса: 0.70 лв.Дневна тарифа: 0.79 лв. / км.Нощна тарифа: 0.90 лв. / км.
                if (tripTime == "day")
                {
                    total = km * 0.79 + 0.7;
                }
                else
                {
                    total = km * 0.9 + 0.7;
                }
            }

            Console.WriteLine($"{total:f2}");



        }
    }
}
