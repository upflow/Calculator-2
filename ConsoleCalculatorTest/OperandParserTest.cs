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
    public class OperandParserTest
    {
        private Mock<IResultsRepository> mockResRepo;

        [TestInitialize]
        public void Initialize()
        {
            mockResRepo = new Mock<IResultsRepository>();
            mockResRepo.Setup(m => m.ResultList).Returns(new List<decimal> { 10, 23.5M, 15.3M });
            mockResRepo.Setup(g => g.GetIndex(It.Is<decimal>(d => d == 23.5M))).Returns(1);
        }

        [TestMethod]
        public void ParseStrToDecimalIfFirstSpecialSymbolReturnResultFromRepository()
        {
            string str1 = "45,5";
            string str2 = "#2";

            OperandParser operandParser = new OperandParser(mockResRepo.Object);

            decimal result1 = operandParser.ParseString(str1);
            decimal result2 = operandParser.ParseString(str2);
            
            Assert.AreEqual(45.5M, result1);
            Assert.AreEqual(15.3M, result2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseStrToDesimal_Fail1()
        {
            string str = "#45,5";
            OperandParser operandParser = new OperandParser(mockResRepo.Object);

            decimal result = operandParser.ParseString(str);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ParseStrToDesimal_Fail2()
        {
            string str = "fail";
            OperandParser operandParser = new OperandParser(mockResRepo.Object);

            decimal result = operandParser.ParseString(str);
        }

        [TestMethod]
        public void ParseDecimalToStrFromResultsRepository()
        {
            decimal x = 23.5M;
            OperandParser operandParser = new OperandParser(mockResRepo.Object);

            string result = operandParser.ParseNumber(x);

            Assert.AreEqual("#1", result);
        }
    }
}
