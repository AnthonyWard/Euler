using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Timer
    {
        static Stopwatch stopwatch = new Stopwatch();

        public static void Go()
        {
            stopwatch.Start();
        }

        public static long ElapsedMilliseconds
        {
            get
            {
                return stopwatch.ElapsedMilliseconds;
            }
        }

        public static void Restart()
        {
            stopwatch.Restart();
        }
    }
}
