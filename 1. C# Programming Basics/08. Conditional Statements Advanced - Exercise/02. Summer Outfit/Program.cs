using System;

namespace _02._Summer_Outfit
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Въвеждаме от конзолата
            //      •	Градусите - цяло число в интервала[10…42]
            int degrees = int.Parse(Console.ReadLine());
            //      •	Текст, време от денонощието - с възможности - "Morning", "Afternoon", "Evening"
            string timeOfDay = Console.ReadLine();

            string outfit = "";
            string shoes = "";

            //2. Съобразяваме се с условията
            if (degrees >= 10 && degrees <= 18)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "Sweatshirt";
                        shoes = "Sneakers";
                        break;
                    case "Afternoon":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            else if (degrees > 18 && degrees <= 24)
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                    case "Afternoon":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }
            else
            {
                switch (timeOfDay)
                {
                    case "Morning":
                        outfit = "T-Shirt";
                        shoes = "Sandals";
                        break;
                    case "Afternoon":
                        outfit = "Swim Suit";
                        shoes = "Barefoot";
                        break;
                    case "Evening":
                        outfit = "Shirt";
                        shoes = "Moccasins";
                        break;
                }
            }

            Console.WriteLine($"It's {degrees} degrees, get your {outfit} and {shoes}.");

        }
    }
}
