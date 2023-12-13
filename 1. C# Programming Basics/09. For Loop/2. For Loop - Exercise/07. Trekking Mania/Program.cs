using System;
using System.Collections.Generic;
using System.Linq;

namespace _07.Trekking_Mania
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат поредица от числа, всяко на отделен ред:
            //      •	На първия ред – броя на групите от катерачи – цяло число в интервала[1...1000]
            int groups = int.Parse(Console.ReadLine());

            int peopleInGroup;
            int totalPeople = 0;

            int musala = 0;
            int monblan = 0;
            int kilimandjaro = 0;
            int k2 = 0;
            int everest = 0;
            //      •	За всяка една група на отделен ред – броя на хората в групата – цяло число в интервала[1...1000]
            for (int i = 0; i < groups; i++)
            {
                peopleInGroup = int.Parse(Console.ReadLine());

                totalPeople += peopleInGroup;
                
                if (peopleInGroup <= 5)
                    musala += peopleInGroup;
                else if (peopleInGroup >= 6 && peopleInGroup <= 12)
                    monblan += peopleInGroup;
                else if (peopleInGroup >= 13 && peopleInGroup <= 25)
                    kilimandjaro += peopleInGroup;
                else if (peopleInGroup >= 26 && peopleInGroup <= 40)
                    k2 += peopleInGroup;
                else
                    everest += peopleInGroup;
            }

            Console.WriteLine($"{(double)musala / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)monblan / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)kilimandjaro / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)k2 / totalPeople * 100:f2}%");
            Console.WriteLine($"{(double)everest / totalPeople * 100:f2}%");
        }
    }
}
