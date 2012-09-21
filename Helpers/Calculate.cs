using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public static class Calculate
    {
        public static int Divisors(this int number)
        {
            int divisors = 0;
            int sqrt = (int)Math.Sqrt(number);

            for (int i = 1; i <= sqrt; i++)
                if (number % i == 0)
                    divisors += 2;

            //Correction if the number is a perfect square
            if (sqrt * sqrt == number)
                divisors--;

            return divisors;
        }

        public static IEnumerable<long> PrimeFactors(this long number)
        {
            long divisor = 2;
            var primeFactors = new List<long>();

            while (number != 1)
            {
                while (number % divisor == 0)
                {
                    primeFactors.Add(divisor);
                    number /= divisor;
                }
                divisor++;
            }

            return primeFactors;
        }

        public static bool IsPalindrome(this long number)
        {
            if (number < 10) return true;
            var array = new List<long>();

            while (number != 0)
            {
                array.Add(number % 10);
                number /= 10;
            }

            int lastArrayIndex = array.Count() - 1;

            for (int i = 0; i <= lastArrayIndex; i++)
            {
                if (array[i] != array[lastArrayIndex - i])
                    return false;
            }

            return true;
        }

        public static bool CanBeDividedBy(this int number, int from, int to)
        {
            for (int i = from; i <= to; i++)
            {
                if (number % i != 0)
                    return false;
            }
            return true;
        }

        public static bool Divides(this int x, int y)
        {
            return x % y == 0;
        }
    }
}
