using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._07
{
    public class _07.Problem0704
    {
        public _07.Problem0704()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            ulong max = 10000000;
            var lastPercent = 0;
            for (ulong n = 1; n <= max; n++)
            {
                var percent = (double) n / max * 100;
                if (percent * 100 > lastPercent)
                {
                    Console.Write("\r" + percent.ToString("0.##") + "%");
                    lastPercent = (int) (percent * 100);
                }

                result += f(n);
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(704, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private ulong f(ulong n)
        {
            ulong result = 0;
            for (ulong m = 0; m <= n; m++)
            {
                var g = this.g(n, m);
                if (g > result) result = g;
            }

            return result;
        }

        private ulong g(ulong n, ulong m)
        {
            // n over m
            n = fac(n, n - m) / fac(m);

            // find biggest potenz of 2
            ulong max = 0;
            ulong j = 1;
            for (ulong i = 0; j < n; i++, j = j * 2)
            {
                if (n % j != 0) return max;

                max = i;
            }

            return max;
        }

        private ulong fac(ulong n)
        {
            if (n == 0) return 1;
            for (var i = n - 1; i > 1; i--) n = n * i;

            return n > 0 ? n : 1;
        }

        private ulong fac(ulong n, ulong m)
        {
            if (n == 0) return 1;
            for (var i = n - 1; i > m; i--) n = n * i;

            return n > 0 ? n : 1;
        }
    }
}