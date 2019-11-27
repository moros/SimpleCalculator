using NUnit.Framework;
using SimpleCalculator;
using System.Collections.Generic;

namespace Tests
{
    public class CalculatorTests
    {
        private static IEnumerable<TestCaseData> NumberCases()
        {
            yield return new TestCaseData(":", new[] { 2, 3 }, 5);
            yield return new TestCaseData(",", new[] { 5, 1 }, 6);
            yield return new TestCaseData("-", new[] { 3, 7 }, 10);
            yield return new TestCaseData("&", new[] { 3, 5, 8, 2 }, 18);
        }

        [Test]
        public void Add_ShouldReturn0_ForEmptyString()
        {
            var calculator = new Calculator();
            var sum = calculator.Add(string.Empty);

            Assert.AreEqual(0, sum);
        }

        [Test]
        public void Add_ShouldReturn0_ForNullString()
        {
            var calculator = new Calculator();
            var sum = calculator.Add(null);

            Assert.AreEqual(0, sum);
        }

        [Test, TestCaseSource("NumberCases")]
        public void Add_ShouldHandle_DifferentDelimitors(string delimitor, int[] numbers, int expectedSum)
        {
            var calculator = new Calculator();
            var sum = calculator.Add($"//{delimitor}\n{string.Join(delimitor, numbers)}");

            Assert.AreEqual(expectedSum, sum);
        }

        [TestCase("1\\n2,3", 6)]
        [TestCase("1\n2,3", 6)]
        [TestCase("1\n2\n,3", 6)]
        public void Add_ShouldHandle_NewLineBetweenNumbers(string input, int expectedSum)
        {
            var calculator = new Calculator();
            var sum = calculator.Add(input);

            Assert.AreEqual(expectedSum, sum);
        }
    }
}