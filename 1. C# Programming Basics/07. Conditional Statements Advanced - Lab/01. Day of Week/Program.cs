using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Day_of_Week
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int dayOfWeek = int.Parse(Console.ReadLine());
            string day = "";
            switch (dayOfWeek)
            {
                case 1:
                    day = "Monday";
                        break;
                    case 2:
                    day = "Tuesday";
                    break;

                case 3:
                    day = "Wednesday";
                    break ;

                    case 4:
                    day = "Thursday";
                    break;
                case 5:
                    day = "Friday";
                    break;
                case 6:
                    day = "Saturday";
                    break;
                case 7:
                    day = "Sunday";
                    break;
                    default:
                    day = "Error";
                    break;
            }
            Console.WriteLine(day);
        }
    }
}
