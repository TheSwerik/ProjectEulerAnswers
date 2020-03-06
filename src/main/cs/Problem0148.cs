using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0148
    {
        public Problem0148()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            UInt64 result = 500_000_000_500_000_000;
            System.Console.WriteLine(UInt64.MaxValue);

            // Solution:
            for (UInt64 line = 8; line <= 1_000_000_000; line++)
            {
                UInt64 biggestTriangle = (UInt64) Math.Pow(7, ((UInt64) (Math.Log(line) / Math.Log(7))));
                UInt64 lineLeft = line;
                UInt64 factor = 1;
                for (UInt64 triangle = biggestTriangle; triangle >= 7; triangle /= 7)
                {
                    if (line % triangle == 0) break;
                    UInt64 amount = lineLeft / triangle;
                    result -=  ((triangle - line % triangle) * amount * factor) ;
                    factor *= amount + 1;
                    lineLeft = (lineLeft - (triangle - line % triangle) * amount) / (amount + 1);
                }
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 + " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(148, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}