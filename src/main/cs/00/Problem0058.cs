using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0058
    {
        private readonly ulong[] primeArr;

        public Problem0058()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            decimal result = 0;

            // Solution:
            primeArr = PrimeSieveButFast(100_000);
            decimal all = 5;
            decimal primes = 3;

            decimal bottomLeft = 7;
            decimal topLeft = 5;
            decimal topRight = 3;
            for (decimal i = 2;; i++)
            {
                bottomLeft += i * 8 - 2;
                topLeft = bottomLeft - i * 2;
                topRight = topLeft - i * 2;
                all += 4;

                if (IsPrime(bottomLeft)) primes++;
                if (IsPrime(topLeft)) primes++;
                if (IsPrime(topRight)) primes++;
                if (10 * primes < all)
                {
                    result = i * 2 + 1;
                    break;
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(58, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private bool IsPrime(decimal n)
        {
            // ulong root = Math.Sqrt(n);
            var max = Math.Sqrt((double) n);
            for (var i = 0; primeArr[i] <= max; i++)
                if (n % primeArr[i] == 0)
                    return false;

            return true;
        }

        private ulong[] PrimeSieveButFast(ulong range)
        {
            var bools = new bool[range + 1];
            Array.Fill(bools, true);
            var root = (ulong) (Math.Sqrt(range) + 0.5);
            for (ulong i = 3; i < root; i += 2)
                if (bools[i])
                    for (var j = i * i; j < range; j += i * 2)
                        bools[j] = false;

            var primes = new ArrayList();
            primes.Add((ulong) 2);
            for (ulong i = 3; i < range; i += 2)
                if (bools[i])
                    primes.Add(i);

            return primes.OfType<ulong>().ToArray();
        }
    }
}