using System;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculator
{
    /// <summary>
    /// Обрезает абсолютно все пробелы в строке.
    /// </summary>
    public class WhiteSpaceTrimer : IWhiteSpaceTrimer
    {
        public string DeleteWhiteSpaces(string str)
        {
            string tempStr = str;

            tempStr = tempStr.Trim();
            tempStr = tempStr.Replace(" ", String.Empty);
            return tempStr;
        }
    }
}