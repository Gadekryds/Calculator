using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculation.Internals
{
    public class CalculationInternal : ICalculationInternal
    {
        public CalculationInternal()
        {
        }

        public IEnumerable<Token> ConvertInfixExpressionToTokens(string infixExpression) =>
            Token.Converter(infixExpression);

        public string ConvertInfixTokensToPostfix(IEnumerable<Token> tokens) =>
            ShuntingYardAlgoritm.ConvertInfixToPostfixV2(tokens);

        public CalculationEvaluation EvaluatePostfixExpression(string postfixExpression) =>
            CalcMath.EvaluatePostFixExpression(postfixExpression);
    }
}
