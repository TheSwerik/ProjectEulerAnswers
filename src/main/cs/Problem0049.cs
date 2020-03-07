using System;
using System.Collections;
using System.Diagnostics;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0049
    {
        private int[] _primes;

        public Problem0049()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            var result = "";

            // Solution:
            GenPrimes();
            foreach (var j in _primes)
                for (var i = 45;; i++)
                {
                    if (i == 3330 && j == 1487) continue;
                    var b = j + i;
                    var c = b + i;
                    if (c > 9999) break;
                    if (ArePermutes(j, b, c) && ArePrimes(j, b, c))
                    {
                        result = "" + j + b + c;
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
                Benchmark.AddTime(49, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private bool ArePrimes(int a, int b, int c)
        {
            return _primes.Contains(a) && _primes.Contains(b) && _primes.Contains(c);
        }

        private bool ArePermutes(int a, int b, int c)
        {
            var aS = a + "";
            var bS = (b + "").ToCharArray();
            var cS = (c + "").ToCharArray();
            var digits = aS.ToCharArray();

            var bIndices = new bool[4];
            var cIndices = new bool[4];
            for (var i = 0; i < 4; i++)
            {
                for (var j = 0; j < 4; j++)
                {
                    if (bIndices[j]) continue;
                    if (digits[i] == bS[j])
                    {
                        bIndices[j] = true;
                        break;
                    }
                }

                for (var j = 0; j < 4; j++)
                {
                    if (cIndices[j]) continue;
                    if (digits[i] == cS[j])
                    {
                        cIndices[j] = true;
                        break;
                    }
                }
            }

            return !(bIndices.Contains(false) || cIndices.Contains(false));
        }

        private void GenPrimes()
        {
            var allPrimes = PrimeSieveButFast(10_000);
            _primes = new int[0];
            var i = 0;
            for (; i < allPrimes.Length; i++)
                if (allPrimes[i] >= 1000)
                {
                    _primes = new int[allPrimes.Length - i];
                    break;
                }

            for (var j = 0; j < _primes.Length; j++, i++) _primes[j] = (int) allPrimes[i];
        }

        private ulong[] PrimeSieveButFast(ulong range)
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