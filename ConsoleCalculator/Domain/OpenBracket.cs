using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Открывающаяся скобка.
    /// </summary>
    public class OpenBracket : IOpenBracket
    {
        public char BracketSymbol { get; private set;}

        public OpenBracket()
        {
            BracketSymbol = '(';
        }
    }
}
