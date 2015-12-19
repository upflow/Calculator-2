using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class BracketCounterTest
    {
        [TestMethod]
        public void GetCountOpenCloseBracketInString()
        {
            string bracketsStr1 = "43+(30*50 * (10 - 9))/((5+6) / 11)";
            string bracketsStr2 = "77 + (456 - 0) + (546 ( 435";

            var openBracket = new OpenBracket();
            var closeBracket = new CloseBracket();
            BracketCounter bracketCounter = new BracketCounter(openBracket, closeBracket);

            int result1 = bracketCounter.CountBrackets(bracketsStr1);
            int result2 = bracketCounter.CountBrackets(bracketsStr2);

            Assert.AreEqual(4, result1);
            Assert.AreEqual(-1, result2);
        }
    }
}
