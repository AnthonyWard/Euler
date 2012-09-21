using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Euler3
{
    class Program
    {
        static void Main(string[] args)
        {
            var highestDivisor = 600851475143.PrimeFactors().Max();
            Console.WriteLine("Solution: {0}", highestDivisor);
        }
    }
}
