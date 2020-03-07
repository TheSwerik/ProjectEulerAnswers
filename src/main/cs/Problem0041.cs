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
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            result = solvePanToPrime();

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
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
            int max = 5040;
            string[] permutes = new string[max];
            string maxS = "7654321";
            while (true)
            {
                this.permute(max, permutes, "", maxS);
                foreach (string permute in permutes)
                    if (isPrime(long.Parse(permute)))
                        return long.Parse(permute);

                maxS = maxS.Substring(1);
            }
        }

        private bool isPrime(long n)
        {
            if (n % 2 == 0) return false;

            double root = Math.Sqrt(n);
            for (int i = 3; i < root; i += 2)
                if (n % i == 0)
                    return false;

            return true;
        }

        private void permute(int max, string[] permutations, string prefix, string s)
        {
            if (counter >= max) return;

            int n = s.Length;
            if (n == 0)
                permutations[counter++] = prefix;
            else
                for (int i = 0; i < n; i++)
                    permute(max, permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }
    }
}