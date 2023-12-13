using System;
using System.Collections.Generic;
using System.Linq;

namespace _08.Tennis_Ranklist
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. От конзолата първо се четат два реда:
            //      •	Брой турнири, в които е участвал – цяло число в интервала[1…20] 
            int tournaments = int.Parse(Console.ReadLine());
            //      •	Начален брой точки в ранглистата - цяло число в интервала[1...4000]
            int initialPoints = int.Parse(Console.ReadLine());

            string round;
            int wins = 0;
            int totalPoints = initialPoints;
            //      За всеки турнир се прочита отделен ред:
            //      •	Достигнат етап от турнира – текст – "W", "F" или "SF"
            for (int i = 0; i < tournaments; i++)
            {
                round = Console.ReadLine();
                if (round == "W")
                {
                    totalPoints += 2000;
                    wins++;
                }
                else if (round == "F")
                {
                    totalPoints += 1200;
                }
                else
                {
                    totalPoints += 720;
                }
            }
            Console.WriteLine($"Final points: {totalPoints}");
            Console.WriteLine($"Average points: {Math.Floor(((double)totalPoints - initialPoints) / tournaments)}");
            Console.WriteLine($"{(double)wins / tournaments * 100:f2}%");

        }
    }
}
