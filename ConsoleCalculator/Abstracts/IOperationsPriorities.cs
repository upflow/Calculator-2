using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IOperationsPriorities
    {
        IEnumerable<int> GetPriorityCollection();
        IEnumerable<char> GetPrioritySymbolCollection(int priority);
    }
}
