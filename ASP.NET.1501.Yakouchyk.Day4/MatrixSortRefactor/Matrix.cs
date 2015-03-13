using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Custom
{

    public interface IComparator<T>
    {
      int Compare(T lhs, T rhs);
    }


    public static class Matrix
    {
        static public void Sort<T>(T[] matrix, IComparator<T> comparator)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = i; j < matrix.Length; j++)
                {
                    if (comparator.Compare(matrix[i], matrix[j]) < 0)
                    {
                        Swaper.Swap(ref matrix[i], ref matrix[j]);
                    }

                }
        }
    }
}
