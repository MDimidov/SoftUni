namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            Car car = new Car();

            car.Make = "VW";
            car.Model = "Passat";
            car.Year = 2022;

            Console.WriteLine($"Make: {car.Make}\n" +
                $"Model: {car.Model}\n" +
                $"Year: {car.Year}");
        }
    }
}
