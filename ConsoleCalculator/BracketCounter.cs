using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Считает количество выражений в скобках (или количество скобок) в строке.
    /// </summary>
    public class BracketCounter : IBracketCounter
    {
        private readonly IBracket openBracket;
        private readonly IBracket closeBracket;

        public BracketCounter(IOpenBracket open, ICloseBracket close)
        {
            openBracket = open;
            closeBracket = close;
        }

        public int CountBrackets(string expression)
        {
            int count = -1;

            // Количество открывающихся скобок.
            if (expression != null)
            {
                int countOpenBrackets = expression.Count(x => x == openBracket.BracketSymbol);
                // Количество закрывающихся скобок.
                int countCloseBrackets = expression.Count(x => x == closeBracket.BracketSymbol);

                if (countOpenBrackets == countCloseBrackets)
                    count = countOpenBrackets;
            }

            return count;
        }
    }
}
