using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Equal_Sums_Even_Odd_Position
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n1 = int.Parse(Console.ReadLine());
            int n2 = int.Parse(Console.ReadLine());

            for (int i = n1; i <= n2; i++)
            {
                //Знаем, че работим само със 6цифрени числа следователно крайното чилсо винаги е четно
                int evenNum = i % 10;       // вземаме стойността на последната цифра
                int leftNum = i / 10;       // премахваме последната цифра от 6-цифреното число и остават 5 цифри
                int oddNum = leftNum % 10;  // вземаме стойнстта на предпоследната цифра
                int evenSum = evenNum;      // добавяме стойността на последното число към четната сума
                int oddSum = oddNum;        // добавяме стойността на предпоследното число към нечетната сума

                //аналогично продъжаваме в един вътрешен цикъл, докато от 6-цифреното число не остане само 0с
                while (leftNum != 0)
                {
                    leftNum /= 10;
                    evenNum = leftNum % 10;
                    leftNum /= 10;
                    oddNum = leftNum % 10;
                    evenSum += evenNum;
                    oddSum += oddNum;
                }
                // ако сумата на четни и нечетни са равни отпечатваме числото
                if (evenSum == oddSum)
                {
                    Console.Write($"{i} ");
                }
            }
        }
    }
}
