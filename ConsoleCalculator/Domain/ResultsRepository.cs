using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Хранилище результатов всех математических опреций.
    /// </summary>
    public class ResultsRepository : IResultsRepository
    {
        private static readonly IList<decimal> resultList;

        static ResultsRepository()
        {
            resultList = new List<decimal>();
        }

        public IEnumerable<decimal> ResultList
        {
            get { return resultList; }
        }

        /// <summary>
        /// Добавляет результат в хранилище, возвращая индекс добавленного элемента.
        /// </summary>
        /// <param name="result"></param>
        /// <returns></returns>
        public int Add(decimal result)
        {
            resultList.Add(result);
            return resultList.Count() - 1;
        }

        /// <summary>
        /// Возвращает индекс числа в хранилище результатов.
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public int GetIndex(decimal value)
        {
            return resultList.IndexOf(value);
        }

        /// <summary>
        /// Очищает хранилище.
        /// </summary>
        public void Clear()
        {
            resultList.Clear();
        }
    }
}
