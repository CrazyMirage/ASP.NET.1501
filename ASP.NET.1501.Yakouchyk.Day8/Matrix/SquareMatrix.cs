using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        protected T[] matrix;

        protected SquareMatrix() { }

        public SquareMatrix(int size)
        {
            matrix = new T[size*size];
            Size = size;
        }

        public bool Exist(int i, int j)
        {
            return i >= 0 && j >= 0 && i < Size && j < Size;
        }

        public override T this[int i, int j]
        {
            get
            {
                if (Exist(i,j))
                {
                    return matrix[(i * Size) + j];
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (Exist(i, j))
                {
                    matrix[(i * Size) + j] = value;
                    OnElementChanged(new ElementChengedEventArgs(i, j));
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
