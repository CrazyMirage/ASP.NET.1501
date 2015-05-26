using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Matrix;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace Matrix.Tests
{
    [TestClass()]
    public class SquareMatrixTests
    {
        [TestMethod]
        public void SquareMatrixTest()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);
            int value = -1;
            matrix[1, 2] = value;
            Assert.AreEqual(value, matrix[1, 2]);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void SquareMatrixTestException()
        {
            SquareMatrix<int> matrix = new SquareMatrix<int>(3);

            int result = matrix[5, 6];
        }
    }
}
