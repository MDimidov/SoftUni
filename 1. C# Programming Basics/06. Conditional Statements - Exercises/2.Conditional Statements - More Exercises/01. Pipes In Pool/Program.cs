using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Pipes_In_Pool
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Въвеждаме от конзолата
            //      •	Първият ред съдържа числото V – Обем на басейна в литри – цяло число в интервала[1…10000].
            int V = int.Parse(Console.ReadLine());
            //      •	Вторият ред съдържа числото P1 – дебит на първата тръба за час – цяло число в интервала[1…5000].
            int P1 = int.Parse(Console.ReadLine());
            //      •	Третият ред съдържа числото P2 – дебит на втората тръба за час– цяло число в интервала[1…5000].
            int P2 = int.Parse(Console.ReadLine());
            //      •	Четвъртият ред съдържа числото H – часовете които работникът отсъства – реално число в интервала[1.0…24.00]
            double H = double.Parse(Console.ReadLine());

            //2. Колко литра се е напълнил басейна
            double V2 = P1 * H + P2 * H;
            double percentP1 = Math.Round((P1 * H) / V2 * 100, 2);
            double percentP2 = 100 - percentP1;
            double percentV2 = V2 / V * 100;

            
            if (V2 <= V)
            {
                Console.WriteLine($"The pool is {percentV2:f2}% full. Pipe 1: {percentP1:f2}%. Pipe 2: {percentP2:f2}%.");
            }
            else
            {
                Console.WriteLine($"For {H:f2} hours the pool overflows with {V2 - V:f2} liters.");
            }



        }
    }
}
