using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using Moq;
using ConsoleCalculator.Abstracts;
using ConsoleCalculator.Operations;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class OperationsPrioritiesTest
    {
        private Mock<ICalculator> mockCalc;

        [TestInitialize]
        public void Initialize()
        {
            mockCalc = new Mock<ICalculator>();
            mockCalc.Setup(x => x.OperationList).Returns(new List<IOperation>()
            {
                new SumOperation(5), new MultiplicationOperation(10), new DifferentOperation(5), new DivisionOperation(10)
            }.AsEnumerable());
        }

        [TestMethod]
        public void ReturnDistinctOperationsPriorityOrderByDecsending()
        {
            OperationsPriorities operPrior = new OperationsPriorities(mockCalc.Object);

            int[] priorities = operPrior.GetPriorityCollection().ToArray();

            Assert.IsTrue(priorities[0] > priorities[1]);
            Assert.AreEqual(priorities[0], 10);
            Assert.AreEqual(priorities[1], 5);
        }

        [TestMethod]
        public void ReturnOperationSymbolCollectionOnPriority()
        {
            OperationsPriorities operPrior = new OperationsPriorities(mockCalc.Object);

            char[] symbolArr1 = operPrior.GetPrioritySymbolCollection(10).ToArray();
            char[] symbolArr2 = operPrior.GetPrioritySymbolCollection(5).ToArray();

            Assert.IsTrue(symbolArr1.Count() == 2);
            Assert.AreEqual(symbolArr1[0], '*');
            Assert.AreEqual(symbolArr1[1], '/');

            Assert.IsTrue(symbolArr2.Count() == 2);
            Assert.AreEqual(symbolArr2[0], '+');
            Assert.AreEqual(symbolArr2[1], '-');
        }
    }
}
