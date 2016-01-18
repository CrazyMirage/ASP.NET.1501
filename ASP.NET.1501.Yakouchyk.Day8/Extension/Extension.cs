using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension
{
    public static class Extension
    {
        public static IEnumerable<T> GetEnumerable<T>(this IEnumerable<T> collection, Func<T, bool> solver)
        {
            foreach (T element in collection)
            {
                if (solver(element))
                    yield return element;
            }
        }

        public static int BinarySearch<T>(this IList<T> collection, T searched, Func<T, T, int> comparer)
        {

            if (comparer == null)
            {
                throw new ArgumentNullException("comparer");
            }

            int first = 0;
            int last = collection.Count;
            while (first < last)
            {
                int mid = first + (last - first)/2;
                int compareValue = comparer(searched, collection[mid]);
                if (compareValue == 0)
                {
                    return mid;
                }
                else if (compareValue > 0)
                {
                    first = mid;
                }
                else
                {
                    last = mid;
                }
            }
            return -1;
        }
    }
}
