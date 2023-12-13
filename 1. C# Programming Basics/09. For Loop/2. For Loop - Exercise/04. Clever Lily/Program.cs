using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Clever_Lily
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Програмата прочита 3 числа, въведени от потребителя, на отделни редове:
            //      •	Възрастта на Лили - цяло число в интервала[1...77]
            int age = int.Parse(Console.ReadLine());
            //      •	Цената на пералнята - число в интервала[1.00...10 000.00]
            double washingMachinePrice = double.Parse(Console.ReadLine());
            //      •	Единична цена на играчка -цяло число в интервала[0...40]
            int toyPrice = int.Parse(Console.ReadLine());

            int evenAge = 0;
            int sum = 0;
            int toys = 0;
            double totalSum = 0;

            for (int i = 1; i <= age; i++)
            {
                if (i % 2 == 0)
                {
                    sum += 10 * i / 2;
                    evenAge++;
                }
                else
                {
                    toys++;
                }
            }
            totalSum = sum + (toys * toyPrice) - evenAge;

            double diff = totalSum - washingMachinePrice;
            if (diff >= 0)
            {
                Console.WriteLine($"Yes! {diff:f2}");
            }
            else
                Console.WriteLine($"No! {-diff:f2}");


        }
    }
}
