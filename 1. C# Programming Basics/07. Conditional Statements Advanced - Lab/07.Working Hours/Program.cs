using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Working_Hours
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме в конзолата
            //      - час
            //      - ден
            int hour = int.Parse(Console.ReadLine());
            string day = Console.ReadLine();
            string working = "";

            //2. Съобразяваме се с работното време на магазина
            if (hour >= 10 && hour <= 18)
            {
                switch (day)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                    case "Saturday":
                        working = "open";
                        break;
                    default:
                        working = "closed";
                        break;
                }
            }
            else
            {
                working = "closed";
            }

            Console.WriteLine(working);
        }
    }
}
