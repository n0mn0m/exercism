using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        var acronym = phrase.Split(new char[] { ' ', '-', '_' }, StringSplitOptions.RemoveEmptyEntries)
                                   .Select(c => char.ToUpper(c[0])).ToArray();
        return string.Join("", acronym);
    }
}