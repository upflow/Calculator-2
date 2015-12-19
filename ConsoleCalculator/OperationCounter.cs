using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    ///  Подсчитывает количество матем-их операций в выражении.
    /// </summary>
    public class OperationCounter : IOperationCounter
    {
        private readonly ICalculator _calculator;
        public OperationCounter(ICalculator calculator)
        {
            this._calculator = calculator;
        }

        public int GetCountOperations(string mathStr)
        {
            mathStr = mathStr.Substring(1);

            char[] symbolsOperations = _calculator.GetOperationsSymbolsCollection().ToArray();
            int count = mathStr.Count(symbolsOperations.Contains);

            return count;
        }
    }
}
