using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class ResultsRepositoryTest
    {
        [TestMethod]
        public void AddNumberToRepositoryAndReturnIndex()
        {
            decimal num1 = 42.5M;
            decimal num2 = 56;
            ResultsRepository repository = new ResultsRepository();

            int res1 = repository.Add(num1);
            int res2 = repository.Add(num2);

            Assert.IsTrue(repository.ResultList.Count() == 2);
            Assert.AreEqual(repository.ResultList.ElementAt(res1), num1);
            Assert.AreEqual(repository.ResultList.ElementAt(res2), num2);
        }
    }
}
