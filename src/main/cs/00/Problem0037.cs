using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0037
    {
        public Problem0037()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
//        result = solveSlow();
//        result = solveSlowButOptimized();

            //gen all primes < 1000000:
            var primes = new List<int>(PrimeSieveButFast(1_000_000));

            var firstPrimes = new List<string> {"2", "3", "5", "7"};
            for (var i = 0; i < 11;)
            {
                var newPrimes = new List<string>();

                foreach (var prime in firstPrimes)
                    for (var j = 0; j < 10; j++)
                    {
                        //generate primes:
                        var s = j + "" + prime;
                        if (primes.Contains(int.Parse(s))) newPrimes.Add(s);

                        //check if valid:
                        for (var k = 1; k < s.Length; k++)
                            if (!primes.Contains(int.Parse(s.Substring(k))) ||
                                !primes.Contains(int.Parse(s.Substring(0, s.Length - k))))
                                goto end;

                        //when valid:
                        i++;
                        result += int.Parse(s);

                        end:
                        {
                        }
                    }

                firstPrimes = newPrimes;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(37, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long solveSlowButOptimized()
        {
            long result = 0;

            var count = 0;
            var primes = new List<int>(PrimeSieveButFast(1_000_000));
            foreach (var i in primes)
            {
                var teststring = i + "";

                //skip if <10 or Contains 5 (except leading)
                if (i < 10 ||
                    teststring.Substring(1).Contains("5"))
                    continue;

                //check if valid
                for (var j = 1; j < teststring.Length; j++)
                    if (!primes.Contains(int.Parse(teststring.Substring(j))) ||
                        !primes.Contains(int.Parse(teststring.Substring(0, teststring.Length - j))))
                        goto end;

                //when valid
                result += i;
                if (++count == 11) break;

                end:
                {
                }
            }

            return result;
        }

        private long solveSlow()
        {
            long result = 0;
            for (var k = 2;; k++)
            {
                var count = 0;
                result = 0;
                var primes = new List<int>(PrimeSieveButFast((int) Math.Pow(10.0, k)));
                foreach (var i in primes)
                {
                    if (i < 10) continue;

                    var teststring = i + "";
                    for (var j = 1; j < teststring.Length; j++)
                        if (!primes.Contains(int.Parse(teststring.Substring(j))) ||
                            !primes.Contains(int.Parse(teststring.Substring(0, teststring.Length - j))))
                            goto middle;

                    result += i;
                    if (++count == 11) goto end;

                    middle:
                    {
                    }
                }
            }

            end:
            {
            }
            return result;
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

            var primes = new List<int> {2};
            for (var i = 3; i < range; i += 2)
                if (bools[i])
                    primes.Add(i);

            return primes.ToArray();
        }
    }
}