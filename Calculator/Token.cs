

// Shunting-Yard Algorithm
// Convert infix to postfix (RPN - Reverse Polish Notation) notation
// Return an array of tokens in RPN order







using System.Text;

class Token
{
    public Token(string value, TokenType type)
    {
        Value = value;
        Type = type;
    }

    public string Value { get; set; }
    public TokenType Type { get; set; }
    public IList<Token> Children { get; set; } = new List<Token>();
    public Token? Parent { get; set; }

    public static IEnumerable<Token> ConvertStringToTokens(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return Array.Empty<Token>();

        var tokens = new List<Token>();

        int index = -1;
        StringBuilder builder = new();
        while (index < input.Length - 1)
        {
            index++;

            if (input[index] == ' ')
            {
                string value = builder.ToString();
                if (value == string.Empty)
                    continue;

                TokenType type = MathOperators.AllowedOperators.Select(x => x.Value).Contains(value) ? TokenType.OPERATOR : TokenType.NUMBER;
                tokens.Add(new Token(value, type));
                builder = new();
            }
            else
            {
                builder.Append(input[index]);
            }

        }

        string endV = builder.ToString();
        TokenType endT = MathOperators.AllowedOperators.Select(x => x.Value).Contains(endV) ? TokenType.OPERATOR : TokenType.NUMBER;
        tokens.Add(new Token(endV, endT));

        return tokens;
    }
}
