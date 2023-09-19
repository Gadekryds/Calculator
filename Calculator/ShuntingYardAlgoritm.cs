using System.Text;

internal class ShuntingYardAlgoritm
{
    public static string ConvertInfixToPostFix(IEnumerable<string> vs)
    {
        Stack<Operator> operators = new();
        StringBuilder builder = new();

        List<string> operatorSigns = MathOperators.AllowedOperators.Select(x => x.Value).ToList();
        foreach (string s in vs)
        {
            // Operator logic
            if (operatorSigns.Contains(s))
            {
                if (operators.Count > 0)
                {
                    Operator top = operators.Peek();
                    Operator cur = MathOperators.StringToOperator(s);
                    if (top.Ranking < cur.Ranking)
                    {
                        operators.Push(cur);
                    }
                    else
                    {
                        Operator o = operators.Pop();
                        builder.Append(o + " ");
                        operators.Push(cur);
                    }
                   
                }
                else
                {
                    operators.Push(MathOperators.StringToOperator(s));
                }

                continue;
            }
            builder.Append(s + " " );

        }

        while(operators.Count > 0)
        {
            var op = operators.Pop();
            builder.Append(op.Value + " ");
        }

        return builder.ToString().Trim();
    }
}