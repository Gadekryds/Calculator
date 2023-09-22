
using Calculator;

ApplicationSetup.SetupApplication();

while (true)
{
    Console.Write("Equation to solve: ");
    string input = Console.ReadLine()!;
    ApplicationSetup.TranslateCulturalDifference(input);

    var tk = Token.Converter(input);
    var tokens = ShuntingYardAlgoritm.ConvertInfixToPostFix(tk);
    Console.WriteLine("\n---------------Postfix Conversion---------------");
    Console.WriteLine($"{tokens}");

    Console.WriteLine("\n---------------Evaluation---------------");
    var result = CalcMath.EvaluatePostFixExpression(tokens);

    Console.WriteLine("\n---------------Result---------------");
    Console.WriteLine($"{result}");

    Console.WriteLine("\nStart over? Y/N");
    var k = Console.ReadKey();

    if (k.Key == ConsoleKey.Y)
    {
        Console.Clear();
        continue;
    }
    else
        break;
}

