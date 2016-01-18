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
    public class MatrixExtensionTests
    {
        [TestMethod()]
        public void SumTest()
        {
            DiagonalMatrix<int> first = new DiagonalMatrix<int>(3);
            first[1, 1] = 1;
            DiagonalMatrix<int> second = new DiagonalMatrix<int>(3);
            second[1, 1] = -1;
            int[,] expected = new[,]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
            SquareMatrix<int> output = first.Sum(second, (x, y) => x + y);

            int[,] result = new int[output.Size, output.Size];
            for (int i = 0; i < output.Size; i++)
                for (int j = 0; j < output.Size; j++)
                    result[i, j] = output[i, j];
            CollectionAssert.AreEqual(expected, result);
        }

        [ExpectedException(typeof(ArgumentException))]
        [TestMethod()]
        public void SumTestException()
        {
            DiagonalMatrix<int> first = new DiagonalMatrix<int>(3);
            DiagonalMatrix<int> second = new DiagonalMatrix<int>(4);
            SquareMatrix<int> output = first.Sum(second, (x, y) => x + y);
        }
    }
}
