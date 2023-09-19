using System.Text;

namespace Calculator;

public class ShuntingYardAlgoritm
{
    public static string ConvertInfixToPostFix(IEnumerable<Token> tokens)
    {
        Stack<Operator> operators = new();
        StringBuilder builder = new();

        List<string> operatorSigns = CalcMath.AllowedOperators.Select(x => x.Value).ToList();
        foreach (Token tk in tokens)
        {
            // Operator logic
            if (tk.Type == TokenType.OPERATOR)
            {
                if (operators.Count > 0)
                {
                    Operator top = operators.Peek();
                    Operator cur = tk.Value.StringToOperator();
                    if (top.Ranking < cur.Ranking)
                    {
                        operators.Push(cur);
                    }
                    else
                    {
                        Operator o = operators.Pop();
                        builder.Append(o.Value + " ");
                        operators.Push(cur);
                    }

                }
                else
                {
                    operators.Push(tk.Value.StringToOperator());
                }

                continue;
            }
            builder.Append(tk.Value + " ");

        }

        while (operators.Count > 0)
        {
            var op = operators.Pop();
            builder.Append(op.Value + " ");
        }

        return builder.ToString().Trim();
    }
}