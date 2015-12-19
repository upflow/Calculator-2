using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Закрывающаяся скобка.
    /// </summary>
    public class CloseBracket : ICloseBracket
    {
        public char BracketSymbol { get; private set; }

        public CloseBracket()
        {
            BracketSymbol = ')';
        }
    }
}
