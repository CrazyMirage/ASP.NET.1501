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
    public class MatrixTests
    {
        private class SumComparator : IComparator<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int sumLeft = 0;
                foreach (int element in lhs)
                    sumLeft += element;

                int sumRight = 0;
                foreach (int element in rhs)
                    sumRight += element;

                return Math.Abs(sumLeft) - Math.Abs(sumRight);
            }
        }

        private class MaxAbsElementComparator : IComparator<int[]>
        {
            public int Compare(int[] lhs, int[] rhs)
            {
                int maxLeft = Math.Abs(lhs[0]);
                foreach (int element in lhs)
                    if (maxLeft < Math.Abs(element))
                        maxLeft = Math.Abs(element);

                int maxRight = Math.Abs(rhs[0]);
                foreach (int element in rhs)
                    if (maxRight < Math.Abs(element))
                        maxRight = Math.Abs(element);

                return maxRight - maxLeft;
            }
        }

        [TestMethod]
        public void SortTestSum()
        {
            int[][] matrix = new[]
            {
                new[] {1, 3, 948},
                new[] {5, 1, -47, 98},
                new[] {234, 54, -34, 0}
            };
            int[][] expected = new[]
            {
                new[] {1, 3, 948},
                new[] {234, 54, -34, 0},
                new[] {5, 1, -47, 98}
            };
            Matrix.Sort(matrix, new SumComparator());

            Assert.AreEqual(expected.Length, matrix.Length);
            for (int i = 0; i < matrix.Length; i++)
                CollectionAssert.AreEquivalent(expected[i], matrix[i]);
        }

        [TestMethod]
        public void SortTestMaxAbsElement()
        {
            int[][] matrix = new[]
            {
                new[] {1, 3, -948},
                new[] {5, 1, -47, 98},
                new[] {94, 54, -34, 0}
            };
            int[][] expected = new[]
            {
                new[] {94, 54, -34, 0},
                new[] {5, 1, -47, 98},
                new[] {1, 3, -948}
            };
            Matrix.Sort(matrix, new MaxAbsElementComparator());


            Assert.AreEqual(expected.Length, matrix.Length);
            for (int i = 0; i < matrix.Length; i++)
                CollectionAssert.AreEquivalent(expected[i], matrix[i]);
        }
        
        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortTestNullArgumentFirst()
        {
            int[][] matrix = null;
            Matrix.Sort(matrix, new SumComparator());
        }

        [TestMethod]
        [ExpectedException(typeof (ArgumentNullException))]
        public void SortTestNullArgumentSecond()
        {
            int[][] matrix = new[]
            {
                new[] {1, 3, -948},
                new[] {5, 1, -47, 98},
                new[] {94, 54, -34, 0}
            };
            SumComparator comparator = null;
            Matrix.Sort(matrix, comparator);
        }
    }
}
