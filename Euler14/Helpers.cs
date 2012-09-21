using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    public static class Helpers
    {
        public static bool IsEven(this long number)
        {
            return number % 2 == 0;
        }

        public static long ApplyEvenRule(long number)
        {
            return number / 2;
        }

        public static long ApplyOddRule(long number)
        {
            return 3 * number + 1;
        }
    }

    public static class EulerStopwatch
    {
        static Stopwatch stopwatch = new Stopwatch();
        public static void Start()
        {
            stopwatch.Reset();
            stopwatch.Start();
        }
        public static void Stop()
        {
            stopwatch.Stop();
        }
        public static long ElapsedMilliseconds
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }
    }
}
