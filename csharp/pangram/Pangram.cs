using System.Collections.Generic;

public static class Pangram
{
    public static bool IsPangram(string s) =>
            new HashSet<char>(s.ToLower())
                .IsSupersetOf("abcdefghijklmnopqrstuvwxyz");
}
