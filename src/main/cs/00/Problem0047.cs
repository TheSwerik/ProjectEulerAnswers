using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0047
    {
        private readonly ulong[] primes;

        public Problem0047()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            primes = primeSieveButFast(150_000);
            for (ulong i = 20;; i++)
            {
                if (primes.Contains(i)) continue;
                if (numberOfPrimFactors(new[] {i, i + 1, i + 2, i + 3}))
                {
                    result = i;
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
                Benchmark.AddTime(47, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private bool numberOfPrimFactors(ulong[] numbers)
        {
            for (var j = 0; j < numbers.Length; j++)
            {
                var count = 0;
                var n = numbers[j];
                for (ulong i = 0; primes[i] <= n; i++)
                {
                    if (n % primes[i] == 0) count++;

                    while (n % primes[i] == 0) n /= primes[i];
                }

                if (count != 4) return false;
            }

            return true;
        }

        private ulong[] primeSieveButFast(ulong range)
        {
            var bools = new bool[range + 1];
            Array.Fill(bools, true);
            var root = Math.Sqrt(range) + 0.5;
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