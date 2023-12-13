using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Report_System
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат:
            //      •	Сумата, която се очаква да бъде събрана от продажбите -цяло число в интервала[1... 10000]
            int expectedSum = int.Parse(Console.ReadLine());
            int sumCash = 0;
            int countCashPayments = 0;
            int sumCard = 0;
            int countCardPayments = 0;
            int actualSum = 0;
            int counter = 0;
            string input;

            //      На всеки следващ ред, до получаване на командата "End" или докато не се съберат нужните средства: цените на предметите, които ще бъдат закупени -цяло число в интервала[1... 500]
            while ((input = Console.ReadLine()) != "End")
            {
                counter++;
                actualSum = int.Parse(input);
                if (counter % 2 != 0)
                {
                    if (actualSum <= 100)
                    {
                        sumCash += actualSum;
                        expectedSum -= actualSum;
                        countCashPayments++;
                        Console.WriteLine($"Product sold!");
                    }
                    else
                    {
                        Console.WriteLine($"Error in transaction!");
                    }
                }
                else
                {
                    if (actualSum >= 10)
                    {
                        sumCard += actualSum;
                        expectedSum -= actualSum;
                        countCardPayments++;
                        Console.WriteLine($"Product sold!");
                    }
                    else
                    {
                        Console.WriteLine($"Error in transaction!");
                    }
                }

                if (expectedSum <= 0)
                {
                    Console.WriteLine($"Average CS: {(double)sumCash / countCashPayments:f2}\n" +
                        $"Average CC: {(double)sumCard / countCardPayments:f2}");
                    return;
                }
            }
            Console.WriteLine($"Failed to collect required money for charity.");

        }
    }
}
