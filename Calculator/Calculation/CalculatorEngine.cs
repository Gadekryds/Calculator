using Calculator.Calculation.Internals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculation
{
    public class CalculatorEngine : ICalculator
    {
        private readonly ICalculationInternal _calculationInternal;

        public CalculatorEngine(ICalculationInternal calculationInternal)
        {
            _calculationInternal = calculationInternal;
        }

        public CalculationMetaData EvaluateExpression(string infixExpression)
        {
            CalculationMetaData metaData = new(infixExpression);

            metaData.ExpressionTokens = _calculationInternal.ConvertInfixExpressionToTokens(infixExpression);
            metaData.PostfixExpression = _calculationInternal.ConvertInfixTokensToPostfix(metaData.ExpressionTokens);

            var calcEval = _calculationInternal.EvaluatePostfixExpression(metaData.PostfixExpression);
            metaData.Result = calcEval.Result;
            metaData.EvaluationSteps = calcEval.Evaluation;

            return metaData;
        }
    }
}
