using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0042
    {
        public Problem0042()
        {
            string[] words = readWords();
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            List<int> triangles = generateTriangles(15 * 26);
            foreach (string word in words)
            {
                if (triangles.Contains((int) wordValue(word)))
                {
                    result++;
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
                Benchmark.AddTime(42, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }

        private List<int> generateTriangles(long range)
        {
            List<int> triangles = new List<int>();

            for (int i = 1; i <= range; i++)
            {
                triangles.Add((int) (0.5 * i * (i + 1)));
            }

            return triangles;
        }

        private long wordValue(string word)
        {
            long result = 0;

            foreach (char c in word)
            {
                result += (c - 64);
            }

            return result;
        }

        private string[] readWords()
        {
            string[] file = File.ReadAllLines("G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\src\\main\\resources\\problem0042_words.txt");

            string st = "";
            foreach (string s in file)
            {
                st += s;
            }

            return (st.Replace("\"", "")).Split(",");
        }
    }
}