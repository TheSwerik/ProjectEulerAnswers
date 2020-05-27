using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0060
    {
        public Problem0060()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = new List<long>();

            // Solution:
            var primes = Primes(10000);
            var pairs = new Dictionary<long, List<long>>();
            for (var a = 0; a < primes.Count() - 1; a++)
            for (var b = 0; b < primes.Count(); b++)
                if (IsPrime(Convert.ToInt64(primes[a] + "" + primes[b])) &&
                    IsPrime(Convert.ToInt64(primes[b] + "" + primes[a])))
                {
                    if (pairs.ContainsKey(primes[a])) pairs[primes[a]].Add(primes[b]);
                    else pairs[primes[a]] = new List<long> {primes[b]};
                }

            Console.WriteLine("generated pairs!");
            for (var i = 0; i < primes.Count; i++)
            {
                if (pairs.ContainsKey(primes[i]) && pairs[primes[i]].Count >= 4)
                {
                    var sum = primes[i];
                    for (var j = 0; j < pairs[primes[i]].Count; j++)
                    {
                        if (!pairs.ContainsKey(primes[j])) continue;
                        sum += primes[j];
                        for (var k = 0; k < pairs[primes[i]].Count; k++)
                        {
                            if (j == k) continue;
                            if (pairs.ContainsKey(pairs[primes[i]][j]) && pairs[primes[i]].Contains(k) &&
                                pairs[pairs[primes[i]][j]].Contains(k)) sum += primes[k];
                        }
                    }

                    result.Add(sum);
                }

                {
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine(elapsedTime);
            foreach (var a in result) Console.WriteLine(a);
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    60, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
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