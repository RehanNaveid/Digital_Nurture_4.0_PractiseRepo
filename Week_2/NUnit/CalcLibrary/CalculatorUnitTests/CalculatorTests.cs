using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalculatorUnitTests
{
    [TestFixture]
    public class CalculatorTests
    {
        private SimpleCalculator calc;

        [SetUp]
        public void Init()
        {
            calc = new SimpleCalculator();
        }

        [TearDown]
        public void Cleanup()
        {
            calc = null;
        }

        [Test]
        [TestCase(5, 3, 8)]
        [TestCase(-2, -3, -5)]
        [TestCase(0, 0, 0)]
        public void Addition_WhenCalled_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calc.Addition(a, b);
            Assert.That(result, Is.EqualTo(expected));
            Assert.That(calc.GetResult, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(5, 3, 2)]
        [TestCase(-2, -3, 1)]
        [TestCase(0, 0, 0)]
        public void Subtraction_WhenCalled_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calc.Subtraction(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(5, 3, 15)]
        [TestCase(-2, -3, 6)]
        [TestCase(0, 100, 0)]
        public void Multiplication_WhenCalled_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calc.Multiplication(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        [TestCase(10, 2, 5)]
        [TestCase(-9, 3, -3)]
        public void Division_WhenCalled_ReturnsCorrectResult(double a, double b, double expected)
        {
            var result = calc.Division(a, b);
            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            var ex = Assert.Throws<ArgumentException>(() => calc.Division(10, 0));
            Assert.That(ex.Message, Is.EqualTo("Second Parameter Can't be Zero"));
        }

        [Test]
        public void AllClear_ShouldResetResultToZero()
        {
            calc.Addition(5, 5);  // Sets result to 10
            calc.AllClear();
            Assert.That(calc.GetResult, Is.EqualTo(0));
        }
    }
}
