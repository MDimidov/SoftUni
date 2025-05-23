using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem04.BalancedParentheses
{
    public class BalancedParenthesesSolve : ISolvable
    {
        public bool AreBalanced(string parentheses)
        {
            if(parentheses.Length % 2 != 0)
            {
                return false;
            }

            char[] openedBrackets = { '{', '[', '(' };
            char[] closedBrackets = { '}', ']', ')' };

            Dictionary<char, char> tupleBrackets = new Dictionary<char, char>() {
                {'}', '{' },
                {']', '[' },
                {')', '(' },
            };
            Stack<char> brackets = new Stack<char>(parentheses.Length / 2);

            foreach (char c in parentheses)
            {
                if (openedBrackets.Contains(c))
                {
                    brackets.Push(c);
                }
                else if (closedBrackets.Contains(c))
                {
                    if (brackets.Any() && tupleBrackets[c] == brackets.Peek())
                    {
                        brackets.Pop();
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return !brackets.Any();
        }
    }
}
