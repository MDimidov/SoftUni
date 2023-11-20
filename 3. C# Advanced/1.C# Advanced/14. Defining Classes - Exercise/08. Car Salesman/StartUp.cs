namespace DefiningClasses;

public class StartUp
{
    private static void Main()
    {
        List<Car> cars = new();
        List<Engine> engines = new();

        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            string[] cmdArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = cmdArg[0];
            int power = int.Parse(cmdArg[1]);
            int displacement = 0;
            string efficiency = "n/a";
            if (cmdArg.Length == 4)
            {
                displacement = int.Parse(cmdArg[2]);
                efficiency = cmdArg[3];
            }
            else if (cmdArg.Length == 3 && int.TryParse(cmdArg[2], out displacement))
            {
                displacement = int.Parse(cmdArg[2]);
            }
            else if (cmdArg.Length == 3)
            {
                efficiency = cmdArg[2];
            }


            Engine engine = new(model, power, displacement, efficiency);
            engines.Add(engine);
        }

        int m = int.Parse(Console.ReadLine());
        for (int i = 0; i < m; i++)
        {
            string[] cmdArg = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            string model = cmdArg[0];
            string engineModel = cmdArg[1];
            int weight = 0;
            string color = "n/a";
            if (cmdArg.Length == 4)
            {
                weight = int.Parse(cmdArg[2]);
                color = cmdArg[3];
            }
            else if (cmdArg.Length == 3 && int.TryParse(cmdArg[2], out weight))
            {
                weight = int.Parse(cmdArg[2]);
            }
            else if (cmdArg.Length == 3)
            {
                color = cmdArg[2];
            }

            Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);
            Car car = new(model, engine, weight, color);
            cars.Add(car);
        }


        foreach(Car car in cars)
        {
            string weight = car.Weight.ToString();
            if(car.Weight == 0)
            {
                weight = "n/a";
            }

            string displacement = car.Engine.Displacement.ToString();
            if(car.Engine.Displacement == 0)
            {
                displacement = "n/a";
            }

            Console.WriteLine($"{car.Model}:\n" +
                $"  {car.Engine.Model}:\n" +
                $"    Power: {car.Engine.Power}\n" +
                $"    Displacement: {displacement}\n" +
                $"    Efficiency: {car.Engine.Efficiency}\n" +
                $"  Weight: {weight}\n" +
                $"  Color: {car.Color}");
        }
    }
}
