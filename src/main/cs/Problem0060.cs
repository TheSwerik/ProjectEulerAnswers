using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0060
    {
        public Problem0060()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 3 + 7 + 109 + 673;

            // Solution:
            long[] primes = PrimeSieveButFast(10_000_000);
            int[] firstPrimes = new[] {3, 7, 109, 673};
            foreach (long prime in primes)
            {
                long[] newPrimes = new[]
                {
                    long.Parse("" + firstPrimes[0] + prime),
                    long.Parse("" + prime + firstPrimes[0]),
                    long.Parse("" + firstPrimes[1] + prime),
                    long.Parse("" + 3 + prime + firstPrimes[1]),
                    long.Parse("" + firstPrimes[2] + prime),
                    long.Parse("" + 3 + prime + firstPrimes[2]),
                    long.Parse("" + firstPrimes[3] + prime),
                    long.Parse("" + 3 + prime + firstPrimes[3]),
                };
                if (
                    primes.Contains(newPrimes[0]) &&
                    primes.Contains(newPrimes[1]) &&
                    primes.Contains(newPrimes[2]) &&
                    primes.Contains(newPrimes[3]) &&
                    primes.Contains(newPrimes[4]) &&
                    primes.Contains(newPrimes[5]) &&
                    primes.Contains(newPrimes[6]) &&
                    primes.Contains(newPrimes[7])
                )
                {
                    result += prime;
                    goto end;
                }
            }

            end:
            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(60, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long[] PrimeSieveButFast(int range)
        {
            var bools = new bool[range + 1];
            Array.Fill(bools, true);
            var root = Math.Sqrt(range) + 0.5;
            for (var i = 3; i < root; i += 2)
                if (bools[i])
                    for (var j = i * i; j < range; j += i * 2)
                        bools[j] = false;

            var primes = new ArrayList();
            primes.Add(2);
            for (long i = 3; i < range; i += 2)
                if (bools[i])
                    primes.Add(i);

            return primes.OfType<long>().ToArray();
        }
    }
}