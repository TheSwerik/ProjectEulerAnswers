using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0500
    {
        public Problem0500()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 1;

            // Solution:
            List<long> primes = Primes(7376508);

            for (int i = 1; i < 500500; i++)
            {
                primes[0] *= primes[0];
                var index = primes.BinarySearch(primes[0]);
                if (index < 0)
                {
                    index = ~index;
                    if (index == primes.Count) index--;
                }

                long help = primes[index];
                primes[index] = primes[0];
                primes[0] = help;
            }

            foreach (long p in primes)
            {
                result = (result * p) % 500500507;
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(500, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private static List<long> Primes(int upper)
        {
            var primeSieve = new bool[upper];
            var primeList = new List<long> {2};

            var sqrt = (int) Math.Sqrt(primeSieve.Length);
            for (var i = 3; i < sqrt; i += 2)
                if (!primeSieve[i])
                {
                    primeList.Add(i);

                    for (var j = i * i; j < primeSieve.Length; j += i * 2) primeSieve[j] = true;
                }

            for (long i = ((sqrt + 1) & 1) == 0 ? sqrt + 2 : sqrt + 1; i < upper && primeList.Count < 500500; i += 2)
                if (!primeSieve[i])
                    primeList.Add(i);

            return primeList;
        }
    }
}