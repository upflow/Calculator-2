using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Ищет символы операций в строке и возвращает данные.
    /// </summary>
    public class OperationFinder : IOperationFinder
    {
        private readonly ICalculator calculator;

        public OperationFinder(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Находит следующий символ операции начиная от указанного индекса.
        /// </summary>
        /// <param name="mathExpr"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public PositionOperation FindOperationNext(string mathExpr, int startIndex = 1)
        {
            return Find(mathExpr, startIndex, true);
        }

        /// <summary>
        /// Находит предыдущий символ опреации начиная от указанного индекса.
        /// </summary>
        /// <param name="mathExpr"></param>
        /// <param name="startIndex"></param>
        /// <returns></returns>
        public PositionOperation FindOperationPrev(string mathExpr, int startIndex)
        {
            return Find(mathExpr, startIndex, false);
        }

        /// <summary>
        /// Ищет символ операции в строке начиная с заданного индекса.
        /// Булевский параметр указывает направление поиска.
        /// </summary>
        /// <param name="mathExpr"></param>
        /// <param name="startIndex"></param>
        /// <param name="isForth"></param>
        /// <returns></returns>
        private PositionOperation Find(string mathExpr, int startIndex, bool isForth)
        {
            PositionOperation posOper = new PositionOperation();

            char[] operations = calculator.GetOperationsSymbolsCollection().ToArray();
            int index = -1;

            if (isForth)
                index = mathExpr.IndexOfAny(operations, startIndex);
            else
                index = mathExpr.LastIndexOfAny(operations, startIndex);

            if (index != -1)
            {
                posOper.PositionIndex = index;
                posOper.OperationSymbol = mathExpr.ElementAt(index);
            }

            return posOper;
        }
    }
}
