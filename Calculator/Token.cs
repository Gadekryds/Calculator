using Calculator;
using System.Text;

public class Token
{
    public Token(string value, TokenType type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; set; }
    public TokenType Type { get; set; }

    public static IEnumerable<Token> ConvertStringToTokens(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Array.Empty<Token>();

        List<Token> tokens = new();
        StringBuilder builder = new();

        Queue<char> chars = new();

        foreach (char c in input)
        {
            chars.Enqueue(c);
        }

        while (chars.Count > 0)
        {
            var c = chars.Dequeue();
            if (c.IsOperator() || c == ' ')
            {
                string val = builder.ToString();
                tokens.Add(new Token(val, val.SolveTokenType()));
                builder = new();
                string oVal = c.ToString();
                tokens.Add(new Token(oVal, oVal.SolveTokenType()));
                continue;
            }
            builder.Append(c);
        }
        if (builder.Length > 0)
        {
            var val = builder.ToString();
            tokens.Add(new Token(val, val.SolveTokenType()));
        }
        return tokens;
    }

}
