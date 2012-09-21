using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Generate
    {
        public static IEnumerable<int> TriangleNumbers()
        {
            int triangleNumber = 0, i = 0;

            while(true)
            {
                triangleNumber = checked(triangleNumber + i);
                yield return triangleNumber;
                i++;
            }
        }

        public static IEnumerable<long> FibonacciNumbers(int maxFibonacciNumber)
        {
            yield return 0;
            yield return 1;

            long previous = 0, current = 1;

            while (maxFibonacciNumber > current)
            {
                long next = checked(previous + current);
                yield return next;
                previous = current;
                current = next;

            }
            yield break;
        }
    }
}
