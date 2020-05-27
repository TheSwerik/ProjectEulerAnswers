using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0032
    {
        private int counter;

        public Problem0032()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var n = 362880;
            var permutations = new string[n];
            var first = "123456789";

            permute(permutations, "", first);

            var numbers = new HashSet<long>();
            foreach (var s in permutations)
                for (var i = 1; i < s.Length - 2; i++)
                for (var j = i + 1; j < s.Length - 1; j++)
                    if (long.Parse(s.Substring(0, i)) *
                        long.Parse(s.Substring(i, j - i)) ==
                        long.Parse(s.Substring(j)))
                        numbers.Add(long.Parse(s.Substring(j)));

            foreach (var l in numbers) result += l;


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(32, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private void permute(string[] permutations, string prefix, string s)
        {
            if (counter >= 362880) return;

            var n = s.Length;
            if (n == 0) permutations[counter++] = prefix;
            else
                for (var i = 0; i < n; i++)
                    permute(permutations, prefix + s[i], s.Substring(0, i) + s.Substring(i + 1, n - i - 1));
        }
    }
}
