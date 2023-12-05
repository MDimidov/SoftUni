using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Godzilla_vs.Kong
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            //          Ред 1.Бюджет за филма – реално число в интервала[1.00 … 1000000.00]
            //          Ред 2.Брой на статистите – цяло число в интервала[1 … 500]
            //          Ред 3.Цена за облекло на един статист – реално число в интервала[1.00 … 1000.00]
            double budget = double.Parse(Console.ReadLine());
            int extras = int.Parse(Console.ReadLine());
            double suitPrice = double.Parse(Console.ReadLine());

            //2. Съобразяваме се със следните условия
            //           •	Декорът за филма е на стойност 10 % от бюджета.
            //           •	При повече от 150 статиста,  има отстъпка за облеклото на стойност 10 %.
            double decor = budget * 0.1;
            double priceForExtras = extras*suitPrice;
            if (extras > 150)
            {
                //discount
                priceForExtras -= priceForExtras * 0.1;
            }
            double total = priceForExtras + decor;

            double difference = budget - total;
            if (difference >= 0)
            {
                Console.WriteLine("Action!");
                Console.WriteLine($"Wingard starts filming with {difference:f2} leva left.");
            }
            else
            {
                Console.WriteLine("Not enough money!");
                Console.WriteLine($"Wingard needs {Math.Abs(difference):f2} leva more.");
            }


        }
    }
}
