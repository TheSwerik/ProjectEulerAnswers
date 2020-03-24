using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0041
    {
        private int counter;

        public Problem0041()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            result = solvePanToPrime();

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(41, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private long solvePanToPrime()
        {
            var max = 5040;
            var permutes = new string[max];
            var maxS = "7654321";
            while (true)
            {
                this.permute(max, permutes, "", maxS);
                foreach (var permute in permutes)
                    if (isPrime(long.Parse(permute)))
                        return long.Parse(permute);

                maxS = maxS.Substring(1);
            }
        }

        private bool isPrime(long n)
        {
            if (n % 2 == 0) return false;

            var root = Math.Sqrt(n);
            for (var i = 3; i < root; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }

        private void permute(int max, string[] permutations, string prefix, string s)
        {
            if (counter >= max) return;

            var n = s.Length;
            if (n == 0)
                permutations[counter++] = prefix;
            else
                for (var i = 0; i < n; i++)
                    permute(max, permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }
    }
}