using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class WhiteSpaceTrimerTest
    {
        [TestMethod]
        public void DeleteAllSpacesAndReturnResultStr()
        {
            string mathStr = "-60 + 60   *30/    10   ";
            WhiteSpaceTrimer wst = new WhiteSpaceTrimer();

            string result = wst.DeleteWhiteSpaces(mathStr);

            Assert.AreEqual("-60+60*30/10", result);
        }
    }
}
