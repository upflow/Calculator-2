using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IBracketRemover
    {
        Expression GetExpressionInRightBrackets(string expression);
    }
}
