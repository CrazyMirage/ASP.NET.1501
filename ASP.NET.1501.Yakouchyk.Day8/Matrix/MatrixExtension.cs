using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public static class MatrixExtension
    {
        public static SquareMatrix<T> Sum<T>(this SquareMatrix<T> lhs, SquareMatrix<T> rhs, Func<T, T, T> sumCounter)
        {
            if (rhs == null)
                throw new ArgumentNullException();
            if (lhs.Size != rhs.Size)
                throw new ArgumentException("Different size in Matrix");

            SquareMatrix<T> result = new SquareMatrix<T>(lhs.Size);
            for (int i = 0; i < lhs.Size; i++)
            {
                for (int j = 0; j < lhs.Size; j++)
                {
                    result[i, j] = sumCounter(lhs[i, j], rhs[i, j]);
                }
            }
            return result;
        }
    }
}
