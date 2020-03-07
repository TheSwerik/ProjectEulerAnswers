using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0024
    {
        private int _counter;

        public Problem0024()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            int n = 1000000;
            string[] permutations = new string[n];
            string first = "0123456789";

            Permute(permutations, "", first);


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + permutations[n - 1] + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(24, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private void Permute(string[] permutations, string prefix, string s)
        {
            if (_counter >= 1000000) return;

            int n = s.Length;
            if (n == 0) permutations[_counter++] = prefix;
            else
                for (int i = 0; i < n; i++)
                    Permute(permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }
    }
}