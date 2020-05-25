using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0014
    {
        public Problem0014()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            // Dictionary<long, long> map = new Dictionary<long, long>();
            // long maxCount = 0;
            // for (int i = 2; i <= 1000000; i++)
            // {
            //     long test = i;
            //     long count = 0;
            //     do
            //     {
            //         if (map.ContainsKey(test))
            //         {
            //             count += map[test];
            //             break;
            //         }
            //
            //         if ((test & 1) == 0)
            //         {
            //             test /= 2;
            //         }
            //         else
            //         {
            //             test = test * 3 + 1;
            //         }
            //
            //         count++;
            //     } while (test != 1);
            //
            //     map.Add(i, count);
            //     if (count > maxCount)
            //     {
            //         maxCount = count;
            //         result = i;
            //     }
            // }

            //faster: array > map
            var map = new int[1000001];
            var maxCount = 0;
            for (var i = 2; i <= 1000000; i++)
            {
                long test = i;
                var count = 0;
                do
                {
                    if (test < 1000001 && map[(int) test] != 0)
                    {
                        count += map[(int) test];
                        break;
                    }

                    if ((test & 1) == 0)
                        test /= 2;
                    else
                        test = test * 3 + 1;

                    count++;
                } while (test != 1);

                map[i] = count;
                if (count > maxCount)
                {
                    maxCount = count;
                    result = i;
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
                Benchmark.AddTime(14, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}