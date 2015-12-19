using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;
using ConsoleCalculator.Extensions;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class ReplaceExpressionTest
    {
        [TestMethod]
        public void ExtensionStrMethodForReplaseFirstExpressionInThisStr()
        {
            string str = "80+97,5*44,8-12";
            string res = "%5";
            Expression expr = new Expression("97,5*44,8", 3);

            string result = str.ReplaceExpression(expr, res, false);

            Assert.AreEqual("80+%5-12", result);
        }
    }
}
