using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0038
    {
        private int counter;

        public Problem0038()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            int n = 40_320; //n = 40320 bc there are 40320 Pandigital numbers that start with 9
            string[] permutations = new string[n];
            string first = "987654321";

            permute(n, permutations, "", first);

            List<string> permutationsList = new List<string>(permutations);
            //find number:
            for (int i = 9487; i > 0; i--)
                if (permutationsList.Contains(concatenate(i)))
                {
                    result = long.Parse(i + "" + i * 2);
                    break;
                }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(38, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
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

        private string concatenate(int n)
        {
            string result = "";

            for (int i = 1; result.Length < 9; i++) result += n * i;

            return result;
        }
    }
}