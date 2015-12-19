using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using ConsoleCalculator;
using ConsoleCalculator.Abstracts;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class OperationFinderTest
    {
        private Mock<ICalculator> mockCalc;

        [TestInitialize]
        public void Initialize()
        {
            mockCalc = new Mock<ICalculator>();
            mockCalc.Setup(x => x.GetOperationsSymbolsCollection()).Returns(new List<char>()
            {
                '+', '-', '*', '/'
            }.AsEnumerable());
        }

        [TestMethod]
        public void FindNextOperationAndReturnPositionOperation()
        {
            string text = "(50 * 79) / 20 + 10";
            OperationFinder operationFinder = new OperationFinder(mockCalc.Object);

            PositionOperation po1 = operationFinder.FindOperationNext(text);
            PositionOperation po2 = operationFinder.FindOperationNext(text, 5);
            PositionOperation po3 = operationFinder.FindOperationNext(text, 17);

            Assert.IsNotNull(po1);
            Assert.IsNotNull(po2);
            Assert.IsNotNull(po3);

            Assert.AreEqual(4, po1.PositionIndex);
            Assert.AreEqual('*', po1.OperationSymbol);

            Assert.AreEqual(10, po2.PositionIndex);
            Assert.AreEqual('/', po2.OperationSymbol);

            Assert.AreEqual(-1, po3.PositionIndex);
            Assert.AreEqual('\0', po3.OperationSymbol);
        }

        [TestMethod]
        public void FindPrevOperationAndReturnPositionOperation()
        {
            string text = "(50 * 79) / 20 + 10";
            OperationFinder operationFinder = new OperationFinder(mockCalc.Object);

            PositionOperation po1 = operationFinder.FindOperationPrev(text, 0);
            PositionOperation po2 = operationFinder.FindOperationPrev(text, 5);
            PositionOperation po3 = operationFinder.FindOperationPrev(text, 17);

            Assert.IsNotNull(po1);
            Assert.IsNotNull(po2);
            Assert.IsNotNull(po3);

            Assert.AreEqual(-1, po1.PositionIndex);
            Assert.AreEqual('\0', po1.OperationSymbol);

            Assert.AreEqual(4, po2.PositionIndex);
            Assert.AreEqual('*', po2.OperationSymbol);

            Assert.AreEqual(15, po3.PositionIndex);
            Assert.AreEqual('+', po3.OperationSymbol);
        }
    }
}
