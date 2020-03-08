using System;
using System.Diagnostics;
using System.Numerics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0052
    {
        public Problem0052()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            for (ulong i = 1;; i++)
            {
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
            }

            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(52, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private bool SameDigits(ulong a, ulong b)
        {
            string aS = a + "";
            string bS = b + "";
            if (aS.Length != bS.Length) return false;
            bool[] used = new bool[bS.Length];
            foreach (char aC in aS)
            {
                for (int i = 0; i < bS.Length; i++)
                {
                    if (!used[i] && aC == bS[i])
                    {
                        used[i] = true;
                        goto endOfLoop;
                    }
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