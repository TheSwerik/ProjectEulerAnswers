using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._01
{
    public class Problem0148
    {
        public Problem0148()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 500_000_000_500_000_000;
            Console.WriteLine(ulong.MaxValue);

            // Solution:
            for (ulong line = 8; line <= 1_000_000_000; line++)
            {
                var biggestTriangle = (ulong) Math.Pow(7, (ulong) (Math.Log(line) / Math.Log(7)));
                var lineLeft = line;
                ulong factor = 1;
                for (var triangle = biggestTriangle; triangle >= 7; triangle /= 7)
                {
                    if (line % triangle == 0) break;
                    var amount = lineLeft / triangle;
                    result -= (triangle - line % triangle) * amount * factor;
                    factor *= amount + 1;
                    lineLeft = (lineLeft - (triangle - line % triangle) * amount) / (amount + 1);
                }
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
                    148, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}