using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IBracketCounter
    {
        int CountBrackets(string expression);
    }
}
