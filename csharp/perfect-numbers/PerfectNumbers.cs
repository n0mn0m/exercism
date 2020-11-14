using System;
using System.Globalization;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {        
        if (number <= 0)
            throw new ArgumentOutOfRangeException();
        
        var aliquotSum = Enumerable.Range(1, number / 2).Where(x => number % x == 0).Sum();

        if (aliquotSum == number)
            return Classification.Perfect;
        
        return aliquotSum > number ? Classification.Abundant : Classification.Deficient;
    }
}
