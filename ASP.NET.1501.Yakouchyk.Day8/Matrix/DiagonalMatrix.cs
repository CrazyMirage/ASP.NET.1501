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
            : base(size)
        {

        }

        public override T this[int i, int j]
        {
            get
            {
                return base[i, j];
            }
            set
            {
                if (i != j)
                    throw new ArgumentOutOfRangeException();
                base[i, j] = value;
            }
        }
    }
}
