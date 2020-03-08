using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading;
using Euler.test.cs;

namespace Euler.main.cs
{
    public class Problem0059
    {
        public Problem0059()
        {
            string[] encryptedStrings = File
                .ReadAllText(
                    "G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\src\\main\\resources\\p059_cipher.txt")
                .Split(',');
            char[] encrypted = new char[encryptedStrings.Length];
            for (int i = 0; i < encrypted.Length; i++)
            {
                encrypted[i] = (char) int.Parse(encryptedStrings[i]);
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            long result = 0;

            // Solution:
            for (char a = 'a'; a <= 'z'; a++)
            {
                for (char b = 'a'; b <= 'z'; b++)
                {
                    for (char c = 'a'; c <= 'z'; c++)
                    {
                        char[] decrypted = new char[encrypted.Length];
                        for (int i = 0; i < decrypted.Length; i++)
                        {
                            decrypted[i] = (char) (encrypted[i] ^ (i % 3 == 0 ? a : i % 3 == 1 ? b : c));
                        }

                        string dec = new string(decrypted);
                        if (dec.Contains("Euler"))
                        {
                            System.Console.WriteLine("\r" + a + b + c + "\t" + dec);
                            foreach (char ch in decrypted)
                            {
                                result += ch;
                            }
                        }
                    }
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
                Benchmark.AddTime(59, double.Parse(elapsedTime.Substring(elapsedTime.IndexOf(".") + 1)) / 10_000);
            }
        }
    }
}