using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Vacation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат:
            //      •	Пари нужни за екскурзията -реално число в интервала[1.00...25000.00]
            double moneyForTrip = double.Parse(Console.ReadLine());
            //      •	Налични пари -реално число в интервала[0.00...25000.00]
            double budget = double.Parse(Console.ReadLine());
            string action;
            double sum;
            int totalDays = 0;
            int spentDays = 0;
            //      След това многократно се четат по два реда:
            while (spentDays < 5)
            {
                //      •	Вид действие – текст с възможности "spend" и "save"
                action = Console.ReadLine();
                //      •	Сумата, която ще спести / похарчи - реално число в интервала[0.01… 25000.00]
                sum = double.Parse(Console.ReadLine());

                if (action == "spend")
                {
                    spentDays++;
                    if (budget >= sum)
                    {
                    budget -= sum;

                    }
                    else
                    {
                        budget = 0;
                    }
                }
                else
                {
                    spentDays = 0;
                    budget += sum;
                }
                totalDays++;
                if (budget >= moneyForTrip)
                {
                    Console.WriteLine($"You saved the money for {totalDays} days.");
                    return;
                }
            }
            Console.WriteLine($"You can't save the money.\n" +
                $"{totalDays}");

        }
    }
}
