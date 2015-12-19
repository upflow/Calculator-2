using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Используя колекцию операций работает с приоритетами операций.
    /// </summary>
    public class OperationsPriorities : IOperationsPriorities
    {
        private readonly ICalculator calculator;

        public OperationsPriorities(ICalculator calculator)
        {
            this.calculator = calculator;
        }

        /// <summary>
        /// Возвращает коллекцию всех приоритетов операций.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<int> GetPriorityCollection()
        {
            return calculator.OperationList
                .Select(x => x.Priority)
                .Distinct()
                .OrderByDescending(x => x)
                .AsEnumerable();
        }

        /// <summary>
        /// Получает число (приоритет операции) и возвращает список символов,
        /// соответствующих этому приоритету.
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        public IEnumerable<char> GetPrioritySymbolCollection(int priority)
        {
            return calculator.OperationList
                .Where(x => x.Priority == priority)
                .Select(x => x.OperationSymbol)
                .AsEnumerable();
        }
    }
}
