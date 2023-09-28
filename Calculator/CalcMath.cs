using System.Reflection.Metadata.Ecma335;

namespace Calculator;

public static class CalcMath
{
    public static readonly Operator[] AllowedOperators = new Operator[]
    {
        new(1, "Plus", "+"),
        new(1, "Minus", "-"),
        new(2, "Multiply", "*"),
        new(2, "Divide", "/")
    };

    public static Operator ToOperator(this string str) => str switch
    {
        "+" => AllowedOperators.FirstOrDefault(x => x.Value == "+")!,
        "-" => AllowedOperators.FirstOrDefault(x => x.Value == "-")!,
        "*" => AllowedOperators.FirstOrDefault(x => x.Value == "*")!,
        "/" => AllowedOperators.FirstOrDefault(x => x.Value == "/")!,
        _ => throw new ArgumentException($"Operator not supported: {str}")
    };

    public static Operator ToOperator(this Token tk) =>
        AllowedOperators.FirstOrDefault(x => x.Value == tk.Value)!;

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
            _ => throw new ArgumentException($"Calculation evaluation not supported for operator: {op}", nameof(op))
        };
    }

    public static (double result, IEnumerable<string> evaluations) EvaluatePostFixExpression(string input)
    {
        Stack<string> operands = new();
        List<string> evaluations = new();
        var allowedOperators = AllowedOperators.Select(x => x.Value);
        var tokens = input.Split(' ');

        foreach (var x in tokens)
        {
            if (allowedOperators.Contains(x))
            {
                var op2 = operands.Pop();
                var op1 = operands.Pop();

                var result = EvaluateCalculation(x, op1, op2);
                evaluations.Add($"{op1} {x} {op2} = {result}");
                operands.Push(result.ToString());
            }
            else
            {
                operands.Push(x);
            }
        }
        var endResult = operands.Pop();
        return (double.Parse(endResult), evaluations);
    }
}

public record Operator(int Ranking, string OperatorName, string Value);