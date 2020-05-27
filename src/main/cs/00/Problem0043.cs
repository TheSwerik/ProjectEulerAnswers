using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0043
    {
        private int counter;

        public Problem0043()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var n = 3_265_920;
            var permutations = new string[n];
            var first = "9876543210";
            permute(n, permutations, "", first);

            foreach (var number in permutations)
            {
                // check 2
                if ((number[3] - 48) % 2 != 0) continue;

                // check 3
                var crossSum = number[2] + number[3] + number[4] - 3 * 48;
                if (crossSum % 3 != 0) continue;

                // check 5
                int checkDigit = number[5];
                if (checkDigit != '0' && checkDigit != '5') continue;

                // check 7
                var checkNumber = int.Parse(number.Substring(4, 3));
                if (checkNumber % 7 != 0) continue;

                // check 11
                checkNumber = int.Parse(number.Substring(5, 3));
                if (checkNumber % 11 != 0) continue;

                // check 13
                checkNumber = int.Parse(number.Substring(6, 3));
                if (checkNumber % 13 != 0) continue;

                // check 17
                checkNumber = int.Parse(number.Substring(7, 3));
                if (checkNumber % 17 != 0) continue;

                result += long.Parse(number);
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    43, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
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