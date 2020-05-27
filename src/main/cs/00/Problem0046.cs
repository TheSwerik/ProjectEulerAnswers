using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0046
    {
        private readonly int[] primes;

        public Problem0046()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result;

            // Solution:
            primes = PrimeSieveButFast(10_000);
            // System.Console.WriteLine(primes.Length + " Primes generated.");

            for (ulong i = 9;; i += 2)
                // if (isComposite(i))
                // {
                //     if (IsGoldbach(i))
                //     {
                //         System.Console.WriteLine(i);
                //     }
                //     else
                //     {
                //         result = i;
                //         break;
                //     }
                //
                //     if (!IsGoldbach(i))
                //     {
                //     }
                // }

                if (isComposite(i) && !IsGoldbach(i))
                {
                    result = i;
                    break;
                }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));

            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(46, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private bool IsGoldbach(ulong n)
        {
            for (var i = 0; i < primes.Length; i++)
            {
                var p = primes[i];
                if (p > (int) n - 2) break;

                for (var j = 1;; j++)
                {
                    var func = (ulong) (p + 2 * j * j);
                    if (n == func)
                        return true;
                    if (n < func) break;
                }
            }

            return false;
        }

        private bool isComposite(ulong n)
        {
            var max = (ulong) Math.Sqrt(n);
            for (ulong divisor = 2; divisor <= max; divisor++)
                if (n % divisor == 0)
                    return true;

            return false;
        }

        private int[] PrimeSieveButFast(int range)
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
            for (var i = 3; i < range; i += 2)
                if (bools[i])
                    primes.Add(i);

            return primes.OfType<int>().ToArray();
        }
    }
}
