using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        var nucleotideFrequency = new Dictionary<char, int> { { 'A', 0 }, { 'C', 0 }, { 'G', 0 }, { 'T', 0 } };

        foreach (char c in sequence)
        {
            if (!nucleotideFrequency.ContainsKey(c)) throw new InvalidNucleotideException("Nucleotide must be A, C, G or T.");
            nucleotideFrequency[c] = nucleotideFrequency[c] + 1;
        }
        return nucleotideFrequency;
    }
}

public class InvalidNucleotideException : ArgumentException
{
    public InvalidNucleotideException(): base() {}
    public InvalidNucleotideException(string message) : base(message) { }
}
