namespace Calculator;

public static class TokenExtensions
{
    public static TokenType SolveTokenType(this string value)
    => value.IsOperator() ? TokenType.OPERATOR : TokenType.NUMBER;

    public static bool IsOperator(this char c)
        => CalcMath.AllowedOperators.FirstOrDefault(x => x.Value[0] == c) != null;

    public static bool IsOperator(this string c)
        => CalcMath.AllowedOperators.FirstOrDefault(x => x.Value == c) != null;
}
