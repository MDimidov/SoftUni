using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.SoftUni_Exam_Results
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var judgeSubmissions = new SortedDictionary<string, Dictionary<string, int>>();
            var languageTotalPoints = new SortedDictionary<string, int>();

            string input;
            while ((input = Console.ReadLine()) != "exam finished")
            {
                string[] submissionInfo = input
                    .Split('-', StringSplitOptions.RemoveEmptyEntries);
                string username = submissionInfo[0];
                string languageOrCommand = submissionInfo[1];
                if(languageOrCommand == "banned"
                    && judgeSubmissions.ContainsKey(username))
                {
                    judgeSubmissions.Remove(username);
                }
                else if(languageOrCommand != "banned")
                {
                    int points = int.Parse(submissionInfo[2]);
                    if(!judgeSubmissions.ContainsKey(username))
                    {
                        judgeSubmissions[username] = new Dictionary<string, int>();
                        judgeSubmissions[username][languageOrCommand] = points;
                    }
                    if(judgeSubmissions[username][languageOrCommand] < points)
                    {
                        judgeSubmissions[username][languageOrCommand] = points;
                    }

                    if (!languageTotalPoints.ContainsKey(languageOrCommand))
                    {
                        languageTotalPoints[languageOrCommand] = 0;
                    }
                    languageTotalPoints[languageOrCommand]++;
                }
            }

            Console.WriteLine("Results:");
            foreach(var (username, langPoints) in judgeSubmissions
                .OrderByDescending(x => x.Value.Values.Sum()))
            {
                Console.WriteLine(username + " | " + langPoints.Values.Sum());
            }
            Console.WriteLine("Submissions:");
            foreach(var (langugage, points) in languageTotalPoints
                .OrderByDescending(x => x.Value))
            {
                Console.WriteLine(langugage + " - " + points);
            }
        }
    }
}
