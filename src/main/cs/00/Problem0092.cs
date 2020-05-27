using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs.de.swerik.euler._00
{
    public class Problem0092
    {
        public Problem0092()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            var found = new byte[600];
            for (var i = 2; i < 10_000_000; i++)
            {
                var tempFound = new List<int>();
                byte add = 1;
                var temp = i;
                while (true)
                {
                    var input = temp;
                    temp = 0;
                    while (input > 0)
                    {
                        var digit = input % 10;
                        temp += digit * digit;
                        input /= 10;
                    }

                    if (temp == 89 || found[temp] == 1)
                    {
                        result++;
                        break;
                    }

                    if (temp == 1 || found[temp] == 2)
                    {
                        add = 2;
                        break;
                    }

                    tempFound.Add(temp);
                }

                foreach (var foundInt in tempFound.ToArray()) found[foundInt] = add;
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                   ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                   : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                     " ms"));
            if (ProblemTest.DoBenchmark)
                Benchmark.AddTime(92, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}
