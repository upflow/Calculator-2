using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Получает выражение в виде строки и разбивает его на составляющие:
    /// 2 операнда и символ операции.
    /// </summary>
    public class ExpressionDelimiter : IExpressionDelimiter
    {
        private readonly IOperationFinder operationFinder;
        private readonly IOperandParser operandParser;

        public ExpressionDelimiter(IOperandParser operandParser, IOperationFinder operationFinder)
        {
            this.operandParser = operandParser;
            this.operationFinder = operationFinder;
        }

        /// <summary>
        /// Разбивает выражение на 2 операнда и символ операции.
        /// </summary>
        /// <param name="mathExpression"></param>
        /// <returns></returns>
        public OperationInfo Divide(string mathExpression)
        {
            PositionOperation posOper = operationFinder.FindOperationNext(mathExpression);

            if (posOper.PositionIndex == -1) return null;
            
            string leftOperandStr = mathExpression.Substring(0, posOper.PositionIndex);
            decimal leftOperand = operandParser.ParseString(leftOperandStr);
                
            string rightOperandStr = mathExpression.Substring(posOper.PositionIndex + 1);
            decimal rightOperand = operandParser.ParseString(rightOperandStr);
                
            return new OperationInfo
            {
                Operand1 = leftOperand,
                Operand2 = rightOperand,
                OperationSymbol = posOper.OperationSymbol
            };
        }
    }
}
