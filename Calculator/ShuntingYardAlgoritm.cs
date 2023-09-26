using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Calculator;

public static class ShuntingYardAlgoritm
{

    public static string ConvertInfixToPostfixV2(IEnumerable<Token> tokens)
    {
        Queue<Token> queue = new();
        StringBuilder builder = new();
        Stack<Token> operators = new Stack<Token>();

        foreach (var tk in tokens)
        {
            queue.Enqueue(tk);
        }

        while (queue.TryDequeue(out Token token))
        {
            if (token.Type == TokenType.SCOPE_START)
            {
                var part = HandleScopeTokens(token, ref queue);
                builder.Append(part);
                continue;
            }

            if (token.Type == TokenType.OPERATOR)
            {
                builder.HandleOperatorToken(token, ref operators);
                continue;
            }

            if (token.Type == TokenType.NUMBER)
            {
                builder.HandleNumberToken(token, queue.Count > 0);
                continue;
            }
        }

        while (operators.TryPop(out Token token))
        {
            builder.Append(token.Value);
            if (operators.Count > 0)
            {
                builder.Append(' ');
            }
        }

        return builder.ToString();
    }

    private static void HandleNumberToken(this StringBuilder builder, Token token, bool moreTokens)
    {
        builder.Append(token.Value + ' ');
    }

    private static void HandleOperatorToken(this StringBuilder builder, Token token, ref Stack<Token> operators)
    {
        Operator op = token.ToOperator();

        if (operators.Count == 0)
        {
            operators.Push(token);
            return;
        }

        if (operators.TryPeek(out Token t))
        {
            Operator top = t.ToOperator();
            if (top.Ranking < op.Ranking)
            {
                operators.Push(token);
            }
            else
            {
                var next = operators.Pop();
                builder.Append(next.Value + ' ');
                operators.Push(token);
            }
        }
    }

    private static string HandleScopeTokens(Token current, ref Queue<Token> queue)
    {
        StringBuilder builder = new();
        Stack<Token> operators = new Stack<Token>();
        while (queue.TryDequeue(out Token token))
        {
            if (token.Type == TokenType.SCOPE_END)
            {
                break;
            }
            else if (token.Type == TokenType.SCOPE_START)
            {
                string part = HandleScopeTokens(token, ref queue);
                builder.Append(part);
            }
            else if (token.Type == TokenType.OPERATOR)
            {
                builder.HandleOperatorToken(token, ref operators);
            }
            else if (token.Type == TokenType.NUMBER)
            {
                builder.HandleNumberToken(token, queue.Count > 0);
            }
        }

        while (operators.TryPop(out Token token))
        {
            builder.Append(token.Value);
            builder.Append(' ');
        }

        return builder.ToString();
    }



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
                    Operator cur = tk.Value.ToOperator();
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
                    operators.Push(tk.Value.ToOperator());
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