using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fibonacci
{
    public static class FibonacciCounter
    {
        public static IEnumerable<int> GetNumbers(int count)
        {
            int previous = 0;
            yield return previous;
            int current = 1;
            yield return current;
            for (int i = 2; i < count; i++)
            {
                int temp;
                yield return temp = current + previous;
                previous = current;
                current = temp;
            }
        }
    }
}
