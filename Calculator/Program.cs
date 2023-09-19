
using Calculator;
using System.Globalization;

ApplicationSetup.SetupApplication();
string input = Console.ReadLine()!;
ApplicationSetup.TranslateCulturalDifference(input);

var tk = Token.ConvertStringToTokens(input);
var tokens = ShuntingYardAlgoritm.ConvertInfixToPostFix(tk);
var result = CalcMath.EvaluatePostFixExpression(tokens);

Console.WriteLine(tokens);
Console.WriteLine($"result is: {result}");
