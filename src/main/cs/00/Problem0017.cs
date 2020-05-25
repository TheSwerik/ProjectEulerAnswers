using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0017
    {
        public Problem0017()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            var map = new Dictionary<int, int>();
            map.Add(0, 0);
            map.Add(1, 3);
            map.Add(2, 3);
            map.Add(3, 5);
            map.Add(4, 4);
            map.Add(5, 4);
            map.Add(6, 3);
            map.Add(7, 5);
            map.Add(8, 5);
            map.Add(9, 4);
            map.Add(10, 3);
            map.Add(11, 6);
            map.Add(12, 6);
            map.Add(13, 8);
            map.Add(15, 7);
            map.Add(18, 8);
            for (var i = 1; i < 1000; i++)
            {
                var test = result;
                var rest = i + "";
                if (i >= 100)
                {
                    result += map[rest[0] - 48]; // first digit
                    result += 7; // hundred
                    rest = rest.Substring(1); // keep last two digits
                    if (rest.Equals("00")) continue;
                    result += 3; // and
                }

                var restInt = int.Parse(rest);
                if (restInt < 14 || restInt == 15 || restInt == 18)
                {
                    result += map[restInt]; // below 14, or 15 or 18
                }
                else if (restInt < 20)
                {
                    result += map[rest[1] - 48]; // last digit
                    result += 4; // teen
                }
                else
                {
                    if (rest[0] - 48 == 2 || rest[0] - 48 == 3 || rest[0] - 48 == 8)
                        result += 4; // twen- or thir- or eigh-
                    else if (rest[0] - 48 == 5 || rest[0] - 48 == 4)
                        result += 3; // fif- or for-
                    else
                        result += map[rest[0] - 48]; // first digit
                    result += 2; // -ty
                    result += map[rest[1] - 48]; // last digit
                }
            }

            result += 11; // one thousand


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(17, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}