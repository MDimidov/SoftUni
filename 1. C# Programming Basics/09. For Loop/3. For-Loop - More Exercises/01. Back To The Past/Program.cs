using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _01.Back_To_The_Past
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Входът се чете от конзолата и съдържа точно 2 реда:
            //      •	Наследените пари – реално число в интервала[1.00... 1 000 000.00]
            double inheritedMoney = double.Parse(Console.ReadLine());
            //      •	Годината, до която трябва да живее(включително) – цяло число в интервала[1801... 1900]
            int lastYear = int.Parse(Console.ReadLine());

            double leftMoney = inheritedMoney;
            int age = 18;

            for (int year = 1800; year <= lastYear; year++)
            {
                if (year % 2 == 0)
                {
                    leftMoney -= 12000;
                }
                else
                {
                    leftMoney -= (12000 + 50 * age);
                }
                age++;
            }
            if (leftMoney >= 0)
                Console.WriteLine($"Yes! He will live a carefree life and will have {leftMoney:f2} dollars left.");
            else
                Console.WriteLine($"He will need {-leftMoney:f2} dollars to survive.");


        }
    }
}
