using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.Bonus_Score
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме началните бонус точки
            int points = int.Parse(Console.ReadLine());
            double bonus = 0;
            double total = 0;

            //2. Съобразяваме се със следните условия
            //      •	Ако числото е до 100 включително, бонус точките са 5.
            if (points <= 100)
            {
                bonus = bonus + 5;
            }
            //      •	Ако числото е по-голямо от 1000, бонус точките са 10 % от числото.
            else if (points > 1000)
            {
                bonus = 0.1 * points + bonus;
            }
            //      •	Ако числото е по-голямо от 100, бонус точките са 20 % от числото.
            else
            {
                bonus = 0.2 * points + bonus;
            }

            //      •	Допълнителни бонус точки (начисляват се отделно от предходните):
            //            o За четно число  +1 т.
            if (points % 2 == 0)
            {
                bonus++;
            }
            //            o За число, което завършва на 5  +2 т.
            else if (points % 5 == 0)
            {
                bonus = bonus + 2;
            }

            total = bonus + points;
            Console.WriteLine(bonus);
            Console.WriteLine(total);


        }
    }
}
