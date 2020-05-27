using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0042
    {
        public Problem0042()
        {
            var words = readWords();
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            var triangles = generateTriangles(15 * 26);
            foreach (var word in words)
                if (triangles.Contains((int) wordValue(word)))
                    result++;


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                ProblemBenchmark.AddTime(
                    42, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private List<int> generateTriangles(long range)
        {
            var triangles = new List<int>();

            for (var i = 1; i <= range; i++) triangles.Add((int) (0.5 * i * (i + 1)));

            return triangles;
        }

        private long wordValue(string word)
        {
            return word.Aggregate<char, long>(0, (current, c) => current + (c - 64));
        }

        private IEnumerable<string> readWords()
        {
            var file = File.ReadAllLines(@"resources\problem0042_words.txt");

            var st = file.Aggregate("", (current, s) => current + s);

            return st.Replace("\"", "").Split(",");
        }
    }
}