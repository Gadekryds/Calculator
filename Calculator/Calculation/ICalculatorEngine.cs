namespace Calculator.Calculation
{
    public interface ICalculatorEngine
    {
        CalculationMetaData EvaluateExpression(string infixExpression);
    }
}