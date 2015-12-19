using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator.Operations
{
    /// <summary>
    /// Операция суммы двух чисел.
    /// </summary>
    public class SumOperation : IOperation
    {
        public char OperationSymbol { get; private set; }
        public int Priority { get; private set; }

        public SumOperation(int priority)
        {
            OperationSymbol = '+';
            Priority = priority;
        }

        public decimal Calculate(decimal firstArgument, decimal secondArgument)
        {
            return firstArgument + secondArgument;
        }
    }
}
