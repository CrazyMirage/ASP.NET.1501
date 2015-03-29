using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SquareMatrix<T>
    {
        protected T[,] matrix;
        public int Size { get; private set; }


        public event EventHandler<ElementChengedEventArgs> ElementChanged = delegate { };

        public SquareMatrix(int size)
        {
            matrix = new T[size, size];
            Size = size;
        }

        protected virtual void OnElementChanged(int i, int j)
        {
            ElementChanged(this, new ElementChengedEventArgs(i, j));
        }

        public virtual T this[int i, int j]
        {
            get
            {
                if (i >= 0 && j >= 0 && i < Size && j < Size)
                {
                    return matrix[i, j];
                }
                else
                    throw new ArgumentOutOfRangeException();
            }

            set
            {
                if (i >= 0 && j >= 0 && i < Size && j < Size)
                {
                    matrix[i, j] = value;
                    OnElementChanged(i, j);
                }
                else
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
