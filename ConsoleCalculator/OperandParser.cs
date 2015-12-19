using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Используя хранилище результатов преобразовывает 
    /// результаты операций в специальные маркеры ("#x", x - индекс числа в массиве результатов) 
    /// для вставки в исходную строку.
    /// Также производит обратное преобразование.
    /// </summary>
    public class OperandParser : IOperandParser
    {
        // Специальный маркер, который ставится перед числом (индексатором).
        private const char specialSymbol = '#';
        private readonly IResultsRepository resultsRepository;

        public OperandParser(IResultsRepository resultsRepository)
        {
            this.resultsRepository = resultsRepository;
        }

        /// <summary>
        /// Метод принимает маркер или число, в виде строки, и возвращает результат.
        /// Если передается маркер, используя хранилище извлекается число. 
        /// </summary>
        /// <param name="operandStr"></param>
        /// <returns></returns>
        public decimal ParseString(string operandStr)
        {
            decimal number;
            if (operandStr[0] == specialSymbol)
            {
                string numberStr = operandStr.Substring(1);

                int operandDigit;
                if (!int.TryParse(numberStr, out operandDigit))
                    throw new ArgumentException();

                number = resultsRepository.ResultList.ElementAt(operandDigit);
            }
            else
            {
                if (!decimal.TryParse(operandStr, out number))
                    throw new ArgumentException();
            }

            return number;
        }

        /// <summary>
        /// Возвращает маркер (ссылку) на число в хранилище результатов.
        /// </summary>
        /// <param name="operand"></param>
        /// <returns></returns>
        public string ParseNumber(decimal operand)
        {
            string operandStr = String.Empty;
            int index = resultsRepository.GetIndex(operand);

            if (index != -1)
                operandStr = specialSymbol + index.ToString(CultureInfo.InvariantCulture);

            return operandStr;
        }
    }
}