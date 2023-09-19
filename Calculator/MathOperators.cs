

// Shunting-Yard Algorithm
// Convert infix to postfix (RPN - Reverse Polish Notation) notation
// Return an array of tokens in RPN order




using System.Reflection.Metadata.Ecma335;

public class MathOperators
{
    public static readonly Operator[] AllowedOperators = new Operator[]
    {
        new Operator(1, "Plus", "+"),
        new Operator(1, "Minus", "-"),
        new Operator(2, "Multiply", "*"),
        new Operator(2, "Divide", "/")
    };

    public static Operator StringToOperator(string str) => str switch
    {
        "+" => AllowedOperators.FirstOrDefault(x => x.Value == "+")!,
        "-" => AllowedOperators.FirstOrDefault(x => x.Value == "-")!,
        "*" => AllowedOperators.FirstOrDefault(x => x.Value == "*")!,
        "/" => AllowedOperators.FirstOrDefault(x => x.Value == "/")!,
        _ => throw new ArgumentException()
    };

}

public record Operator(int Ranking, string OperatorName, string Value);
