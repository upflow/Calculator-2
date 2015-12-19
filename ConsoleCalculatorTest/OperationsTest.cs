using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleCalculator.Operations;

namespace ConsoleCalculatorTest
{
    [TestClass]
    public class OperationsTest
    {
        [TestMethod]
        public void IsCorrectCalculateSum()
        {
            const decimal x = 10.5M;
            const decimal y = 9.5M;
            var sum = new SumOperation(1);

            var result = sum.Calculate(x, y);

            Assert.AreEqual(20, result);
        }

        [TestMethod]
        public void IsCorrectCalculateDifferent()
        {
            const decimal x = 10.5M;
            const decimal y = 9.5M;
            var diff = new DifferentOperation(1);

            decimal result = diff.Calculate(x, y);

            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void IsCorrectCalculateMultipication()
        {
            decimal x = 10;
            decimal y = 5;
            var multip = new MultiplicationOperation(0);

            decimal result = multip.Calculate(x, y);

            Assert.AreEqual(50, result);
        }

        [TestMethod]
        public void IsCorrectCalculateDivision()
        {
            decimal x = 10;
            decimal y = 4;
            DivisionOperation div = new DivisionOperation(0);

            decimal result = div.Calculate(x, y);

            Assert.AreEqual(2.5M, result);
        }
    }
}
