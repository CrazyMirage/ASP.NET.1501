using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Custom.Tests
{
    [TestClass()]
    public class SimpleMathTests
    {
        public TestContext TestContext { get; set; }


        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData\\MathData.xml",
            "RootTestCase",
            DataAccessMethod.Sequential)]
        [TestMethod()]
        public void RootTest()
        {
            double testNumber = Convert.ToInt32(TestContext.DataRow["Number"]);
            int power = Convert.ToInt32(TestContext.DataRow["Power"]);
            double eps = Convert.ToDouble(TestContext.DataRow["Eps"]);
            double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            double result = SimpleMath.Root(testNumber, power, eps);

            Assert.AreEqual(expected, result, eps);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void RootTestOutOfRangeException()
        {
            double testNumber = 1;
            int power = -10;

            SimpleMath.Root(testNumber, power);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void RootTestException()
        {
            double testNumber = -1;
            int power = 2;

            SimpleMath.Root(testNumber, power);
        }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData\\MathData.xml",
            "PowTestCase",
            DataAccessMethod.Sequential)]
        [TestMethod()]
        public void PowTest()
        {
            double number = Convert.ToDouble(TestContext.DataRow["Number"]);
            int power = Convert.ToInt32(TestContext.DataRow["Power"]);
            double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            double result = SimpleMath.Pow(number, power);

            Assert.AreEqual(expected, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PowTestException()
        {
            double number = 1;
            int power = -1;
            
            SimpleMath.Pow(number, power);
        }

        [TestMethod()]
        public void GCDTest()
        {
          int a = 40;
          int b = -15;
          int result = SimpleMath.GCD(a, b);

          Assert.AreEqual(5, result);
        }

        [TestMethod()]
        public void GCDTestMultivariable()
        {
            int a = 48;
            int b = 15;
            int c = 33;
            int result = SimpleMath.GCD(a, b,c);

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GCDTestNullException()
        {
            SimpleMath.GCD(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void GCDTestException()
        {
            SimpleMath.GCD();
        }

        [TestMethod()]
        public void BinaryGCDTest()
        {
            int a = 39;
            int b = -15;
            int result = SimpleMath.BinaryGCD(a, b);

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        public void BinaryGCDTestMultivariable()
        {
            int a = 48;
            int b = 15;
            int c = 33;
            int result = SimpleMath.BinaryGCD(a, b, c);

            Assert.AreEqual(3, result);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinaryGCDTestNullException()
        {
            SimpleMath.BinaryGCD(null);
        }

        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        public void BinaryGCDTestException()
        {
            SimpleMath.BinaryGCD();
        }
    }
}
