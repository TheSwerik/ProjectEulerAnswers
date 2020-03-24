using System;
using System.Globalization;
using System.Threading;

namespace Euler.test.cs
{
    public class Test
    {
        public static bool DoBenchmark = false;

        private static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture("en-US");
            Environment.CurrentDirectory = "..\\..\\..\\src";
            if (DoBenchmark)
            {
                new Benchmark();
                return;
            }

            while (true)
            {
                Console.WriteLine("\nWhich do you want to try out?");
                var input = Console.ReadLine();
                if (input.Equals("0")) return;

                //start Problems:
                var path = "Euler.main.cs._0" + (input.Length < 3 ? '0' : input[0]) + ".Problem" +
                           new string('0', 4 - input.Length) + input;
                var problem = Type.GetType(path);
                if (problem == null)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Cannot find the Class: " + path);
                    Console.ResetColor();
                }
                else
                {
                    Activator.CreateInstance(problem);
                }
            }
        }
    }
}