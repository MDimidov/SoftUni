// See https://aka.ms/new-console-template for more information
using System;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //1. Четем входните данни и ги записваме в променливи от тип int
            // брой стр. в книгата, стр. за час, дните с които разполага
            int pages = int.Parse(Console.ReadLine());
            int pagePerHours = int.Parse(Console.ReadLine());
            int days = int.Parse(Console.ReadLine());

            //2. Изчисляваме общото време за четене на книгата: брой стр. / стр. за четене на час
            int totalHours = pages / pagePerHours;

            //3. Необходими часове на ден: общото време / дните с които разполага
            int hoursPerDay = totalHours / days;

            //4. Отпечатавне на резултата (Необходимите часове на ден)
            Console.WriteLine(hoursPerDay);
        }
    }
}