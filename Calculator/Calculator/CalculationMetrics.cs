using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Calculator
{
    public class CalculationMetaData
    {
        public string InfixExpression { get; set; } = string.Empty;
        public IEnumerable<Token> ExpressionTokens { get; set; } = new List<Token>();
        public string PostfixExpression { get; set; } = string.Empty;
        public IEnumerable<string> EvaluationSteps { get; set; } = new List<string>();
        public double Result { get; set; }
    }
}
