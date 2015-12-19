using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Хранит данные мат. выражении.
    /// </summary>
    public class Expression
    {
        public int IndexInString { get; set; } // Индекс в строке.
        public string ExpressionText { get; set; } // Математическое выражение.

        public Expression(string expressionText = "", int index = -1)
        {
            IndexInString = index;
            ExpressionText = expressionText;
        }
    }
}