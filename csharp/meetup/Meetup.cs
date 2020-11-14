using System;
using System.Linq;

public enum Schedule
{
    Teenth,
    First,
    Second,
    Third,
    Fourth,
    Last
}

public class Meetup
{
    private readonly int _month;
    private readonly int _year;

    public Meetup(int month, int year)
    {
        _month = month;
        _year = year;
    }

    public DateTime Day(DayOfWeek dayOfWeek, Schedule schedule)
    {
        var daysMatching = Enumerable
            .Range(1, DateTime.DaysInMonth(_year, _month))
            .Select(day => new DateTime(_year, _month, day))
            .Where(day => day.DayOfWeek == dayOfWeek)
            .ToList();

        var meetup = schedule switch
        {
            Schedule.Teenth => daysMatching.First(day => day.Day >= 13),
            Schedule.Last => daysMatching.Last(),
            _ => daysMatching[(int)schedule - 1]
        };

        return meetup;
    }
}