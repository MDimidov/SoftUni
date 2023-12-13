using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Hospital
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Входът се чете от конзолата и съдържа:
            //      •	На първия ред – периода, за който трябва да направите изчисления. Цяло число в интервала[1... 1000]
            int days = int.Parse(Console.ReadLine());

            int doctors = 7;
            int pacients;
            int treatedPacients = 0;
            int untreatedPacients = 0;
            //      •	На следващите редове(равни на броят на дните) – броя пациенти, които пристигат за преглед за текущия ден. Цяло число в интервала[0…10 000]
            for (int i = 1; i <= days; i++)
            {
                pacients = int.Parse(Console.ReadLine());
                if (i % 3 == 0 && untreatedPacients > treatedPacients)
                {
                    doctors++;
                }
                if (pacients <= doctors)
                treatedPacients += pacients;
                else
                {
                    treatedPacients += doctors;
                    untreatedPacients += pacients - doctors;
                }
            }
            Console.WriteLine($"Treated patients: {treatedPacients}.");
            Console.WriteLine($"Untreated patients: {untreatedPacients}.");
        }
    }
}
