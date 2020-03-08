using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0058
    {
        public Problem0058()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            BigInteger result = 0;

            // Solution:
            BigInteger all = 4;
            BigInteger primes = 3;

            BigInteger bottomRight = 9;
            BigInteger bottomLeft = 7;
            BigInteger topLeft = 5;
            BigInteger topRight = 3;
            for (BigInteger i = 2;; i++)
            {
                bottomRight += i * 8;
                bottomLeft = bottomRight - i * 2;
                topLeft = bottomLeft - i * 2;
                topRight = topLeft - i * 2;
                all += 4;

                if (IsPrime(bottomRight)) primes++;
                if (IsPrime(bottomLeft)) primes++;
                if (IsPrime(topLeft)) primes++;
                if (IsPrime(topRight)) primes++;
                // System.Console.WriteLine(primes * 100 / all);
                if (primes * 100 / all < 10)
                {
                    result = i * 2 + 1;
                    break;
                }

                System.Console.Write("\r" + i + "\t" + bottomRight);
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(58, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private bool IsPrime(BigInteger n)
        {
            if (n % 2 == 0) return false;
            // BigInteger root = Math.Sqrt(n);
            BigInteger max = n / 2;
            for (int i = 3; i < max; i += 2)
            {
                if (n % i == 0) return false;
            }

            return true;
        }
    }
}