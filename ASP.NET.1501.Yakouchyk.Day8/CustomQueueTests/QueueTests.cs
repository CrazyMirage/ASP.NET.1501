using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomQueue;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace CustomQueue.Tests
{
    [TestClass()]
    public class QueueTests
    {
        private int[] testedData = new[] {1, 6, 98, 76};
        
        [TestMethod()]
        public void EnqueueTest()
        {
            Queue<int> tested = new Queue<int>();
            int[] expected = testedData;
            foreach(int val in expected)
                tested.Enqueue(val);
            int[] result = tested.ToArray();

            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void DequeueTest()
        {
            Queue<int> empty = new Queue<int>();
            Queue<int> testedQueue = new Queue<int>(testedData);
            List<int> expected = new List<int>(testedData);
            List<int> result = new List<int>();

            while (!testedQueue.Empty())
                result.Add(testedQueue.Dequeue());

            CollectionAssert.AreEqual(testedQueue.ToArray(), empty.ToArray());
            CollectionAssert.AreEqual(expected, result);
        }

        [TestMethod()]
        public void PeekTest()
        {
            Queue<int> testedQueue = new Queue<int>(testedData);
            List<int> expected = new List<int>(testedData);

            int result = testedQueue.Peek();

            CollectionAssert.AreEqual(expected.ToArray(), testedQueue.ToArray());
            Assert.AreEqual(testedData[0], result);
        }

        [TestMethod()]
        public void GetEnumeratorTest()
        {
            Queue<int> testedQueue = new Queue<int>(testedData);
            List<int> expected = new List<int>(testedData);
            List<int> result = new List<int>();

            foreach (var elem in testedQueue)
            {
                result.Add(elem);
            }

            CollectionAssert.AreEqual(expected, result);
        }
    }
}
