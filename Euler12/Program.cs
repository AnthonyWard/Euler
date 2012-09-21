using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Euler12
{
    class Program
    {
        static int triangleNumber = 0;

        static void Main(string[] args)
        {
            Timer.Go();

            // LINQ version, single threaded
            triangleNumber = Generate
                .TriangleNumbers()
                .First(x => x.Divisors() > 500);

            Console.WriteLine("Triangle Number {0}. {1}ms. LINQ via a generator", triangleNumber, Timer.ElapsedMilliseconds);

            Timer.Restart();

            // P-LINQ version, multi threaded
            triangleNumber = Generate
                .TriangleNumbers()
                .AsParallel()
                .First(x => x.Divisors() > 500);

            Console.WriteLine("Triangle Number {0}. {1}ms. P-LINQ via a generator", triangleNumber, Timer.ElapsedMilliseconds);

        }
    }
}
