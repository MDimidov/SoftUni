namespace CarManufacturer
{
    public class StartUp
    {
        static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();
            List<Car> cars = new List<Car>();

            string input;
            while ((input = Console.ReadLine()) != "No more tires")
            {
                var tiresArr = new Tire[4];
                string[] arguments = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                for (int i = 0; i < tiresArr.Length; i++)
                {
                    Tire tire = new Tire(int.Parse(arguments[i * 2]), double.Parse(arguments[i * 2 + 1]));
                    tiresArr[i] = tire;
                }
                tires.Add(tiresArr);
            }

            while ((input = Console.ReadLine()) != "Engines done")
            {
                string[] arguments = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine engine = new(int.Parse(arguments[0]), double.Parse(arguments[1]));
                engines.Add(engine);
            }
            while ((input = Console.ReadLine()) != "Show special")
            {
                string[] arguments = input
                   .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = arguments[0];
                string model = arguments[1];
                int year = int.Parse(arguments[2]);
                double fuelQuantity = double.Parse(arguments[3]);
                double fuelConsumption = double.Parse(arguments[4]);
                int engineIndex = int.Parse(arguments[5]);
                int tiresIndex = int.Parse(arguments[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tiresIndex]);

                cars.Add(car);
            }


            double sum = tires[0].Sum(t => t.Pressure);

            List<Car> specialCars = cars
                .Where(c => c.Year >= 2017
                && c.Engine.HorsePower > 330
                && c.Tires.Sum(t => t.Pressure) >= 9
                && c.Tires.Sum(t => t.Pressure) <= 10)
                .ToList();

            foreach (Car specialCar in specialCars)
            {
                //Console.WriteLine(specialCar.ShowSpecial());
                specialCar.FuelQuantity -= specialCar.FuelConsumption * 20 / 100;
                Console.WriteLine($"Make: {specialCar.Make}");
                Console.WriteLine($"Model: {specialCar.Model}");
                Console.WriteLine($"Year: {specialCar.Year}");
                Console.WriteLine($"HorsePowers: {specialCar.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {specialCar.FuelQuantity}");
            }
        }
    }
}