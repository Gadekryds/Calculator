
using Calculator;
using Calculator.Calculation;

ApplicationSetup.SetupApplication();

while (true)
{
    Console.Write("Equation to solve: ");
    string input = Console.ReadLine()!;
    ApplicationSetup.TranslateCulturalDifference(input);

    ICalculator calc = new CalculatorEngine();
    var meta = calc.EvaluateExpression(input);

    ConsoleUIHelpers.InsertHeader("Identified Tokens", '-');
    foreach (var t in meta.ExpressionTokens)
    {
        Console.WriteLine(t);
    }

    ConsoleUIHelpers.InsertHeader("Postfix Conversion", '-');
    Console.WriteLine($"{meta.PostfixExpression}");

    ConsoleUIHelpers.InsertHeader("Evaluation", '-');
    foreach (var eval in meta.EvaluationSteps)
    {
        Console.WriteLine(eval);
    }
    ConsoleUIHelpers.InsertHeader("Result", '-');
    Console.WriteLine($"{meta.Result}");

    Console.WriteLine("\nExit? Y/N");
    var k = Console.ReadKey();

    if (k.Key == ConsoleKey.Y)
    {
        break;
    }
    else
    {
        Console.Clear();
    }
}

