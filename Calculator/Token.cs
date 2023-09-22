namespace Calculator;

public record Token(string Value, TokenType Type)
{
    public static Token Create(string value)
        => new(value, value.SolveTokenType());

    public static IEnumerable<Token> Converter(string input)
    {
        Queue<char> chars = new();
        foreach (char c in input)
        {
            chars.Enqueue(c);
        }

        while (chars.Count > 0)
        {
            char c = chars.Dequeue();

            if (c.IsNumber())
            {
                yield return TokenExtensions.CreateNumberToken(c, chars);
                continue;
            }

            if (c.IsOperator())
            {
                yield return Token.Create(c.ToString());
                continue;
            }
        }
    }

}