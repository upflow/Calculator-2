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
    public class ExpressionExtractentTest
    {
        private Mock<IPriorityOperationFinder> mockPriorOperFinder;
        private Mock<IOperationFinder> mockOperationFinder;

        [TestInitialize]
        public void Initialize()
        {
            mockOperationFinder = new Mock<IOperationFinder>();
            mockOperationFinder
                .Setup(f => f.FindOperationNext(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new PositionOperation { PositionIndex = 9, OperationSymbol = '+' });

            mockOperationFinder
                .Setup(f => f.FindOperationPrev(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new PositionOperation());


            mockPriorOperFinder = new Mock<IPriorityOperationFinder>();
            mockPriorOperFinder
                .Setup(s => s.FindFirst(It.IsAny<string>()))
                .Returns(new PositionOperation() { PositionIndex = 2, OperationSymbol = '*' });
        }

        [TestMethod]
        public void GetFirstExpressionByPriorityOperationsFromMathString()
        {
            string str = "44*2357,8+55,7";
            var exprExtr = new ExpressionExtractent(mockOperationFinder.Object, mockPriorOperFinder.Object);

            var expr = exprExtr.CutFirstExpression(str);

            Assert.IsNotNull(expr);
            Assert.AreEqual(expr.ExpressionText, "44*2357,8");
            Assert.AreEqual(expr.IndexInString, 0);
        }
    }
}
