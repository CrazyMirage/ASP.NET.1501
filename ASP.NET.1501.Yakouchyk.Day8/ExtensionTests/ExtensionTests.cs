using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Extension;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Extension.Tests
{
    [TestClass()]
    public class ExtensionTests
    {
        private List<int> listInt = new List<int>(new[] { 1, 8, 3, 5, -23, 56, 9, -3, 4, 90});

        [TestMethod()]
        public void getEnumerableTestEven()
        {
            List<int> expected = new List<int>(new[] { 8, 56, 4, 90 });
            List<int> result = new List<int>();
            foreach(var el in listInt.GetEnumerable( x => x % 2 == 0))
                result.Add(el);
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void getEnumerableTestOnEvenPlace()
        {
            List<int> expected = new List<int>(new[] { 8, 5, 56, -3, 90 });
            List<int> result = new List<int>();
            int k = 0;
            foreach (var el in listInt.GetEnumerable(x => ++k % 2 == 0))
                result.Add(el);
            CollectionAssert.AreEqual(expected, result);
        }
    }
}
