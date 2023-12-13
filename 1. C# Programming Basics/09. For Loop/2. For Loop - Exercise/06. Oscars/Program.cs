using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Oscars
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      •	Име на актьора - текст
            string nameActor = Console.ReadLine();
            //      •	Точки от академията - реално число в интервала[2.0... 450.5]
            double pointsAccademy = double.Parse(Console.ReadLine());
            //      •	Брой оценяващи n - цяло число в интервала[1… 20]
            int n = int.Parse(Console.ReadLine());
            //      На следващите n - на брой реда:

            double pointsJury;
            string nameJury;
            double sumPoints = pointsAccademy;
            string print = "";
            for (int i = 0; i < n; i++)
            {
            //      o Име на оценяващия -текст
                nameJury = Console.ReadLine();
            //      o Точки от оценяващия -реално число в интервала[1.0... 50.0]
                pointsJury = double.Parse(Console.ReadLine());
                sumPoints += nameJury.Length * (double)pointsJury / 2;
                if (sumPoints >= 1250.5)
                {
                    print = $"Congratulations, {nameActor} got a nominee for leading role with {sumPoints:f1}!";
                    break;
                }
                else
                {
                    print = $"Sorry, {nameActor} you need {1250.5 - sumPoints:f1} more!";
                }
            }
            Console.WriteLine(print);

        }
    }

}
