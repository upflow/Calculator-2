using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IResultsRepository
    {
        IEnumerable<decimal> ResultList { get; }
        int Add(decimal result);
        int GetIndex(decimal value);
        void Clear();
    }
}
