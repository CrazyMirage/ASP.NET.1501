﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class SymmetricMatrix<T> : SquareMatrix<T>
    {
        public SymmetricMatrix(int size)
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
                base[i, j] = value;
                base[j, i] = value;
            }
        }
    }
}
