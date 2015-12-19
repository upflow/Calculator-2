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
    public class PriorityOperationFinderTest
    {
        private Mock<IOperationsPriorities> mockOperPrior;

        [TestInitialize]
        public void Initialize()
        {
            mockOperPrior = new Mock<IOperationsPriorities>();
            mockOperPrior
                .Setup(x => x.GetPriorityCollection())
                .Returns(new List<int>() { 2, 1 }.AsEnumerable());

            mockOperPrior
                .Setup(x => x.GetPrioritySymbolCollection(It.IsAny<int>()))
                .Returns<int>(p =>
                    {
                        var list = new List<char>();
                        if (p == 1) list.AddRange(new[] { '+', '-' });
                        if (p == 2) list.AddRange(new[] { '*', '/' });
                        return list;
                    });
        }

        [TestMethod]
        public void FindInStringFirstOperationSymbolByPriority()
        {
            string str1 = "-30,6-50*12,5";
            string str2 = "-30,6-50";
            PriorityOperationFinder pof = new PriorityOperationFinder(mockOperPrior.Object);

            var result1 = pof.FindFirst(str1);
            var result2 = pof.FindFirst(str2);

            Assert.AreEqual(result1.PositionIndex, 8);
            Assert.AreEqual(result1.OperationSymbol, '*');

            Assert.AreEqual(result2.PositionIndex, 5);
            Assert.AreEqual(result2.OperationSymbol, '-');
        }
    }
}
