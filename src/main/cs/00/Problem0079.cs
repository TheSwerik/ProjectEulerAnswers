using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0079
    {
        public Problem0079()
        {
            var lines = File.ReadAllLines(@"resources\p079_keylog.txt");
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            var passcode = "";
            var before = new bool[10, 10];
            foreach (var line in lines)
                before[line[2] - 48, line[1] - 48] =
                    before[line[2] - 48, line[0] - 48] = before[line[1] - 48, line[0] - 48] = true;

            var beforeI = new int[10];

            for (var i = 0; i < 10; i++)
            for (var j = 0; j < 10; j++)
                if (before[i, j])
                    beforeI[i]++;

            for (var i = 0; i < 10; i++)
            for (var j = 0; j < 10; j++)
            {
                if (j == 5 || j == 4) continue;
                if (beforeI[j] == i)
                {
                    passcode += j;
                    break;
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + passcode + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(79, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}