using System;
using System.Threading;

namespace Euler.test.cs
{
    public class Test
    {
        public static bool DoBenchmark = false;

        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.CreateSpecificCulture("en-US");
            if (DoBenchmark)
            {
                Benchmark benchmark = new Benchmark();
                return;
            }

            while (true)
            {
                Console.WriteLine("\nWhich do you want to try out?");
                string input = Console.ReadLine();
                if (input.Equals("0"))
                {
                    return;
                }

                //start Problems:
                string path = "Euler.main.cs.Problem" + new string('0', 4 - input.Length) + input;
                Type problem = Type.GetType(path);
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