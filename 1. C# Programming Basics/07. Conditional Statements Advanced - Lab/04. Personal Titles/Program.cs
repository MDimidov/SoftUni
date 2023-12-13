using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Personal_Titles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //1. Четем от конзолата
            //      - възраст
            double age = double.Parse(Console.ReadLine());
            //      - пол
            string gender = Console.ReadLine();

            string text = "";

            //2. Съобразяваме се със следните условия
            //      •	"Mr." – мъж(пол 'm') на 16 или повече години
            //      •	"Master" – момче(пол 'm') под 16 години
            //      •	"Ms." – жена(пол 'f') на 16 или повече години
            //      •	"Miss" – момиче(пол 'f') под 16 години

            if (gender == "m")
            {
                if (age >= 16)
                {
                    text = "Mr.";
                }
                else
                {
                    text = "Master";
                }
            }

            if (gender == "f")
            {
                if (age >= 16)
                {
                    text = "Ms.";
                }
                else
                {
                    text = "Miss";
                }
            }

            Console.WriteLine(text);




        }
    }
}
