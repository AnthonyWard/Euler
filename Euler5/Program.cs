using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Euler5
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.Go();
            var answer = Enumerable.Range(1, int.MaxValue).Where(x => x.CanBeDividedBy(1, 20)).First();
            Console.WriteLine("Answer {0}. {1}ms. LINQ.", answer, Timer.ElapsedMilliseconds);

            Timer.Restart();
            answer = Enumerable.Range(1, int.MaxValue).AsParallel().Where(x => x.CanBeDividedBy(1, 20)).First();
            Console.WriteLine("Answer {0}. {1}ms. P-LINQ.", answer, Timer.ElapsedMilliseconds);
        }
    }
}
