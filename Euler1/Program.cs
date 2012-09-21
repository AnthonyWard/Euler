using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler1
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.Go();
            int sum = 0;
            for (int i = 1; i < 1000; i++)
                if (i % 3 == 0 || i % 5 == 0) sum += i;
            Console.WriteLine("Answer {0}. {1}ms. Traditional.", sum, Timer.ElapsedMilliseconds);

            Timer.Restart();
            sum = Enumerable
                .Range(1, 999)
                .Where(i => (i % 3 == 0 || i % 5 == 0))
                .Sum();
            Console.WriteLine("Answer {0}. {1}ms. LINQ.", sum, Timer.ElapsedMilliseconds);

            Timer.Restart();
            sum = Enumerable
                .Range(1, 999)
                .AsParallel()
                .Where(i => (i % 3 == 0 || i % 5 == 0))
                .Sum();
            Console.WriteLine("Answer {0}. {1}ms. P-LINQ.", sum, Timer.ElapsedMilliseconds);

        }
    }
}
