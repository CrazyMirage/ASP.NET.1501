using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Custom;

namespace Custom.Tests
{
    [TestClass()]
    public class PolynomTests
    {
        [TestMethod()]
        public void MultiplyTest()
        {
            Polynom polynom1 = new Polynom(3, 5, 1);
            double x = 3;

            Polynom expected = new Polynom(9, 15, 3);

            Polynom result = 3* polynom1;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void SubtractionTest()
        {
            Polynom polynom1 = new Polynom(3, 5, 1);
            Polynom polynom2 = new Polynom(1, 2, 1);

            Polynom expected = new Polynom(2, 3, 0);

            Polynom result = polynom1 - polynom2;

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void AddTest()
        {
            Polynom polynom1 = new Polynom(3, 5, 1);
            Polynom polynom2 = new Polynom(1, 2, 1);

            Polynom expected = new Polynom(4,7, 2);

            Polynom result = polynom1 + polynom2;

            Assert.AreEqual(expected,result);
        }

        [TestMethod()]
        public void CalculateTest()
        {
          Polynom polynom = new Polynom(3, 5, 1);
          double x = 2;
          double expected = 17;

          double result = polynom.Calculate(x);

          Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void EqualsTestFalse()
        {

            Polynom polynom1 = new Polynom(1, 2, 1);

            Polynom polynom2 = new Polynom(4, 7, 2);

          Assert.IsFalse(polynom1.Equals(polynom2));
        }

        [TestMethod()]
        public void EqualsTestTrue()
        {

            Polynom polynom1 = new Polynom(4, 7, 2, 0);

            Polynom polynom2 = new Polynom(4, 7, 2);

            Assert.IsTrue(polynom1.Equals(polynom2));
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SumTestException()
        {
            Polynom polynom1 = new Polynom(3, 5, 1);
            Polynom polynom2 = null;
            
            Polynom result = polynom1 + null;
        }
    }
}
