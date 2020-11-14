using System.Collections.Immutable;
using System.Linq;

public static class MatchingBrackets
{
    private const string Open = "{[(";
    private const string Close = "}])";

    public static bool IsPaired(string input) => !input.Aggregate(ImmutableStack<char>.Empty, (acc, current) =>
            Open
                .Contains(current)
                ? acc.Push(current)
                : Close.Contains(current)
                    ? acc.Any() && Open.ElementAt(Close.IndexOf(current)) == acc.Peek() ? acc.Pop() :
                    acc.Push('?')
                    : acc)
        .Any();
}