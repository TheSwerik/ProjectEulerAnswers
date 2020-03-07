using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0032
    {
        private int counter;

        public Problem0032()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            int n = 362880;
            string[] permutations = new string[n];
            string first = "123456789";

            permute(permutations, "", first);

            HashSet<long> numbers = new HashSet<long>();
            foreach (string s in permutations)
                for (int i = 1; i < s.Length - 2; i++)
                for (int j = i + 1; j < s.Length - 1; j++)
                    if (long.Parse(s.Substring(0, i)) *
                        long.Parse(s.Substring(i, j - i)) ==
                        long.Parse(s.Substring(j)))
                        numbers.Add(long.Parse(s.Substring(j)));

            foreach (long l in numbers) result += l;


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(32, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private void permute(string[] permutations, string prefix, string s)
        {
            if (counter >= 362880) return;

            int n = s.Length;
            if (n == 0) permutations[counter++] = prefix;
            else
                for (int i = 0; i < n; i++)
                    permute(permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }
    }
}