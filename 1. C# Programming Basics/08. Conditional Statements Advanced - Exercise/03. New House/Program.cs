    using System;

    namespace _03._New_House
    {
        internal class Program
        {
            static void Main(string[] args)
            {
                //1. От конзолата се чете
                //      •	Вид цветя -текст с възможности -"Roses", "Dahlias", "Tulips", "Narcissus", "Gladiolus"
                string flowers = Console.ReadLine();
                //      •	Брой цветя -цяло число в интервала[10…1000]
                int quantity = int.Parse(Console.ReadLine());
                //      •	Бюджет - цяло число в интервала[50…2500]
                int budget = int.Parse(Console.ReadLine());


                //2. Определяме цената за всяко цвете
                double price = 0;
                switch (flowers)
                {
                    case "Roses":
                        price = 5;
                        break;
                    case "Dahlias":
                        price = 3.8;
                        break;
                    case "Tulips":
                        price = 2.8;
                        break;
                    case "Narcissus":
                        price = 3.0;
                        break;
                    case "Gladiolus":
                        price = 2.5;
                        break;
                }

                double totalPrice = price * quantity;
                //3. Съществуват следните отстъпки:
                //      •	Ако Нели Купи по-малко от 80 Гладиоли - цената се оскъпява с 20 %
                if (quantity < 80 && flowers == "Gladiolus")
                {
                    totalPrice += totalPrice * 0.2;
                }
                //      •	Ако Нели купи повече от 80 Рози - 10 % отстъпка от крайната цена
                else if (quantity > 80 && flowers == "Roses")
                {
                    totalPrice -= totalPrice * 0.1;
                }
                //      •	Ако Нели купи повече от 80 Лалета - 15 % отстъпка от крайната цена
                //      •	Ако Нели купи повече от 90  Далии - 15 % отстъпка от крайната цена
                else if ((quantity > 80 && flowers == "Tulip") || (quantity > 90 && flowers == "Dahlias"))
                {
                    totalPrice -= totalPrice * 0.15;

                }
                //      •	Ако Нели купи по-малко от 120 Нарциса - цената се оскъпява с 15 %
                else if (quantity < 120 && flowers == "Narcissus")
                {
                    totalPrice += totalPrice * 0.15;
                }
                

                double sum = budget - totalPrice;
                if (sum>=0)
                {
                    Console.WriteLine($"Hey, you have a great garden with {quantity} {flowers} and {sum:f2} leva left.");
                }
                else
                {
                    Console.WriteLine($"Not enough money, you need {-sum:f2} leva more.");
                }




            }
        }
    }
