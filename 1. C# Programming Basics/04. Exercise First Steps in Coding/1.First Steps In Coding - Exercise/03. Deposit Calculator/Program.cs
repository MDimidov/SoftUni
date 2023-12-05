// See https://aka.ms/new-console-template for more information
using System;
using System.Security.AccessControl;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем данните от конзолата 
            // - 1.	Депозирана сума – реално число 
            double deposit = double.Parse(Console.ReadLine());

            // - 2. Срок на депозита(в месеци) – цяло число int
            int term = int.Parse(Console.ReadLine());

            // - 3. Годишен лихвен процент – реално число double
            double rate = double.Parse(Console.ReadLine());

            //2. Изчисляваме сумата:
            //сума=депозит + срок на депозита * ((депозирана сума * годишен лихвен процент) / 12)
            double sum = deposit + term * ((deposit * rate / 100) / 12);

            //3. Отпечатваме резултата на конзолата (сума)
            Console.WriteLine(sum);
        }
    }
}