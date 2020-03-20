using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using DocumentFormat.OpenXml.Wordprocessing;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0060
    {
        public Problem0060()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            List<int> primes = Primes(10000);
            Dictionary<long, List<long>> pairs = new Dictionary<long, List<long>>();
            for (var a = 0; a < primes.Count() - 1; a++)
            {
                for (var b = a + 1; b < primes.Count(); b++)
                {
                    if (IsPrime(Convert.ToInt64(primes[a] + "" + primes[b])) && IsPrime(Convert.ToInt64(primes[b] + "" + primes[a])))
                    {
                        if (pairs.ContainsKey(primes[a]))
                        {
                            var list = pairs[primes[a]];
                            list.Add(primes[b]);
                            pairs[primes[a]] = list;
                        }
                        else
                        {
                            pairs[primes[a]] = new List<long> {primes[b]};
                        }
                    }
                }
            }
            System.Console.WriteLine("generated pairs!");

            end:
            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            System.Console.WriteLine(elapsedTime);
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(60, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private static List<int> Primes(int upper)
        {
            var pS = new bool[upper];
            var pL = new List<int>();

            var sqrt = (int) Math.Sqrt(pS.Length);
            for (var i = 3;
                i < sqrt;
                i += 2)
                if (!pS[i])
                {
                    pL.Add(i);

                    for (var j = i * i; j < pS.Length; j += i * 2) pS[j] = true;
                }

            for (var i = ((sqrt + 1) & 1) == 0 ? sqrt + 2 : sqrt + 1;
                i < pS.Length;
                i += 2)
                if (!pS[i])
                    pL.Add(i);
            return pL;
        }

        private static bool IsPrime(long n)
        {
            var nsqrt = Math.Sqrt(n);
            for (var i = 3;
                i < nsqrt;
                i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }
    }
}