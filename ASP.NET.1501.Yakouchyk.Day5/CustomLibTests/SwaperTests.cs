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
    public class SwaperTests
    {
        [TestMethod()]
        public void SwapTestReference()
        {
          object first = new object(), first_ref = first;
          object second = new object(), second_ref = second;

          Swaper.Swap(ref first, ref second);

          Assert.ReferenceEquals(first_ref, second);
          Assert.ReferenceEquals(second_ref, first);
        }


        [TestMethod()]
        public void SwapTestValue()
        {
            int first = new int(), first_ref = first;
            int second = new int(), second_ref = second;

            Swaper.Swap(ref first, ref second);

            Assert.AreEqual(first_ref, second);
            Assert.AreEqual(second_ref, first);
        }
    }
}
