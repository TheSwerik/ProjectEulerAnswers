using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class _00.Problem0035
    {
        private readonly List<int> primes;

        public _00.Problem0035()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            primes = genPrimes(1000000);
            var circularPrimes = new HashSet<int>();
            foreach (var prime in primes)
            {
                if (circularPrimes.Contains(prime)) continue;
                var primeSwapped = swapped(prime);

                if (primeSwapped != null)
                    foreach (var i in primeSwapped)
                        circularPrimes.Add(i);
            }

            result = circularPrimes.Count;


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(35, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private int[] swapped(int n)
        {
            var asString = n + "";

            //Optimized:
            if (n > 10 && (asString.Contains("0") || asString.Contains("2") || asString.Contains("4") ||
                           asString.Contains("5") || asString.Contains("6") || asString.Contains("8")))
                return null;

            var permutations = new string[asString.Length];
            var primeSwapped = new HashSet<int>();
            permutations[0] = asString;
            primeSwapped.Add(int.Parse(asString));

            for (var i = 1; i < permutations.Length; i++)
            {
                permutations[i] = permutations[i - 1].Substring(1) + permutations[i - 1][0];
                if (!primes.Contains(int.Parse(permutations[i]))) return null;

                primeSwapped.Add(int.Parse(permutations[i]));
            }

            return primeSwapped.ToArray();
        }

        private List<int> genPrimes(int range)
        {
            var primes = new List<int> {2};
            for (var i = 3; i < range; i += 2)
            {
                var sqrt = (int) Math.Sqrt(i);
                for (var j = 0; j < primes.Count && primes[j] <= sqrt; j++)
                    if (i % primes[j] == 0)
                        goto skip;

                primes.Add(i);
                skip:
                {
                }
            }

            return primes;
        }
    }
}