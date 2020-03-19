using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0089
    {
        public Problem0089()
        {
            string[] lines =
                File.ReadAllLines("main\\resources\\p089_roman.txt");
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            Dictionary<char, long> roman = new Dictionary<char, long>();
            roman.Add('M', 1000);
            roman.Add('D', 500);
            roman.Add('C', 100);
            roman.Add('L', 50);
            roman.Add('X', 10);
            roman.Add('V', 5);
            roman.Add('I', 1);
            // calc values
            long[] values = new long[lines.Length];
            // for (int i = 0; i < lines.Length; i++)
            for (int i = 0; i < 1; i++)
            {
                string line = lines[i];
                for (int j = 0; j < roman.Count; j++)
                {
                    char currentChar = roman.Keys.ElementAt(j);
                    if (line.Contains(currentChar))
                    {
                        char subtractChar = '0';
                        if (j < 6)= roman.Keys.ElementAt(j % 2 == 1 ? j + 1 : j + 2);
                        string part = line.Substring(0, line.LastIndexOf(currentChar) + 1);
                        if (part[0] == subtractChar)
                        {
                            values[j] -= roman[subtractChar];
                            part = part.Substring(1);
                        }

                        values[j] += (part.Length * roman[currentChar]);
                        line = line.Substring(part.Length);
                    }
                }

                System.Console.WriteLine(values[0]);
            }


            //calcMax:
            long max = 0;
            for (int i = 0; i < lines.Length; i++)
            {
                max += lines[i].Length;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + (result - max) + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(89, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}