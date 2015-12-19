using System.Collections.Generic;
using System.Linq;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Ищет первый символ операции соответствующий наивысшему приоритету.
    /// </summary>
    public class PriorityOperationFinder : IPriorityOperationFinder
    {
        private readonly IOperationsPriorities _operationsPriorities;
        
        public PriorityOperationFinder(IOperationsPriorities operationsPriorities)
        {
            this._operationsPriorities = operationsPriorities;
        }

        public PositionOperation FindFirst(string mathExpr)
        {
            PositionOperation posOper = new PositionOperation();

            int index = GetOperationIndexUsingPriority(mathExpr);
            if (index == -1) return posOper;

            posOper.PositionIndex = index;
            posOper.OperationSymbol = mathExpr.ElementAt(index);

            return posOper;
        }

        private int GetOperationIndexUsingPriority(string mathExpr)
        {
            int operatinIndex = 0;
            IEnumerable<int> priorities = _operationsPriorities.GetPriorityCollection();

            foreach (int priority in priorities)
            {
                char[] priorityOpers = _operationsPriorities.GetPrioritySymbolCollection(priority).ToArray();

                operatinIndex = mathExpr.IndexOfAny(priorityOpers, 1);

                if (operatinIndex != -1)
                    break;
            }

            return operatinIndex;
        }
    }
}
