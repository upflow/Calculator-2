using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IOperandParser
    {
        decimal ParseString(string operandStr);
        string ParseNumber(decimal operand);
    }
}
