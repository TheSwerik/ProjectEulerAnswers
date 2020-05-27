using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs._00
{
    public class Problem0036
    {
        public Problem0036()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 25;

            // Solution:
            var counter = 0;
            var nines = "99";
            var tens = "0";
            // under 10,000:
            for (long i = 11; i < 10_000;)
            {
                var binary = Convert.ToString(i, 2);
                if (binary.Equals(ReverseString(binary))) result += i;

                // 99 or 999 or 9999 or 99999
                if (i % int.Parse(nines) == 0)
                {
                    nines += "9";
                    tens = "1" + tens;
                    i += 2;
                    counter = 0;
                    continue;
                }

                // 111 & 2222 & 33333 & 444444:
                if (i > 100)
                {
                    if (++counter == 10)
                    {
                        i += 11;
                        counter = 0;
                    }
                    else
                    {
                        i += int.Parse(tens);
                    }

                    continue;
                }

                // < 100:
                if (i < 99) i += 11;
            }

            // over 10,000:
            counter = 0;
            long lastI = 10001;
            var addNumber1 = 1010;
            var addNumber2 = 100;
            var addNumber3 = 9001;
            for (long i = lastI, j = 0; i < 1_000_000;)
            {
                if (Convert.ToString(i, 2).Equals(ReverseString(Convert.ToString(i, 2)))) result += i;

                i += addNumber1;
                // when middle number(s) are 9 (xx9xx or xx99xx):
                if (++counter == 10)
                {
                    i = lastI + addNumber2;
                    lastI = (int) i;
                    counter = 0;
                    j++;
                }

                // when all inner numbers are 9 (x999x or x9999x):
                if (j == 10)
                {
                    j = 0;
                    i += addNumber3;
                    lastI = (int) i;
                }

                // change numbers when over 100,000:
                if (i == 100010)
                {
                    lastI = i = 100001;
                    counter = 0;
                    addNumber1 = 10010;
                    addNumber2 = 1100;
                    addNumber3 = 89001;
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
                ProblemBenchmark.AddTime(
                    36, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private string ReverseString(string s)
        {
            var arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}