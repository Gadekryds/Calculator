using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    public class CalculatorEngine : ICalculator
    {
        public CalculationMetaData EvaluateExpression(string infixExpression)
        {
            CalculationMetaData metaData = new(infixExpression);

            var tokens = Token.Converter(infixExpression);
            metaData.ExpressionTokens = tokens;

            var postfix = ShuntingYardAlgoritm.ConvertInfixToPostfixV2(tokens);
            metaData.PostfixExpression = postfix;

            (double result, IEnumerable<string> eval) = CalcMath.EvaluatePostFixExpression(postfix);
            metaData.Result = result;
            metaData.EvaluationSteps = eval;

            return metaData;
        }
    }
}
