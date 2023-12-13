using System;

namespace _09._Ski_Trip1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Входът се чете от конзолата и се състои от три реда:
            //      •	Първи ред -дни за престой -цяло число в интервала[0...365]
            int days = int.Parse(Console.ReadLine());
            //      •	Втори ред -вид помещение - "room for one person", "apartment" или "president apartment"
            string room = Console.ReadLine();
            //      •	Трети ред -оценка - "positive"  или "negative"
            string assessment = Console.ReadLine();

            days--;
            //2. Съобразяваме се с останалата част от условието
            double price = 0;
            if(room == "room for one person")
            {
                price = days * 18.0;
            }
            else if (room == "apartment")
            {
                price = days * 25.0;
                if (days < 10)
                    price -= price * 0.3;
                else if (days >= 10 && days <= 15)
                    price -= price * 0.35;
                else price -= price * 0.5;
            }
            else
            {
                price = days * 35.0;
                if (days < 10)
                    price -= price * 0.1;
                else if (days >= 10 && days <= 15)
                    price -= price * 0.15;
                else price -= price * 0.2;
            }
            if (assessment == "positive")
                price += price * 0.25;
            else price -= price * 0.1;
            Console.WriteLine("{0:f2}", price);


        }
    }
}
