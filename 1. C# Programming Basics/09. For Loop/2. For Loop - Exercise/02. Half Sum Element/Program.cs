using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Half_Sum_Element
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Брой числа въведени от потребителя
            int n = int.Parse(Console.ReadLine());

            //2. Създаваме променлива, която да пазси сумата от всички числа
            int sum = 0;
            //3. Създаваме променлива, която да пази най-голялмото въведено число до момента
            int max = int.MinValue;
            //4. Създаваме променлива, която да пази последното въведено число
            int lastNum = 0;
            //5. фор цикъл
            for (int i = 0; i < n; i++)
            {
                int num = int.Parse(Console.ReadLine());
                if (max < num)
                {
                    max = num;
                }
                sum += num;
                lastNum = num;
            }
            if (sum - max == max)
            {
                Console.WriteLine($"Yes\nSum = {max}");
            }
            else
            {
                Console.WriteLine($"No\nDiff = {Math.Abs(max - (sum - max))}");
            }
        }
    }
}
