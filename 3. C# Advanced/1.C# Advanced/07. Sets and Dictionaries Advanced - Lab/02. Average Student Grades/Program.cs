using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Average_Student_Grades
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Dictionary<string, List<decimal>> studentsGrade = new Dictionary<string, List<decimal>>();
            
            for(int i = 0; i < n; i++)
            {
                string[] studentInfo = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string name = studentInfo[0];
                decimal grade = decimal.Parse(studentInfo[1]);

                if (!studentsGrade.ContainsKey(name))
                {
                    studentsGrade[name] = new List<decimal>();
                }
                studentsGrade[name].Add(grade);
            }

            foreach(var (student, grades) in studentsGrade)
            {
                Console.Write($"{student} ->");
                foreach(decimal grade in grades)
                {
                    Console.Write($" {grade:f2}"); 
                }
                Console.WriteLine($" (avg: {grades.Average():f2})");
            }
        }
    }
}
