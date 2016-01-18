using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class DiagonalMatrix<T> : SquareMatrix<T>
    {
        public DiagonalMatrix(int size)
        {
            matrix = new T[size];
            Size = size;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (Exist(i, j))
                {
                    if (i == j)
                        return matrix[i];
                    else
                        return default(T);
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (i != j || !Exist(i, j))
                    throw new ArgumentOutOfRangeException();
                matrix[i] = value;
            }
        }
    }
}
