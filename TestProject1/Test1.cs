using Microsoft.VisualStudio.TestTools.UnitTesting;
using ConsoleApp2;

namespace TestProject1
{
    [TestClass()]
    public class RationalTests
    {
        [TestMethod()]
        public void Reduce_Simple()
        {
            var fraction = new Rational(3, 4);
            var reduced = fraction.Reduce();
            Assert.AreEqual(3, reduced.Numerator);
            Assert.AreEqual(4, reduced.Denominator);
        }

        [TestMethod()]
        public void Reduce_Reducible()
        {
            var fraction = new Rational(8, 12);
            var reduced = fraction.Reduce();
            Assert.AreEqual(2, reduced.Numerator);
            Assert.AreEqual(3, reduced.Denominator);
        }

        [TestMethod()]
        public void Reduce_Large()
        {
            var fraction = new Rational(48, 180);
            var reduced = fraction.Reduce();
            Assert.AreEqual(4, reduced.Numerator);
            Assert.AreEqual(15, reduced.Denominator);
        }

        [TestMethod()]
        public void Reduce_Negative()
        {
            var fraction = new Rational(-8, 12);
            var reduced = fraction.Reduce();
            Assert.AreEqual(-2, reduced.Numerator);
            Assert.AreEqual(3, reduced.Denominator);
        }


        [TestMethod()]
        public void Addition_Positive()
        {
            var a = new Rational(1, 2);
            var b = new Rational(1, 3);
            var result = a + b;
            Assert.AreEqual("5/6", result.Verbose());
        }

        [TestMethod()]
        public void Addition_WithNegative()
        {
            var a = new Rational(1, 2);
            var b = new Rational(-1, 3);
            var result = a + b;
            Assert.AreEqual("1/6", result.Verbose());
        }

        [TestMethod()]
        public void Addition_ResultZero()
        {
            var a = new Rational(1, 2);
            var b = new Rational(-1, 2);
            var result = a + b;
            Assert.AreEqual("0/1", result.Verbose());
        }

        [TestMethod()]
        public void Subtraction_Positive()
        {
            var a = new Rational(3, 4);
            var b = new Rational(1, 4);
            var result = a - b;
            Assert.AreEqual("1/2", result.Verbose());
        }

        [TestMethod()]
        public void Subtraction_WithNegative()
        {
            var a = new Rational(1, 2);
            var b = new Rational(-1, 3);
            var result = a - b;
            Assert.AreEqual("5/6", result.Verbose());
        }

        [TestMethod()]
        public void Subtraction_ResultNegativee()
        {
            var a = new Rational(1, 3);
            var b = new Rational(1, 2);
            var result = a - b;
            Assert.AreEqual("-1/6", result.Verbose());
        }

        [TestMethod()]
        public void Multiplication_Positive()
        {
            var a = new Rational(2, 3);
            var b = new Rational(3, 4);
            var result = a * b;
            Assert.AreEqual("1/2", result.Verbose());
        }

        [TestMethod()]
        public void Multiplication_WithNegative()
        {
            var a = new Rational(2, 3);
            var b = new Rational(-3, 4);
            var result = a * b;
            Assert.AreEqual("-1/2", result.Verbose());
        }

        [TestMethod()]
        public void Multiplication_ByZero()
        {
            var a = new Rational(2, 3);
            var b = new Rational(0, 1);
            var result = a * b;
            Assert.AreEqual("0/1", result.Verbose());
        }

        [TestMethod()]
        public void Division_Positive()
        {
            var a = new Rational(3, 4);
            var b = new Rational(1, 2);
            var result = a / b;
            Assert.AreEqual("3/2", result.Verbose());
        }

        [TestMethod()]
        public void Division_WithNegative()
        {
            var a = new Rational(3, 4);
            var b = new Rational(-1, 2);
            var result = a / b;
            Assert.AreEqual("-3/2", result.Verbose());
        }

        [TestMethod()]
        public void Equality_Equal()
        {
            var a = new Rational(1, 2);
            var b = new Rational(2, 4);
            Assert.IsTrue(a == b);
        }

        [TestMethod()]
        public void Equality_Different()
        {
            var a = new Rational(1, 2);
            var b = new Rational(2, 3);
            Assert.IsFalse(a == b);
        }

        [TestMethod()]
        public void Inequality_NotEqual()
        {
            var a = new Rational(1, 2);
            var b = new Rational(2, 3);
            Assert.IsTrue(a != b);
        }

        [TestMethod()]
        public void GreaterThan_FirstLarger()
        {
            var a = new Rational(2, 3);
            var b = new Rational(1, 2);
            Assert.IsTrue(a > b);
        }

        [TestMethod()]
        public void GreaterThan_FirstSmaller()
        {
            var a = new Rational(1, 3);
            var b = new Rational(1, 2);
            Assert.IsFalse(a > b);
        }

        [TestMethod()]
        public void LessThan_FirstSmaller()
        {
            var a = new Rational(1, 3);
            var b = new Rational(1, 2);
            Assert.IsTrue(a < b);
        }

        [TestMethod()]
        public void LessThan_FirstLarge()
        {
            var a = new Rational(2, 3);
            var b = new Rational(1, 2);
            Assert.IsFalse(a < b);
        }
    }
}
