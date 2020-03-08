using System;
using System.Diagnostics;
using System.IO;
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
            foreach (string line in lines)
            {
                int[] found = new int[3];
                Array.Fill(found, -1);
                string search = passcode;
                if (search.Contains(line[0]))
                {
                    found[0] = search.IndexOf(line[0]);
                    search = search.Substring(found[0]);
                }

                if (search.Contains(line[1]))
                {
                    found[1] = search.IndexOf(line[1]);
                    search = search.Substring(found[1]);
                }

                if (search.Contains(line[2]))
                {
                    found[2] = search.IndexOf(line[2]);
                    search = search.Substring(found[2]);
                }

                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] != -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
                if (found[0] == -1 && found[1] == -1 && found[2] == -1) passcode += line;
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