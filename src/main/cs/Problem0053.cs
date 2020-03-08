using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0053
    {
        public Problem0053()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            System.Console.WriteLine(fac(25, 25 - 17) / fac(17));
            System.Console.WriteLine(fac(25, 25 - 17));
            System.Console.WriteLine(fac(17));
            for (ulong n = 10; n <= 100; n++)
            {
                ulong max = (ulong) Math.Ceiling((double) n / 2);
                if (max != n / 2 && fac(n, n - max) / fac(max) > 1_000_000) result++;
                for (ulong r = 2; r < max; r++)
                {
                    if (fac(n, n - r) / fac(r) > 1_000_000) result += 2;
                }
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
                Benchmark.AddTime(53, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private BigInteger fac(ulong n, ulong min = 1)
        {
            BigInteger result = n;
            for (ulong i = min + 1; i < n; i++)
            {
                result *= i;
            }

            return result;
        }
    }
}