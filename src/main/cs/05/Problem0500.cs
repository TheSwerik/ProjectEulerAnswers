using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._05
{
    public class Problem0500
    {
        public Problem0500()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 1;

            // Solution:
            var primes = Primes(7376508);

            for (var i = 1; i <= 500500; i++)
            {
                result = result * primes[0] % 500500507;
                primes[0] *= primes[0];
                var index = primes.BinarySearch(1, primes.Count - 1, primes[0], null);
                if (index < 0)
                {
                    index = ~index;
                    if (index == primes.Count) index--;
                }

                primes.Insert(index, primes[0]);
                primes.Remove(primes[0]);
                if (i % 5005 == 0) Console.Write("\r" + (double) i * 100 / 500500 + "%");
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    500, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private static List<ulong> Primes(int upper)
        {
            var primeSieve = new bool[upper];
            var primeList = new List<ulong> {2};

            var sqrt = (int) Math.Sqrt(primeSieve.Length);
            for (var i = 3; i < sqrt; i += 2)
                if (!primeSieve[i])
                {
                    primeList.Add((ulong) i);

                    for (var j = i * i; j < primeSieve.Length; j += i * 2) primeSieve[j] = true;
                }

            for (var i = ((sqrt + 1) & 1) == 0 ? sqrt + 2 : sqrt + 1; i < upper && primeList.Count < 500500; i += 2)
                if (!primeSieve[i])
                    primeList.Add((ulong) i);

            return primeList;
        }
    }
}