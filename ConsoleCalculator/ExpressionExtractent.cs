using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Используя приоритеты операций вырезает из строки (не содержащей скобки)
    /// первое выражение удовлетворяющее наивысшему приоритету.
    /// </summary>
    public class ExpressionExtractent : IExpressionExtractent
    {
        private readonly IOperationFinder operationFinder;
        private readonly IPriorityOperationFinder priorityOperationFinder;

        public ExpressionExtractent(IOperationFinder operationFinder, IPriorityOperationFinder priorityOperationFinder)
        {
            this.operationFinder = operationFinder;
            this.priorityOperationFinder = priorityOperationFinder;
        }

        /// <summary>
        /// Вырезает из строки первое выражение удовлетворяющее наивысшему приоритету.
        /// </summary>
        /// <param name="mathExpr"></param>
        /// <returns></returns>
        public Expression CutFirstExpression(string mathExpr)
        {
            int index = priorityOperationFinder.FindFirst(mathExpr).PositionIndex;
            return GetExpressionByIndex(mathExpr, index);
        }

       /// <summary>
       /// Вырезает из переданной строки мат. выражение используя индекс месторасположения
       /// символа операции.
       /// </summary>
       /// <param name="mathExpr"></param>
       /// <param name="operIndex"></param>
       /// <returns></returns>
        private Expression GetExpressionByIndex(string mathExpr, int operIndex)
        {
            Expression expression = new Expression
            {
                ExpressionText = mathExpr,
                IndexInString = operIndex
            };

           if (operIndex == 0 || operIndex == mathExpr.Count())
                return expression;

            // Получить индекс предыдущей операции.
            int start = operationFinder.FindOperationPrev(mathExpr, operIndex - 1).PositionIndex;
            if (start != -1 && start != 0)
                start++;
            else
                start = 0;
            
            // Получить индекс следующей операции.
            int end = operationFinder.FindOperationNext(mathExpr, operIndex + 1).PositionIndex; 
            string resultStr = end == -1 ? mathExpr.Substring(start) : mathExpr.Substring(start, end - start);

            expression.IndexInString = start;
            expression.ExpressionText = resultStr;

            return expression;
        }
    }
}