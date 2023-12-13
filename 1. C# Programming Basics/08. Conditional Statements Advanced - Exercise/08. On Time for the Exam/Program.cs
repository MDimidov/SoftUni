using System;

namespace _08._On_Time_for_the_Exam
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. От конзолата се четат 4 цели числа (по едно на ред), въведени от потребителя:
            //      •	Първият ред съдържа час на изпита – цяло число от 0 до 23.
            int hourExam = int.Parse(Console.ReadLine());
            //      •	Вторият ред съдържа минута на изпита – цяло число от 0 до 59.
            int minuteExam = int.Parse(Console.ReadLine());
            //      •	Третият ред съдържа час на пристигане – цяло число от 0 до 23.
            int hourArrive = int.Parse(Console.ReadLine());
            //      •	Четвъртият ред съдържа минута на пристигане – цяло число от 0 до 59.
            int minuteArrive = int.Parse(Console.ReadLine());

            //2. Преобразуваме часовете в минути и ги обединяваме с минутите
            int totalMinExam = hourExam * 60 + minuteExam;
            int totalMinArrive = hourArrive * 60 + minuteArrive;
            int hh = Math.Abs(totalMinArrive - totalMinExam) / 60;
            int mm = totalMinExam - totalMinArrive;
            int mmm = mm;
            if (Math.Abs(mm) >= 60)
            {
                mmm = mm % 60;
            }
            string time = "";
            string end = "";

            if (mm < 0)
            {
                time = "Late";
                if (Math.Abs(mm) < 60)
                    end = $"{Math.Abs(mmm)} minutes after the start";
                else
                    end = $"{hh}:{Math.Abs(mmm):00} hours after the start";
            }
            else if (mm >= 0 && mm <= 30)
            {
                time = "On time";
                if (Math.Abs(mm) < 60 && mm != 0)
                    end = $"{Math.Abs(mmm)} minutes before the start";
                //else
                //    end = $"{hh}:{Math.Abs(mm)} hours after the start";

            }
            else
            {
                time = "Early";
                if (Math.Abs(mm) < 60)
                    end = $"{Math.Abs(mmm)} minutes before the start";
                else
                    end = $"{hh}:{Math.Abs(mmm):00} hours before the start";

            }

            Console.WriteLine($"{time}\n{end}");


        }
    }
}
