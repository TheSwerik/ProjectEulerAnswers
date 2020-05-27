using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0052
    {
        public Problem0052()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            for (ulong i = 1;; i++)
                if (
                    SameDigits(i, 6 * i) &&
                    SameDigits(i, 5 * i) &&
                    SameDigits(i, 4 * i) &&
                    SameDigits(i, 3 * i) &&
                    SameDigits(i, 2 * i)
                )
                {
                    result = i;
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
                Benchmark.AddTime(52, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private bool SameDigits(ulong a, ulong b)
        {
            var aS = a + "";
            var bS = b + "";
            if (aS.Length != bS.Length) return false;
            var used = new bool[bS.Length];
            foreach (var aC in aS)
            {
                for (var i = 0; i < bS.Length; i++)
                    if (!used[i] && aC == bS[i])
                    {
                        used[i] = true;
                        goto endOfLoop;
                    }

                return false;
                endOfLoop:
                {
                }
            }

            return true;
        }
    }
}
