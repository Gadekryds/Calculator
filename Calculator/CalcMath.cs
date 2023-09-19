namespace Calculator;

public static class CalcMath
{
    public static readonly Operator[] AllowedOperators = new Operator[]
    {
    new Operator(1, "Plus", "+"),
    new Operator(1, "Minus", "-"),
    new Operator(2, "Multiply", "*"),
    new Operator(2, "Divide", "/")
    };

    public static Operator StringToOperator(this string str) => str switch
    {
        "+" => AllowedOperators.FirstOrDefault(x => x.Value == "+")!,
        "-" => AllowedOperators.FirstOrDefault(x => x.Value == "-")!,
        "*" => AllowedOperators.FirstOrDefault(x => x.Value == "*")!,
        "/" => AllowedOperators.FirstOrDefault(x => x.Value == "/")!,
        _ => throw new ArgumentException()
    };

    public static double EvaluateCalculation(string op, string num1, string num2)
    {
        double d1 = double.Parse(num1);
        double d2 = double.Parse(num2);
        return op switch
        {
            "+" => d1 + d2,
            "-" => d1 - d2,
            "*" => d1 * d2,
            "/" => d1 / d2,
            _ => throw new ArgumentException(nameof(op))
        };
    }

    public static double EvaluatePostFixExpression(string input)
    {
        Stack<string> operands = new();
        var allowedOperators = AllowedOperators.Select(x => x.Value);
        var tokens = input.Split(' ');

        foreach (var x in tokens)
        {
            if (allowedOperators.Contains(x))
            {
                var op1 = operands.Pop();
                var op2 = operands.Pop();

                var result = EvaluateCalculation(x, op1, op2);
                operands.Push(result.ToString());
            }
            else
            {
                operands.Push(x);
            }
        }
        var endResult = operands.Pop();
        return double.Parse(endResult);
    }
}

public record Operator(int Ranking, string OperatorName, string Value);