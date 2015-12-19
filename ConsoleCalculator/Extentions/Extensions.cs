using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator.Extensions
{
    /// <summary>
    /// Расширения
    /// </summary>
    public static class Extensions
    {
        /// <summary>
        /// Расширение для типа String.
        /// Эквивалент Replace, но заменяет не все вхождения, а тольео указанное.
        /// Структура Expression содержит заменяемое вырлжение и индекс этого выражения в строке.
        /// Булевский параметр определяет, надо ли убирать скобки 
        /// (возможно в исходной строке это выражение стоит в скобках).
        /// </summary>
        /// <param name="sourceStr"></param>
        /// <param name="exp"></param>
        /// <param name="result"></param>
        /// <param name="isInBrackets"></param>
        /// <returns></returns>
        public static string ReplaceExpression(this string sourceStr, Expression exp, string result, bool isInBrackets)
        {
            string tempStr = sourceStr;
            int indent = 0;

            if (isInBrackets)
                indent = 1;

            tempStr = tempStr.Remove(exp.IndexInString - indent, exp.ExpressionText.Length + indent * 2);
            tempStr = tempStr.Insert(exp.IndexInString - indent, result);

            return tempStr;
        }
    }
}
