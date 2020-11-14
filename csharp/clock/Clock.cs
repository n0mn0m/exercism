using System;

public class Clock : IEquatable<Clock>
{
    private const int MINUTES_IN_HOUR = 60;
    private const int HOURS_IN_DAY = 24;
    private const int MINUTES_IN_DAY = HOURS_IN_DAY * MINUTES_IN_HOUR;
    private readonly int _minutes;

    private static int WrapDay(int minutes) => ((minutes % MINUTES_IN_DAY) + MINUTES_IN_DAY) % MINUTES_IN_DAY;

    public Clock(int hours, int minutes) => _minutes = WrapDay(hours * MINUTES_IN_HOUR + minutes);

    public Clock Add(int minutes) => new Clock(0, _minutes + minutes);
    
    public Clock Subtract(int minutes) => new Clock(0, _minutes - minutes);

    public override string ToString() => $"{_minutes / MINUTES_IN_HOUR:d2}:{_minutes % MINUTES_IN_HOUR:d2}";

    bool IEquatable<Clock>.Equals(Clock other) => other != null && _minutes == other._minutes;
}
