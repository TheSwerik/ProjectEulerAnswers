using System;
using System.Diagnostics;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class _00.Problem0031
    {
        private readonly int[] _coins = {200, 100, 50, 20, 10, 5, 2, 1};
        private long _result;

        public _00.Problem0031()
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            // Solution:
            Combinations(200, 0);

            stopWatch.Stop();
            var elapsedTime = stopWatch.Elapsed.ToString();
            Console.WriteLine("Result:\t" + _result + "\tTime:\t" +
                              (double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1, 2)) >= 1
                                  ? double.Parse(elapsedTime.Substring(elapsedTime.LastIndexOf(":") + 1)) + " s"
                                  : double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000 +
                                    " ms"));
            if (Test.DoBenchmark)
                Benchmark.AddTime(31, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }

        private void Combinations(int rest, int coin)
        {
            if (rest == 0)
            {
                _result++;
                return;
            }

            for (var a = coin; a < _coins.Length; a++)
                if (rest - _coins[a] >= 0)
                    Combinations(rest - _coins[a], a);
        }
    }
}