using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._02
{
    public class Problem0206
    {
        public Problem0206()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            var start = (ulong) Math.Sqrt(1020304050607080900.0);
            var end = (ulong) Math.Sqrt(1929394959697989990.0);
            // String pattern = "1.2.3.4.5.6.7.8.9.0";
            // Regex regex = new Regex(pattern);

            for (var i = start; i <= end; i += 10)
            {
                // if (regex.IsMatch((i * i) + ""))
                // {
                //     result = i;
                //     break;
                // }

                var s = "" + i * i;
                if (s.Length != 19) continue;

                if (s[16] == '9' &&
                    s[14] == '8' &&
                    s[12] == '7' &&
                    s[10] == '6' &&
                    s[8] == '5' &&
                    s[6] == '4' &&
                    s[4] == '3' &&
                    s[2] == '2' &&
                    s[0] == '1' &&
                    s[18] == '0')
                {
                    result = i;
                    break;
                }
            }

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(206, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}
