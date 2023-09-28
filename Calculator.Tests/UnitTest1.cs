using System.Net.Sockets;

namespace Calculator.Tests
{
    public class UnitTest1
    {
        [Theory]
        [InlineData("3 * 1 + 2 - 9", "3 1 * 2 + 9 -")]
        [InlineData("3.272 * 112 + 2.2 / 91", "3.272 112 * 2.2 91 / +")]
        [InlineData("3.272*112+2.2/91", "3.272 112 * 2.2 91 / +")]
        public void Token_Converter_Infix_(string input, string expected)
        {
            var tokens = Token.Converter(input);
            var res = ShuntingYardAlgoritm.ConvertInfixToPostFix(tokens);

            Assert.Equal(expected, res);
        }

        [Theory]
        [InlineData("(2+2)*7+(2+(7+1))", 38)]
        [InlineData("(2+2)*7+(2+(7-1))", 36)]
        public void Result_ShouldBe_True(string input, double expected)
        {
            var tokenize = Token.Converter(input);
            var conversion = ShuntingYardAlgoritm.ConvertInfixToPostfixV2(tokenize);
            double result = CalcMath.EvaluatePostFixExpression(conversion);

            Assert.Equal(expected, result);
        }
    }
}