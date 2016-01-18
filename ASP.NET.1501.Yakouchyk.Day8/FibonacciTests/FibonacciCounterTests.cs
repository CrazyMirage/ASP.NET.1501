using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fibonacci;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Fibonacci.Tests
{
    [TestClass()]
    public class FibonacciCounterTests
    {
        
        [TestMethod()]
        public void GetNumbersTest()
        {
            int[] expected = new[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34, 55, 89 };
            List<int> result = new List<int>(FibonacciCounter.GetNumbers(12));
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
