using Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler2
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer.Go();

            var fibonacciSeq = new List<long>();
            long newValue = 0;
            long currentValue = 2;
            long previousValue = 1;
            long sum = 2; //start at two as i'm skipping this below

            while (currentValue <= 4000000)
            {
                newValue = previousValue + currentValue;
                if (newValue % 2 == 0) sum += newValue;
                previousValue = currentValue;
                currentValue = newValue;
            }

            Console.WriteLine("Answer {0}. {1}ms. Traditional.", sum, Timer.ElapsedMilliseconds);

            Timer.Restart();
            sum = Generate.FibonacciNumbers(4000000).Where(x => x % 2 == 0).Sum();
            Console.WriteLine("Answer {0}. {1}ms. LINQ.", sum, Timer.ElapsedMilliseconds);

            Timer.Restart();
            sum = Generate.FibonacciNumbers(4000000).AsParallel().Where(x => x % 2 == 0).Sum();
            Console.WriteLine("Answer {0}. {1}ms. P-LINQ.", sum, Timer.ElapsedMilliseconds);
        }
    }
}
