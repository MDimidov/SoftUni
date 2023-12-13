using System;
using System.Collections.Generic;
using System.Linq;

namespace _12.Trade_Commissions
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме от конзолата
            string town = Console.ReadLine();
            double sales = double.Parse(Console.ReadLine());

            double percent = 0;
            if (sales >= 0 && sales <= 500)
            {
                switch (town)
                {
                    case "Sofia":
                        percent = 0.05;
                        break;
                    case "Varna":
                        percent = 0.045;
                        break;
                    case "Plovdiv":
                        percent = 0.055;
                        break;
                }
            }
            else if (sales > 500 && sales <= 1000)
            {
                switch (town)
                {
                    case "Sofia":
                        percent = 0.07;
                        break;
                    case "Varna":
                        percent = 0.075;
                        break;
                    case "Plovdiv":
                        percent = 0.08;
                        break;
                }
            }
            else if (sales > 1000 && sales <= 10000)
            {
                switch (town)
                {
                    case "Sofia":
                        percent = 0.08;
                        break;
                    case "Varna":
                        percent = 0.10;
                        break;
                    case "Plovdiv":
                        percent = 0.12;
                        break;
                }
            }
            else if (sales > 10000)
            {
                switch (town)
                {
                    case "Sofia":
                        percent = 0.12;
                        break;
                    case "Varna":
                        percent = 0.13;
                        break;
                    case "Plovdiv":
                        percent = 0.145;
                        break;
                }
            }
            

            if (percent == 0)
                Console.WriteLine("error");
            else 
                Console.WriteLine("{0:0.00}",sales * percent);

        }
    }
}
