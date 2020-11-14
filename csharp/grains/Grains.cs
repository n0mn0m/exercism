using System;
using System.Linq;

public static class Grains
{
    public static ulong Square(int n) =>
        n <= 0 || n > 64 ? 
        throw new ArgumentOutOfRangeException() : 
        Convert.ToUInt64(Math.Pow(2, n - 1));

    public static ulong Total() => ulong.MaxValue;
}