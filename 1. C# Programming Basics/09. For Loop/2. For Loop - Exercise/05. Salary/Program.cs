using System;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;

namespace _05.Salary
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат два реда:
            //      •	Брой отворени табове в браузъра n -цяло число в интервала[1...10]
            int tabs = int.Parse(Console.ReadLine());
            //      •	Заплата - число в интервала[500...1500]
            int salary = int.Parse(Console.ReadLine());

            int sum = 0;
            string site;
            //      След това n – на брой пъти се чете име на уебсайт – текст
            for (int i = 1; i <= tabs; i++)
            {
                site = Console.ReadLine();
                if (site == "Facebook")
                    sum += 150;
                else if (site == "Instagram")
                    sum += 100;
                else if (site == "Reddit")
                    sum += 50;
                if (sum >= salary)
                {
                    //site = "You have lost your salary.";
                    break;
                }
            }
            
            if (sum >= salary)
            {
            Console.WriteLine("You have lost your salary.");

            }
            else
            {
                Console.WriteLine(salary - sum);
            }

            



        }
    }
}
