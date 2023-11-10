using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Train_The_Trainers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string presentationName;
            double grade;
            double sumPresentations = 0;
            int cntPresentations = 0;
            while ((presentationName = Console.ReadLine()) != "Finish")
            {
                double sumTeams = 0;
                for (int i = 0; i < n; i++)
                {
                    grade = double.Parse(Console.ReadLine());
                    sumTeams += grade;
                }
                Console.WriteLine($"{presentationName} - {sumTeams / n:f2}.");

                cntPresentations++;
                sumPresentations += sumTeams / n;
            }
            Console.WriteLine($"Student's final assessment is {sumPresentations / cntPresentations:f2}.");
        }
    }
}
