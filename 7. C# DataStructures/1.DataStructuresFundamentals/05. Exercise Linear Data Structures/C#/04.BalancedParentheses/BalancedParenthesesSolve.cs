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

            Dictionary<char, char> bracketsPairs = new Dictionary<char, char>() {
                {'}', '{' },
                {']', '[' },
                {')', '(' },
            };

            Stack<char> brackets = new Stack<char>(parentheses.Length / 2);

            foreach (char c in parentheses)
            {
                if (bracketsPairs.ContainsValue(c))
                {
                    brackets.Push(c);
                }
                else if (bracketsPairs.ContainsKey(c))
                {
                    if (!brackets.Any() || bracketsPairs[c] != brackets.Pop())
                    {
                        return false;
                    }
                }
            }

            return !brackets.Any();
        }
    }
}
