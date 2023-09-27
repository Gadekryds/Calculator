
using Calculator;

ApplicationSetup.SetupApplication();

while (true)
{
    Console.Write("Equation to solve: ");
    string input = Console.ReadLine()!;
    ApplicationSetup.TranslateCulturalDifference(input);

    var tk = Token.Converter(input);
    ConsoleUIHelpers.InsertHeader("Identified Tokens", '-');
    foreach (var t in tk)
    {
        Console.WriteLine(t);
    }

    var tokens = ShuntingYardAlgoritm.ConvertInfixToPostfixV2(tk);
    ConsoleUIHelpers.InsertHeader("Postfix Conversion", '-');
    Console.WriteLine($"{tokens}");

    ConsoleUIHelpers.InsertHeader("Evaluation", '-');
    var result = CalcMath.EvaluatePostFixExpression(tokens);

    ConsoleUIHelpers.InsertHeader("Result", '-');
    Console.WriteLine($"{result}");

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

