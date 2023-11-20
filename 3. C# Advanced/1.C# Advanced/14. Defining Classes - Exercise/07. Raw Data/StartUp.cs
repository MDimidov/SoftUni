namespace DefiningClasses;

public class StartUp
{
    private static void Main()
    {
        List<Car> cars = new();

        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            string[] cmdArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Tire[] tires = new Tire[4];
            string model = cmdArg[0];
            int engineSpeed = int.Parse(cmdArg[1]);
            int enginePower = int.Parse(cmdArg[2]);
            int cargoWeight = int.Parse(cmdArg[3]);
            string cargoType = cmdArg[4];
            
            Engine engine = new(engineSpeed, enginePower);
            Cargo cargo = new(cargoType, cargoWeight);


            for(int j = 0; j < tires.Length; j++)
            {
                double tirePressure = double.Parse(cmdArg[j * 2 + 5]);
                int tireAge = int.Parse(cmdArg[j * 2 + 6]);

                tires[j] = new Tire(tireAge, tirePressure);
            }

            double fuelConsumptionFor1km = double.Parse(cmdArg[2]);

            Car car = new Car(model, engine, cargo, tires);
            cars.Add(car);  

        }

        string command = Console.ReadLine();
        
        if(command == "fragile")
        {
            cars = cars
                .Where(c => c.Tires.Any(t => t.Pressure < 1))
                .ToList();
        }
        else
        {
            cars = cars
                .Where(c => c.Engine.Power > 250)
                .ToList();
        }

        foreach(Car car in cars)
        {
            Console.WriteLine($"{car.Model}");
        }
    }
}
