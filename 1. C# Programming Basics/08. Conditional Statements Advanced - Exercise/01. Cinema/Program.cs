using System;

namespace _01._Cinema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      - тип прожекци
            string projection = Console.ReadLine();
            //      - брой редове
            int rows = int.Parse(Console.ReadLine());
            //      - брой колони
            int columns = int.Parse(Console.ReadLine());

            //2. Съобразяваме се със следните условия
            //      •	Premiere – премиерна прожекция, на цена 12.00 лева.
            //      •	Normal – стандартна прожекция, на цена 7.50 лева.
            //      •	Discount – прожекция за деца, ученици и студенти на намалена цена от 5.00 лева.

            double price = 0;
            if (projection == "Premiere")
            {
                price = 12;
            }
            else if (projection == "Normal")
            {
                price = 7.5;
            }
            else
            {
                price = 5;
            }

            double total = price * rows * columns;
            Console.WriteLine($"{total:f2} leva");


        }
    }
}
