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
    public class ExpressionDelimiterTest
    {
        private Mock<IOperandParser> mockOperandParser;
        private Mock<IOperationFinder> mockOperationFinder;

        [TestInitialize]
        public void Initialize()
        {
            mockOperationFinder = new Mock<IOperationFinder>();
            mockOperationFinder
                .Setup(f => f.FindOperationNext(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new PositionOperation { PositionIndex = 2,  OperationSymbol = '+'});

            mockOperandParser = new Mock<IOperandParser>();
            mockOperandParser
                .Setup(s => s.ParseString(It.IsAny<string>()))
                .Returns<string>(s =>
                    {
                        decimal res = 0;
                        if (s[0] == '%') res = decimal.Parse(s.Substring(1));
                        else res = decimal.Parse(s);
                        return res;
                    });
        }

        [TestMethod]
        public void GetOperationInfoFromMathExpression()
        {
            string str = "30+%100";
            ExpressionDelimiter expDelim = new ExpressionDelimiter(mockOperandParser.Object, mockOperationFinder.Object);

            var result = expDelim.Divide(str);

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Operand1, 30);
            Assert.AreEqual(result.Operand2, 100);
            Assert.AreEqual(result.OperationSymbol, '+');
        }
    }
}
