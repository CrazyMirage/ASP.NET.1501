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
            if (count <= 0)
                throw new ArgumentOutOfRangeException("count", "Too small");
            if (count > 47)
                throw new ArgumentOutOfRangeException("count", "Too big");

            int previous = 0;
            yield return previous;
            if (count > 1)
            {
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
}
