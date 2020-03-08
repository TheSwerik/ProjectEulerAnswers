using System;
using System.Diagnostics;
using System.IO;
using DocumentFormat.OpenXml.Wordprocessing;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0079
    {
        public Problem0079()
        {
            string[] lines =
                File.ReadAllLines(
                    "G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\src\\main\\resources\\p079_keylog.txt");
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            string passcode = "";
            bool[,] before = new bool[10, 10];
            foreach (string line in lines)
            {
                before[line[2] - 48, line[1] - 48] =
                    before[line[2] - 48, line[0] - 48] = before[line[1] - 48, line[0] - 48] = true;
            }

            int[] beforeI = new int[10];

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (before[i, j]) beforeI[i]++;
                }
            }

            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (j == 5 || j == 4) continue;
                    if (beforeI[j] == i)
                    {
                        passcode += j;
                        break;
                    }
                }
            }


            stopWatch.Stop();
            string elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + passcode + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
            {
                Benchmark.AddTime(79, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}