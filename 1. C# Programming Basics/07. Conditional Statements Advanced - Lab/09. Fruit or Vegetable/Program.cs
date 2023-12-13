using System;
using System.Collections.Generic;
using System.Linq;

namespace _09.Fruit_or_Vegetable
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            string product = Console.ReadLine();

            //2. Изпълняваме следните условия
            //      •	Плодовете "fruit" имат следните възможни стойности:  banana, apple, kiwi, cherry, lemon и grapes
            //      •	Зеленчуците "vegetable" имат следните възможни стойности:  tomato, cucumber, pepper и carrot
            //      •	Всички останали са "unknown"
            if (product == "banana" || product == "apple" || product == "kiwi" || product == "cherry" || product == "lemon" || product == "grapes")
            {
                Console.WriteLine("fruit");
            }
            else if (product == "tomato" || product == "cucumber" || product == "pepper" || product == "carrot")
                Console.WriteLine("vegetable");
            else
            {
                Console.WriteLine("unknown");
            }


        }
    }
}
