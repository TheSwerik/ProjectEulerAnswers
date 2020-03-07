using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0044
    {
        public Problem0044()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            long[] arr = fillarr(2500);
            for (int i = 1;; i++)
            {
                long l1 = arr[i];
                for (int j = 1; j <= i; j++)
                {
                    long l2 = arr[j];
                    if (isPartOfFormular(arr, l1 + l2) && isPartOfFormular(arr, l1 - l2))
                    {
                        result = l1 - l2 > 0 ? l1 - l2 : l2 - l1;
                        goto end;
                    }
                }
            }

            end:
            {
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
                Benchmark.AddTime(44, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private long[] fillarr(int n)
        {
            long[] arr = new long[n];

            for (int i = 1; i <= n; i++)
            {
                arr[i - 1] = i * (3 * i - 1) / 2L;
            }

            return arr;
        }

        private bool isPartOfFormular(long[] pentagonal, long value)
        {
            return Array.BinarySearch(pentagonal, value) >= 0;
        }
    }
}