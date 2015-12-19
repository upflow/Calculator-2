using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IOperation
    {
        char OperationSymbol { get; }
        int Priority { get; }
        decimal Calculate(decimal firstArgument, decimal secondArgument);
    }
}
