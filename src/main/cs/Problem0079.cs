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
            for (int i = 1_000_000;; i++)
            {
                passcode = i + "";
                foreach (string line in lines)
                {
                    string search = passcode;
                    if (search.Contains(line[0])) search = search.Substring(search.IndexOf(line[0]));
                    else goto end;

                    if (search.Contains(line[1])) search = search.Substring(search.IndexOf(line[1]));
                    else goto end;

                    if (!search.Contains(line[2])) goto end;
                }

                break;
                end:
                {
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