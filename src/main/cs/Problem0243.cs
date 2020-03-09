using System;
using System.Diagnostics;
using System.Numerics;
using DocumentFormat.OpenXml.Math;
using DocumentFormat.OpenXml.Wordprocessing;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0243
    {
        public Problem0243()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 0;

            // Solution:
            int[] primes = new[] {2, 3, 5, 7, 11, 13, 17, 19, 23, 29};
            BigInteger totient = 1;
            BigInteger denominator = 1;
            for (int i = 0;;)
            {
                totient *= (primes[i] - 1);
                denominator *= primes[i++];
                if (totient * 100_000_000_000 / denominator < 16358819555)
                {
                    for (int j = 1; j < primes[i]; j++)
                    {
                        BigInteger numerator = j * totient;
                        BigInteger realDenominator = j * denominator;
                        if (numerator * 100_000_000_000 / (realDenominator - 1) < 16358819555)
                        {
                            result = realDenominator;
                            goto end;
                        }
                    }
                }
            }

            end:
            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(243, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }

            // string i = "892 371 480";
            // string j = "696 729 600";
        }

        private bool hasSameFactors(int small, decimal high)
        {
            if (small % 2 == 0 && high % 2 == 0) return true;
            for (int i = 3; i < small; i += 2)
            {
                if (small % i == 0 && high % i == 0) return true;
            }

            return false;
        }
    }
}