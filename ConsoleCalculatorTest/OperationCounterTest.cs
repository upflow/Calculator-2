using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using Moq;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class OperationCounterTest
    {
        [TestMethod]
        public void IsCorrectCountOperationsInStr()
        {
            Mock<ICalculator> mockCalc = new Mock<ICalculator>();
            mockCalc.Setup(x => x.GetOperationsSymbolsCollection()).Returns(new List<char>()
            {
                '+', '-', '*', '/'
            }.AsEnumerable());

            string mathStr1 = "-50*(3-7/(32-69+59))";
            OperationCounter operCounter = new OperationCounter(mockCalc.Object);

            int count = operCounter.GetCountOperations(mathStr1);

            Assert.AreEqual(5, count);
        }
    }
}
