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
            if (comparator == null)
                throw new ArgumentNullException("comparator");
            Sort(matrix, comparator.Compare);
        }

        public static void Sort<T>(T[] matrix, Func<T,T, int> comparator)
        {
            if (matrix == null)
                throw new ArgumentNullException("matrix");

            if (comparator == null)
                throw new ArgumentNullException("comparator");

            for (int i = 0; i < matrix.Length; i++)
                for (int j = i; j < matrix.Length; j++)
                {
                    if (comparator(matrix[i], matrix[j]) < 0)
                    {
                        Swaper.Swap(ref matrix[i], ref matrix[j]);
                    }

                }
        }
    }
}
