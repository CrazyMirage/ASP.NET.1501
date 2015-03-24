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
    }
}
