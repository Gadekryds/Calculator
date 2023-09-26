using System.Text;

namespace Calculator;

public static class TokenExtensions
{
    public static TokenType SolveTokenType(this string value)
    => value.IsOperator() ? TokenType.OPERATOR :
        value == "(" ? TokenType.SCOPE_START : 
        value == ")" ? TokenType.SCOPE_END : TokenType.NUMBER;

    public static bool IsOperator(this char c)
        => CalcMath.AllowedOperators.FirstOrDefault(x => x.Value[0] == c) != null;

    public static bool IsOperator(this string c)
        => CalcMath.AllowedOperators.FirstOrDefault(x => x.Value == c) != null;

    public static bool IsNumber(this string c)
        => IsNumber(c[0]);

    public static bool IsNumber(this char c)
        => char.IsDigit(c) || c == '.';

    public static Token CreateNumberToken(char c, Queue<char> queue)
    {
        StringBuilder builder = new();
        builder.Append(c);
        while (queue.TryPeek(out char next) && next.IsNumber())
        {
            builder.Append(queue.Dequeue());
        }
        string val = builder.ToString();
        return Token.Create(val);
    }
}
