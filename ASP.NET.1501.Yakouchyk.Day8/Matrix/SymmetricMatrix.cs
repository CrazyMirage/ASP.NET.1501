using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size)
        {
            matrix = new T[(size + 1) * size / 2];
            Size = size;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (Exist(i, j))
                {
                    if (i >= j) 
                    {
                        return matrix[(i + 1) * i / 2 + j];
                    }
                    else
                    {
                        return matrix[(j + 1) * j / 2 + i];
                    }
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (!Exist(i, j))
                    throw new ArgumentOutOfRangeException();
                if (i >= j)
                {
                    matrix[(i + 1) * i / 2 + j] = value;
                }
                else
                {
                    matrix[(j + 1) * j / 2 + i] = value;
                }
            }
        }
    }
}
