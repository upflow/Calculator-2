using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator.Operations
{
    /// <summary>
    /// Операция деления двух чисел.
    /// </summary>
    public class DivisionOperation : IOperation
    {
        public char OperationSymbol {get; private set;}
        public int Priority {get; private set;}

        public DivisionOperation(int priority)
        {
            OperationSymbol = '/';
            Priority = priority;
        }

        public decimal Calculate(decimal firstArgument, decimal secondArgument)
        {
            decimal result = 0;
            try
            {
                result = firstArgument / secondArgument;
            }
            catch (Exception) { }

            return result;
        }
    }
}
