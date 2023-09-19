

// Shunting-Yard Algorithm
// Convert infix to postfix (RPN - Reverse Polish Notation) notation
// Return an array of tokens in RPN order


string input = Console.ReadLine()!;
var vs = input.Split(' ').Where(x => !string.IsNullOrWhiteSpace(x));

var tk = Token.ConvertStringToTokens(input);
var tokens = ShuntingYardAlgoritm.ConvertInfixToPostFix(vs);
var result = EvaluatePostFixExpression(tokens);

Console.WriteLine(tokens);
Console.WriteLine($"result is: {result}");




double EvaluatePostFixExpression(string input)
{
    Stack<string> operands = new Stack<string>();
    var allowedOperators = MathOperators.AllowedOperators.Select(x => x.Value);
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

double EvaluateCalculation(string op, string num1, string num2)
{
    return op switch
    {
        "+" => double.Parse(num1) + double.Parse(num2),
        "-" => double.Parse(num1) - double.Parse(num2),
        "*" => double.Parse(num1) * double.Parse(num2),
        "/" => double.Parse(num1) / double.Parse(num2),
        _ => throw new ArgumentException(nameof(op))
    };
}
