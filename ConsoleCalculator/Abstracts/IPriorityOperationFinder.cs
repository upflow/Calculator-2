using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Abstracts
{
    public interface IPriorityOperationFinder
    {
        PositionOperation FindFirst(string mathExpr);
    }
}
