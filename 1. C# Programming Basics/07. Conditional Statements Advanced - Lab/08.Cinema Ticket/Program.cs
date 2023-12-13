using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Cinema_Ticket
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string day = Console.ReadLine();

            int price = 0;
            switch (day)
            {
                case "Monday":
                case "Tuesday":
                case "Friday":
                    price = 12;
                        break;
                case "Wednesday":
                case "Thursday":
                    price = 14;
                        break;
                case "Saturday":
                case "Sunday":
                    price = 16;
                        break;
            }
            if (price != 0)
            Console.WriteLine(price);

        }
    }
}
