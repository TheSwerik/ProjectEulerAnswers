using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0010
    {
        public Problem0010()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            // for (long i = 11; i < 2000000; i += 2)
            // {
            //     for (long j = 3; j <= (int) Math.Sqrt(i); j += 2)
            //     {
            //         if (i % j == 0)
            //         {
            //             goto end;
            //         }
            //     }
            //
            //     result += i;
            //     end:
            //     {
            //     }
            // }

            //better (Maurice):
            var bools = new bool[2000000];

            for (var i = 2; i < bools.Length; i++)
                if (!bools[i])
                {
                    result += i;
                    for (var j = i; j < bools.Length; j += i) bools[j] = true;
                }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(10, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}