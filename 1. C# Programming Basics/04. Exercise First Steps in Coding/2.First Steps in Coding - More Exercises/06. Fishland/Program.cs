// See https://aka.ms/new-console-template for more information
// See https://aka.ms/new-console-template for more information
using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double c1 = double.Parse(Console.ReadLine()); //цена скумрия за кг.
            double c2 = double.Parse(Console.ReadLine()); //цена цаца за кг.
            double kg1 = double.Parse(Console.ReadLine()); //Паламуд в кг.
            double kg2 = double.Parse(Console.ReadLine()); //Сафрид в кг.
            double kg3 = double.Parse(Console.ReadLine()); //Миди в кг.

            double c3 = 0.6 * c1 + c1; //цена палумуд за кг.
            double c4 = 0.8 * c2 + c2; //цена сафрид за кг.

            double total = kg1 * c3 + kg2 * c4 + kg3 * 7.5; //общата сметка


            Console.WriteLine(String.Format("{0:0.00}", total));

        }
    }
}