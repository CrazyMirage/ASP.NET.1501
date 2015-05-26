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
    public class SymmetricMatrixTests
    {
        [TestMethod]
        public void SymmetricMatrixTest()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3);
            int value = -1;
            matrix[1, 2] = value;
            Assert.AreEqual(value, matrix[2, 1]);
        }
        
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [TestMethod]
        public void SymmetricMatrixTestException()
        {
            SymmetricMatrix<int> matrix = new SymmetricMatrix<int>(3);

            int result = matrix[5, 6];
        }
    }
}
