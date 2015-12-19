using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class BracketRemoverTest
    {
        [TestMethod]
        public void GetExpressionInRightBrackets()
        {
            string mathStr1 = "(-50,42*34)/(14*(17-12))";
            string mathStr2 = "40*90/43-80";
            BracketRemover bracketRemover1 = new BracketRemover(new OpenBracket(), new CloseBracket());
            BracketRemover bracketRemover2 = new BracketRemover(new OpenBracket(), new CloseBracket());

            var result1 = bracketRemover1.GetExpressionInRightBrackets(mathStr1);
            var result2 = bracketRemover1.GetExpressionInRightBrackets(mathStr2);

            Assert.AreEqual(result1.ExpressionText, "17-12");
            Assert.AreEqual(result1.IndexInString, 17);

            Assert.AreEqual(result2.ExpressionText, "");
            Assert.AreEqual(result2.IndexInString, 0);
        }
    }
}
