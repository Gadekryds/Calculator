using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator.Internals
{
    public interface ICalculationInternal
    {
        IEnumerable<Token> ConvertInfixExpressionToTokens(string infixExpression);
        string ConvertInfixTokensToPostfix(IEnumerable<Token> tokens);
        CalculationEvaluation EvaluatePostfixExpression(string postfixExpression);
    }
}
