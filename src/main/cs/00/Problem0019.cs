using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0019
    {
        public Problem0019()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            //for every year:
            long count = -1;
            var once = false;
            for (var i = 0; i <= 100; i++)
            {
                if (!once && i == 1)
                {
                    result = 0;
                    once = true;
                }

                for (var j = 0; j < 12; j++)
                {
                    int days;
                    switch (j)
                    {
                        case 0:
                        case 2:
                        case 4:
                        case 6:
                        case 7:
                        case 9:
                        case 11:
                            days = 31;
                            break;
                        case 3:
                        case 5:
                        case 8:
                        case 10:
                            days = 30;
                            break;
                        case 1:
                            days = i % 4 == 0 && !once ? 29 : 28;
                            break;
                        default:
                            throw new ArgumentException("Unexpected value: " + j);
                    }

                    for (var k = 0; k < days; k++)
                        if (++count == 7)
                        {
                            count = 0;
                            if (k == 0) result++;
                        }
                }
            }


            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(19, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}