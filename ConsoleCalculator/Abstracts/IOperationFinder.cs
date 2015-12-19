using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IOperationFinder
    {
        PositionOperation FindOperationNext(string mathExpr, int startIndex = 1);
        PositionOperation FindOperationPrev(string mathExpr, int startIndex);
    }
}
