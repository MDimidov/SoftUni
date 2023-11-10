using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Special_Numbers
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());  //Въвеждаме входа

            for (int i = 1111; i <= 9999; i++)      // създаваме цикъл който да ни проверява в следния диапазон
            {
                int copy = i;           //запазваме стойността на текущото число в друга променлива
                bool isTrue = true;     //създаваме си флагче и приемаме, че числото е специално
                while (copy != 0)       //създаваме цикъл който да се върти, докато свършат цидрите в новата променива "copy"
                {
                    if (copy % 10 == 0) //числата няма как да се делят на 0 (n / 0 == error)
                    {
                        isTrue = false; //ако една от цифрите е нула, чеслото не е специално
                        break;
                    }
                    else if ((n % (copy % 10) != 0))    //проверяваме дали при делене на цифрата има остатък
                    {
                        isTrue = false;     //ако има остатък числото не е специално
                        break;
                    }
                    copy /= 10;     //намаляме копираното число с една цифра
                }
                if (isTrue)         // ако числото е специално
                {
                    Console.Write("{0} ", i);   //отпечатваме самото число 

                }
            }
        }
    }
}
