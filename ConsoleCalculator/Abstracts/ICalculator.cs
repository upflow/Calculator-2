using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface ICalculator
    {
        IEnumerable<IOperation> OperationList { get; }
        decimal Calculate(OperationInfo operInfo);
        IEnumerable<char> GetOperationsSymbolsCollection();
    }
}
