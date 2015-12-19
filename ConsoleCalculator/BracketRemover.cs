using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Вырезает выражение из самых правых скобок.
    /// </summary>
    public class BracketRemover : IBracketRemover
    {
        private readonly IBracket _openBracket;
        private readonly IBracket _closeBracket;

        public BracketRemover(IOpenBracket open, ICloseBracket close)
        {
            _openBracket = open;
            _closeBracket = close;
        }

        public Expression GetExpressionInRightBrackets(string mathExpression)
        {
            var exp = new Expression();

            string cutExp = String.Empty;
            // Найти последнюю открывающуюся скобку.
            int lastOpenBracketIndex = mathExpression.LastIndexOf(_openBracket.BracketSymbol) + 1;
            if (lastOpenBracketIndex != 0)
            {
                // Найти закрывающуюся скобку следующую сразу за последней открывающейся.
                int lastCloseBracketIndex = mathExpression.IndexOf(_closeBracket.BracketSymbol, lastOpenBracketIndex);
                if (lastCloseBracketIndex != -1)
                    cutExp = mathExpression.Substring(lastOpenBracketIndex, lastCloseBracketIndex - lastOpenBracketIndex);
            }

            exp.ExpressionText = cutExp;
            exp.IndexInString = lastOpenBracketIndex;

            return exp;
        }
    }
}