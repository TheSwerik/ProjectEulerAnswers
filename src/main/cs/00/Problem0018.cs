using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0018
    {
        private const string Pyramid =
            "75\n" +
            "95 64\n" +
            "17 47 82\n" +
            "18 35 87 10\n" +
            "20 04 82 47 65\n" +
            "19 01 23 75 03 34\n" +
            "88 02 77 73 07 63 67\n" +
            "99 65 04 28 06 16 70 92\n" +
            "41 41 26 56 83 40 80 70 33\n" +
            "41 48 72 33 47 32 37 16 94 29\n" +
            "53 71 44 65 25 43 91 52 97 51 14\n" +
            "70 11 33 28 77 73 17 78 39 68 17 57\n" +
            "91 71 52 38 17 14 91 43 58 50 27 29 48\n" +
            "63 66 04 68 89 53 67 30 73 16 69 87 40 31\n" +
            "04 62 98 27 23 09 70 98 73 93 38 53 60 04 23";

        public Problem0018()
        {
            var arr = Fill();

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (var i = arr.Length - 1; i > 0; i--)
            for (var j = 0; j < arr[i].Length - 1; j++)
                arr[i - 1][j] += Math.Max(arr[i][j], arr[i][1 + j]);

            result = arr[0][0];

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(18, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private int[][] Fill()
        {
            var result = new int[Pyramid.Split("\n").Length][];

            var i = 0;
            foreach (var s in Pyramid.Split("\n"))
            {
                var j = 0;
                result[i] = new int[s.Split(" ").Length];
                foreach (var number in s.Split(" "))
                {
                    result[i][j] = int.Parse(number);
                    j++;
                }

                i++;
            }

            return result;
        }
    }
}