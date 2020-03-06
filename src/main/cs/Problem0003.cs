using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0003
    {
        public Problem0003()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            ulong i;
            ulong maxNumber = 600_851_475_143;

            for (i = 2; i <= maxNumber; i++) {
                if (maxNumber % i == 0) {
                    maxNumber /= i;
                    i--;
                }
            }
            result = i;


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(3, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}