using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0038
    {
        private int counter;

        public Problem0038()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var n = 40_320; //n = 40320 bc there are 40320 Pandigital numbers that start with 9
            var permutations = new string[n];
            var first = "987654321";

            permute(n, permutations, "", first);

            var permutationsList = new List<string>(permutations);
            //find number:
            for (var i = 9487; i > 0; i--)
                if (permutationsList.Contains(concatenate(i)))
                {
                    result = long.Parse(i + "" + i * 2);
                    break;
                }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(38, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
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

        private string concatenate(int n)
        {
            var result = "";

            for (var i = 1; result.Length < 9; i++) result += n * i;

            return result;
        }
    }
}