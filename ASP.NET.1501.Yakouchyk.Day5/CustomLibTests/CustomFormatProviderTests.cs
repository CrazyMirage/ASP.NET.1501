using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Custom;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Custom.Tests
{
    [TestClass()]
    public class CustomFormatProviderTests
    {
        public TestContext TestContext { get; set; }

        [DataSource(
            "Microsoft.VisualStudio.TestTools.DataSource.XML",
            "|DataDirectory|\\TestData\\FormatProviderData.xml",
            "TestCase",
            DataAccessMethod.Sequential)]
        //[DeploymentItem("CustomFormatter.Tests\\TestData.xml")]
        [TestMethod()]
        public void FormatTest()
        {
            int testNumber = Convert.ToInt32(TestContext.DataRow["Value"]);
            string arg = Convert.ToString(TestContext.DataRow["Arg"]);
            string expected = Convert.ToString(TestContext.DataRow["ExpectedResult"]);

            string result = string.Format(new CustomFormatProvider(), "{0:"+arg+"}", testNumber);

            Assert.AreEqual(expected, result);
        }

    }
}
