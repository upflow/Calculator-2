using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleCalculator
{
    /// <summary>
    /// Хранит информацию об мат. опреции.
    /// </summary>
    public class OperationInfo
    {
        public decimal Operand1 { get; set; } // Левый операнд.
        public decimal Operand2 { get; set; } // Правый операнд.
        public char OperationSymbol { get; set; } // Символ операции.

        public OperationInfo(decimal operand1 = 0, decimal operand2 = 0, char operationSymbol = '\0')
        {
            Operand1 = operand1;
            Operand2 = operand2;
            OperationSymbol = operationSymbol;
        }
    }
}
