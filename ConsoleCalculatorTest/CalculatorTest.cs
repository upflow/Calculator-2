using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using ConsoleCalculator.Abstracts;
using ConsoleCalculator.Operations;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class CalculatorTest
    {
        private IList<IOperation> operList;

        [TestInitialize]
        public void Initialize()
        {
            operList = new List<IOperation>()
            {
                new SumOperation(1),
                new MultiplicationOperation(0),
                new DifferentOperation(1),
                new DivisionOperation(0)
            };
        }

        [TestMethod]
        public void IsCorrectCalculate()
        { 
            Calculator calc = new Calculator(operList);
            var operInfo1 = new OperationInfo(50, 10, '+');
            var operInfo2 = new OperationInfo(50, 10, '/');
            var operInfo3 = new OperationInfo(3.5M, 3, '*');
            var operInfo4 = new OperationInfo(50, 10, '-');

            decimal resultSum = calc.Calculate(operInfo1);
            decimal resultDev = calc.Calculate(operInfo2);
            decimal resultMul = calc.Calculate(operInfo3);
            decimal resultDiff = calc.Calculate(operInfo4);

            Assert.IsNotNull(calc.OperationList);
            Assert.AreEqual(60, resultSum);
            Assert.AreEqual(5, resultDev);
            Assert.AreEqual(10.5M, resultMul);
            Assert.AreEqual(40, resultDiff);
        }
    }
}
