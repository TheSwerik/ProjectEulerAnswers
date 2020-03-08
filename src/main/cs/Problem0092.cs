using System;
using System.Collections.Generic;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0092
    {
        public Problem0092()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            ulong result = 0;

            // Solution:
            byte[] found = new byte[1_000_000];
            for (int i = 2; i < 10_000_000; i++)
            {
                List<int> tempFound = new List<int>();
                bool one = false;
                int temp = i;
                while (true)
                {
                    int input = temp;
                    temp = 0;
                    while (input > 0)
                    {
                        int digit = input % 10;
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
                        one = true;
                        break;
                    }

                    tempFound.Add(temp);
                }

                byte add = 0;
                if (one) add = 2;
                else add = 1;
                foreach (int foundInt in tempFound)
                {
                    found[foundInt] = add;
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
                Benchmark.AddTime(92, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}