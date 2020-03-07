using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0026
    {
        public Problem0026()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;
            long resultCounter = 0;

            // Solution:
            for (int i = 10; i < 1000; i++)
            {
                long counter = 0;

                //find periode
                int rest = 10;
                List<int> list = new List<int>();
                while (true)
                {
                    if (rest % i != 0)
                    {
                        counter++;
                        int divisor = rest / i;
                        if (rest > divisor * i) rest -= divisor * i;
                        
                        rest *= 10;
                        if (list.Contains(rest)) break;
                        list.Add(rest);
                    }
                    else
                    {
                        counter = 0;
                        break;
                    }
                }

                if (counter > resultCounter)
                {
                    resultCounter = counter;
                    result = i;
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
                Benchmark.AddTime(26, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}