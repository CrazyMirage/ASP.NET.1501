using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMath;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CustomMath.Tests
{
    [TestClass()]
    public class SimpleMathTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData.xml",
            "RootTestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("CustomMath.Tests\\TestData.xml")]
        [TestMethod()]
        public void RootTest()
        {
            double testNumber = Convert.ToInt32(TestContext.DataRow["Number"]);
            uint power = Convert.ToUInt32(TestContext.DataRow["Power"]);
            double eps = Convert.ToDouble(TestContext.DataRow["Eps"]);
            double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            double result = SimpleMath.Root(testNumber, power, eps);

            //Assert.IsTrue(Math.Abs(result - expected) <= eps );
            Assert.AreEqual(expected, result, eps);
        }


        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData.xml",
            "PowTestCase",
            DataAccessMethod.Sequential)]
        [DeploymentItem("CustomMath.Tests\\TestData.xml")]
        [TestMethod()]
        public void PowTest()
        {
            double number = Convert.ToDouble(TestContext.DataRow["Number"]);
            uint power = Convert.ToUInt32(TestContext.DataRow["Power"]);
            double expected = Convert.ToDouble(TestContext.DataRow["ExpectedResult"]);

            double result = SimpleMath.Pow(number, power);

            Assert.AreEqual(expected, result);
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
    }
}
