using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class ElementChengedEventArgs : EventArgs
    {
        public int I { get; private set; }
        public int J { get; private set; }

        public ElementChengedEventArgs(int i, int j)
        {
            I = i;
            J = j;
        }
    }
}
