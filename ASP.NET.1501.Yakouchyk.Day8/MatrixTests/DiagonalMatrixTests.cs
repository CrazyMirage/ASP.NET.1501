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
    public class DiagonalMatrixTests
    {
        [TestMethod]
        public void DiagonalMatrixTest()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3);
            int value = -1;
            matrix[1, 1] = value;
            Assert.AreEqual(value, matrix[1,1]);
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void DiagonalMatrixTestExceptionNotDiagonal()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3);

            matrix[1, 2] = 2;
        }

        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void DiagonalMatrixTestException()
        {
            DiagonalMatrix<int> matrix = new DiagonalMatrix<int>(3);

            int result = matrix[5, 6];
        }
    }
}
