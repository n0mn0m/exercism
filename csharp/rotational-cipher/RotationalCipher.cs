using System.Linq;

public static class RotationalCipher
{
    private static char Shift(char c, int shiftKey)
    {
        if (!char.IsLetter(c))
            return c;

        int a = char.IsLower(c) ? 'a' : 'A';        
        return (char)((c - a + shiftKey) % 26 + a);
    }
    
    public static string Rotate(string text, int shiftKey) => string.Join("", text.Select(c => Shift(c, shiftKey)));
}