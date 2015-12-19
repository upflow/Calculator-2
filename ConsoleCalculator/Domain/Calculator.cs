using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Используя массив опреций вычисляет значение переданого математического выражения.
    /// </summary>
    public class Calculator : ICalculator
    {
        private readonly List<IOperation> operationList = new List<IOperation>();

        public Calculator(IEnumerable<IOperation> operations)
        {
            operationList.AddRange(operations);
        }

        public IEnumerable<IOperation> OperationList
        {
            get { return operationList; }
        }

        /// <summary>
        /// Зная оба операнда и символ мат. операции, вычисляет значение.
        /// </summary>
        /// <param name="operInfo"></param>
        /// <returns></returns>
        public decimal Calculate(OperationInfo operInfo)
        {
            IOperation operation = GetOperationBySymbol(operInfo.OperationSymbol);
            if (operation == null)
                throw new Exception();

            return operation.Calculate(operInfo.Operand1, operInfo.Operand2);
        }

        /// <summary>
        /// Вспомогательный метод.
        /// Возвращает объект операции получая символ оперции.
        /// </summary>
        /// <param name="operationSymbol"></param>
        /// <returns></returns>
        private IOperation GetOperationBySymbol(char operationSymbol)
        {
            return OperationList.Where(x => x.OperationSymbol == operationSymbol).FirstOrDefault();
        }

        /// <summary>
        /// Возвращает коллекцию символов всех опреций.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<char> GetOperationsSymbolsCollection()
        {
            return OperationList.Select(op => op.OperationSymbol);
        }
    }   
}
