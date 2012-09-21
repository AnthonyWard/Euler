using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Euler
{
    class Program
    {
        static long highestStartingNumber = 0;

        static void Main(string[] args)
        {
            Console.WriteLine("*******************");
            Console.WriteLine("Single Threaded Mode");
            Console.WriteLine("*******************");

            EulerStopwatch.Start();
            CalculateLongestNumberChain();
            EulerStopwatch.Stop();

            Console.WriteLine("Highest Starting Number: " + highestStartingNumber);
            Console.WriteLine("Program Completed in " + EulerStopwatch.ElapsedMilliseconds + "ms");
            Console.WriteLine();

            Console.WriteLine("*******************");
            Console.WriteLine("Now lets use PLINQ");
            Console.WriteLine("*******************");

            EulerStopwatch.Start();
            CalculateLongestNumberChain_MultiCore();
            EulerStopwatch.Stop();

            Console.WriteLine("Highest Starting Number: " + highestStartingNumber);
            Console.WriteLine("Program Completed in " + EulerStopwatch.ElapsedMilliseconds + "ms");
            Console.ReadKey();
        }

        private static void CalculateLongestNumberChain()
        {
            long termsCount = 0;
            long highestCount = 0;

            for (long number = 1; number < 1000000; number++)
            {
                termsCount = CalculateTermsCountFor(number);

                if (termsCount > highestCount)
                {
                    highestCount = termsCount;
                    highestStartingNumber = number;
                }
            }
        }

        private static void CalculateLongestNumberChain_MultiCore()
        {
            highestStartingNumber =
                Enumerable.Range(1, 9999999)
                .AsParallel()
                .Select(number => new { number, Terms = CalculateTermsCountFor(number) })
                .OrderByDescending(n => n.Terms)
                .First()
                .number;
        }

        private static long CalculateTermsCountFor(long number)
        {
            long termsCount = 0;

            while (number > 1)
            {
                termsCount++;

                if (number.IsEven())
                    number = Helpers.ApplyEvenRule(number);
                else
                    number = Helpers.ApplyOddRule(number);
            }

            return termsCount;
        }
    }
}
