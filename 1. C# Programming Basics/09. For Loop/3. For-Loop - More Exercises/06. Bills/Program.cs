using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Bills
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We enter from the console
            //      - First line - months for each you search average expenses
            int months = int.Parse(Console.ReadLine());

            double allBills = 0;
            double electricityAll = 0;
            double water = 0;
            double internet = 0;
            double other = 0;

            //      - For each month - the electricity bill
            for (int i = 1; i <= months; i++)
            {
                double electricity = double.Parse(Console.ReadLine());

                electricityAll += electricity;
                water += 20;
                internet += 15;
                other += (electricity + 20 + 15) + 0.2 * (electricity + 20 + 15);
            }
                allBills = electricityAll + water + internet + other;
            
            Console.WriteLine($"Electricity: {electricityAll:f2} lv" +
                $"\nWater: {water:f2} lv" +
                $"\nInternet: {internet:f2} lv" +
                $"\nOther: {other:f2} lv" +
                $"\nAverage: {allBills / months:f2} lv");

        }
    }
}
