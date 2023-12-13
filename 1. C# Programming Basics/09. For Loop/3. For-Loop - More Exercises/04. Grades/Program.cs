using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Grades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата се четат поредица от числа, всяко на отделен ред:
            //      •	На първия ред – броя на студентите явили се на изпит – цяло число в интервала[1...1000]
            int students = int.Parse(Console.ReadLine());
            

            int fail = 0;
            int bad = 0;
            int good = 0;
            int excellent = 0;
            double averageScore = 0;
            double score;
            //      •	За всеки един студент на отделен ред – оценката от изпита – реално число в интервала[2.00...6.00]
            for (int i = 1; i <= students; i++)
            {
                score = double.Parse(Console.ReadLine());
                if (score >= 2 && score <= 2.99)
                    fail++;
                else if (score >= 3 && score <= 3.99)
                    bad++;
                else if (score >= 4 && score <= 4.99)
                    good++;
                else
                    excellent++;
                averageScore += score;
            }
            Console.WriteLine($"Top students: {(double)excellent / students * 100:f2}%");
            Console.WriteLine($"Between 4.00 and 4.99: {(double)good / students * 100:f2}%");
            Console.WriteLine($"Between 3.00 and 3.99: {(double)bad / students * 100:f2}%");
            Console.WriteLine($"Fail: {(double)fail / students * 100:f2}%");
            Console.WriteLine($"Average: {averageScore / students:f2}");

        }
    }
}
