using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Day_of_Week
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string dayOfWeek = Console.ReadLine();
                string day = "";
                switch (dayOfWeek)
                {
                    case "Monday":
                    case "Tuesday":
                    case "Wednesday":
                    case "Thursday":
                    case "Friday":
                        day = "Working day";
                        break;
                    case "Saturday":
                    case "Sunday":
                        day = "Weekend";
                        break;
                    default:
                        day = "Error";
                        break;
                }
                Console.WriteLine(day);
            }
        }
    }

