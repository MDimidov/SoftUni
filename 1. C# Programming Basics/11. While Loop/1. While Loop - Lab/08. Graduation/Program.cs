using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Graduation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string name = Console.ReadLine();
            int counter = 0;
            double sum = 0;
            double grade;
            int failed = 0;
            while (counter < 12)
            {
                grade = double.Parse(Console.ReadLine());
                sum += grade;
                counter++;

                if (grade < 4)
                {
                    failed++;
                    if (failed > 1)
                    {
                        Console.WriteLine($"{name} has been excluded at {--counter} grade");
                        return;
                    }
                }

            }
                Console.WriteLine($"{name} graduated. Average grade: {sum / counter:f2}");
        }
    }
}
