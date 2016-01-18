using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public abstract class AbstractSquareMatrix<T>
    {
        public event EventHandler<ElementChengedEventArgs> ElementChanged = delegate { };

        public delegate void Custom(int a, int b);

        public int Size { get; protected set; }

        abstract public T this[int i, int j] { get; set; }

        protected virtual void OnElementChanged(ElementChengedEventArgs arg)
        {
            ElementChanged(this, arg);
        }
    }
}
