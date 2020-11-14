using System.Linq;

public static class Bob
{
    private static bool Silence(this string input) => string.IsNullOrWhiteSpace(input);
    private static bool Shouting(this string input) => input.Any(char.IsLetter) && input.ToUpper() == input;
    private static bool Question(this string input) => input.TrimEnd().EndsWith("?");

    public static string Response(string message) => message switch
    {
        _ when message.Silence() => "Fine. Be that way!",
        _ when message.Shouting() && message.Question() => "Calm down, I know what I'm doing!",
        _ when message.Shouting() => "Whoa, chill out!",
        _ when message.Question() => "Sure.",
        _ => "Whatever."
    };
}