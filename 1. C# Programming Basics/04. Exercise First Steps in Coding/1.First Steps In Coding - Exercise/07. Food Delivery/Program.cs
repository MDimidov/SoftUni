// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем данните от конзолата
                //•	Брой пилешки менюта – int
            int chickenQ = int.Parse(Console.ReadLine());
                //•	Брой менюта с риба – int
            int fishQ = int.Parse(Console.ReadLine());
                //•	Брой вегетариански менюта – int
            int veganQ = int.Parse(Console.ReadLine());


            //2. Пресмятаме цената за всяко меню
                 //•	Пилешко меню –  10.35 лв.
            double chickenPrice = chickenQ * 10.35;
                 //•	Меню с риба – 12.40 лв.
            double fishPrice = fishQ * 12.4;
                 //•	Вегетарианско меню  – 8.15 лв.
            double veganPrice = veganQ * 8.15;
            double totalPrice = chickenPrice + fishPrice + veganPrice;
                 //•	Десерта е 20% от общата сметка
            double dessert = 0.2 * totalPrice;
            double delivery = 2.5;

            //3. Намираме общата сума с десерт и доставка
            double Total = totalPrice + dessert + delivery;

            //4. Отпечатваме крайния резултат
            Console.WriteLine(Total);
        }
    }
}