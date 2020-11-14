using System;
using System.Collections.Generic;
using System.Linq;

public class Robot
{
    private string _name;
    public string Name => _name ??= RobotNameFactory.Create();

    public void Reset() => _name = null;
}

internal static class RobotNameFactory
{
    private static readonly Random rng = new Random();
    private static readonly HashSet<string> names = new HashSet<string>();

    public static string Create()
    {
        var name = $"{(char)rng.Next('A', 'Z'+1)}{(char)rng.Next('A', 'Z'+1)}{rng.Next(1000):D3}";

        return names.Add(name) ? name : Create();
    }
}