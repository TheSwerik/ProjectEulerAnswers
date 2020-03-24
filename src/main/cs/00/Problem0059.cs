using System;
using System.Diagnostics;
using System.IO;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0059
    {
        public Problem0059()
        {
            var encryptedStrings = File
                .ReadAllText(
                    "G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\src\\main\\resources\\p059_cipher.txt")
                .Split(',');
            var encrypted = new char[encryptedStrings.Length];
            for (var i = 0; i < encrypted.Length; i++) encrypted[i] = (char) int.Parse(encryptedStrings[i]);

            var stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (var a = 'a'; a <= 'z'; a++)
            for (var b = 'a'; b <= 'z'; b++)
            for (var c = 'a'; c <= 'z'; c++)
            {
                var decrypted = new char[encrypted.Length];
                for (var i = 0; i < decrypted.Length; i++)
                    decrypted[i] = (char) (encrypted[i] ^ (i % 3 == 0 ? a : i % 3 == 1 ? b : c));

                var dec = new string(decrypted);
                if (dec.Contains("Euler"))
                {
                    Console.WriteLine("\r" + a + b + c + "\t" + dec);
                    foreach (var ch in decrypted) result += ch;
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
                Benchmark.AddTime(59, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
        }
    }
}