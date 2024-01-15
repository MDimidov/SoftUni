namespace _10.Chronometer.Interfaces;

public interface IChronometer
{
    string GetTime { get; }

    List<string> Laps { get; }

    void Start();

    void Stop();

    string Lap();

    void Reset();
}
