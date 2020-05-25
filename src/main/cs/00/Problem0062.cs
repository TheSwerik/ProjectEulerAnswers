using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0062
    {
        private int counter;

        public Problem0062()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (var i = 346;; i++)
            {
                counter = 0;
                var bignumber = i * i * i + "";
                var permutes = new string[fac(bignumber.Length)];
                permute(permutes, "", bignumber);
                var count = 1;
                foreach (var p in permutes)
                {
                    if (Math.Abs(Math.Cbrt(int.Parse(p)) % 1) < 0.000001) count++;
                    if (count == 5)
                    {
                        result = i * i * i;
                        goto end;
                    }
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
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(62, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private void permute(string[] permutations, string prefix, string s)
        {
            if (counter >= 362880) return;

            var n = s.Length;
            if
                (n == 0) permutations[counter++] = prefix;
            else
                for (var i = 0; i < n; i++)
                    permute(permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }

        private int fac(int n)
        {
            var product = n;
            for (var i = 2; i < n; i++) product *= i;

            return product;
        }
    }
}