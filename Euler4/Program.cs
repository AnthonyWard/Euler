using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers;

namespace Euler4
{
    class Program
    {
        static void Main(string[] args)
        {
            int product = 0;

            Timer.Go();

            for (int x = 1; x < 1000; x++)
                for (int y = 1; y < 1000; y++)
                    if ((x * y).IsPalindrome() && x * y > product)
                        product = x * y;

            Console.WriteLine("The answer is {0}. {1}ms. Traditional.", product, Timer.ElapsedMilliseconds);
            Timer.Restart();

            product = Enumerable.Range(1, 999).SelectMany(
                x => Enumerable.Range(1, 999).Where(y => (x * y).IsPalindrome()),
                (x, y) => x * y
            ).Max();

            Console.WriteLine("The answer is {0}. {1}ms. LINQ.", product, Timer.ElapsedMilliseconds);
            Timer.Restart();

            product = (from x in Enumerable.Range(1, 999).AsParallel()
                       from y in Enumerable.Range(1, 999)
                       where (x * y).IsPalindrome()
                       select x * y).Max();

            Console.WriteLine("The answer is {0}. {1}ms. P-LINQ.", product, Timer.ElapsedMilliseconds);
        }
    }
}
