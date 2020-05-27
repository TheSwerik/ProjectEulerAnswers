using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0022
    {
        public Problem0022()
        {
            var names = File.ReadAllText(@"resources\problem0022_names.txt").Replace("\"", "").Split(",");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            Array.Sort(names);
            var result = names.Select(t => t.Aggregate<char, long>(0, (current, c) => current + (c - 64)))
                              .Select((score, i) => score * (i + 1)).Sum();


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    22, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}