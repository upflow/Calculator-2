using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Хранит данные о мат. оперции.
    /// </summary>
    public class PositionOperation
    {
        public int PositionIndex { get; set; } // Индекс символа операции в строке.
        public char OperationSymbol { get; set; } // Символ опреции.

        public PositionOperation()
        {
            PositionIndex = -1;
        }
    }
}
