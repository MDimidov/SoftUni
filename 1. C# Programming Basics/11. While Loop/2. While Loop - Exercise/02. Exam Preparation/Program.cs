using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Exam_Preparation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. We read from the console
            //  - how many bad marks he can has
            int badMarks = int.Parse(Console.ReadLine());
            //  - name of the exercise
            string exerciseName = "";
            //  - the result for the last exercise
            double mark = 0;

            double markSum = 0;
            int totalExercises = 0;
            int totalBadMarks = 0;
            string lastExersice = "";

            while ((exerciseName = Console.ReadLine()) != "Enough")
            {
                mark = double.Parse(Console.ReadLine());
                if (mark <= 4)
                {
                    totalBadMarks++;
                }
                if (totalBadMarks == badMarks)
                {
                    Console.WriteLine($"You need a break, {totalBadMarks} poor grades.");
                    return;
                }
                markSum += mark;
                totalExercises++;
                lastExersice = exerciseName;
            }

            Console.WriteLine($"Average score: {markSum / totalExercises:f2}\n" +
                $"Number of problems: {totalExercises}\n" +
                $"Last problem: {lastExersice}");
        }
    }
}
