using System;
using System.Text;

namespace _07._Hotel_Room
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Входът се чете от конзолата и съдържа точно 2 реда, въведени от потребителя:
            //      •	На първия ред е месецът – May, June, July, August, September или October
            string month = Console.ReadLine();
            //      •	На втория ред е броят на нощувките – цяло число в интервала[0... 200]
            int nights = int.Parse(Console.ReadLine());

            double studio = 0;
            double apartment = 0;

            //2. Съобразяваме се с условията
            if (month == "May" || month == "October")
            {
                studio = 50;
                apartment = 65;
                if (nights > 14)
                {
                    studio -= studio * 0.3;
                }
                else if (nights >7)
                {
                    studio -= studio * 0.05;
                }
            }
            else if (month == "June" || month == "September")
            {
                studio = 75.2;
                apartment = 68.7;
                if (nights > 14)
                    studio -= studio * 0.2;
            }
            else
            {
                studio = 76;
                apartment = 77;
            }
            if (nights > 14)
                apartment -= apartment * 0.1;

            Console.WriteLine($"Apartment: {nights*apartment:f2} lv.\nStudio: {nights*studio:f2} lv.");


        }
    }
}
