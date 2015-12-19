using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator.Operations
{
    /// <summary>
    /// Операция разности двух чисел.
    /// </summary>
    public class DifferentOperation : IOperation
    {
        public int Priority { get; private set; }
        public char OperationSymbol { get; private set;}

        public DifferentOperation(int priority)
        {
            OperationSymbol = '-';
            Priority = priority;
        }

        public decimal Calculate(decimal firstArgument, decimal secondArgument)
        {
            return firstArgument - secondArgument;
        }
    }
}
