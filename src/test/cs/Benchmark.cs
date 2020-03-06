using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using ClosedXML.Excel;
using ExcelDataReader;

namespace Euler.test.cs
{
    public class Benchmark
    {
        private static readonly int max = 1000;
        private static readonly int checks = 25;
        private static readonly ArrayList Skip = new ArrayList {148, 704};
        private static Dictionary<int, ArrayList> _times;

        public Benchmark()
        {
            _times = new Dictionary<int, ArrayList>();
            // Test every Problem:
            Console.WriteLine("Starting Benchmark...");
            for (var i = 1; i <= max; i++)
            {
                for (int j = 0; j < checks; j++)
                {
                    System.Console.WriteLine("Checking Problem " + i + "\t Run: " + (j + 1));
                    //start Problems:
                    string input = i + "";
                    string path = "Euler.main.cs.Problem" + new string('0', 4 - input.Length) + input;
                    Type problem = Type.GetType(path);
                    if (problem == null || Skip.Contains(i))
                    {
                        Console.SetCursorPosition(0, Console.CursorTop - 1);
                        ClearCurrentConsoleLine();
                        break;
                    }
                    else
                    {
                        Activator.CreateInstance(problem);
                    }

                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                    Console.SetCursorPosition(0, Console.CursorTop - 1);
                    ClearCurrentConsoleLine();
                }
            }

            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.WriteLine("Benchmark Finished!");
            //Write to Excel:
            WriteToExcel();
        }

        private void WriteToExcel()
        {
            Console.WriteLine("Writing to Excel...");
            using var workbook =
                new XLWorkbook("G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\EulerBenchmark.xlsx");
            var worksheet = workbook.Worksheet(1);
            int index = 10;
            foreach (var cell in worksheet.Row(1).Cells())
            {
                if (cell.GetString().Contains("C#"))
                {
                    index = cell.WorksheetColumn().ColumnNumber();
                }
            }

            //write Excel
            for (int i = 1; i <= max; i++)
            {
                if (!_times.ContainsKey(i))
                {
                    worksheet.Column(index).Cell(i + 1).Value = "/";
                    continue;
                }

                double avg = _times[i].Cast<double>().Sum();
                avg /= _times[i].Count;
                worksheet.Column(index).Cell(i + 1).Value = avg;
            }

            workbook.SaveAs("G:\\Programme\\IntelliJ Projects\\ProjectEulerAnswers\\EulerBenchmark.xlsx");
            
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            ClearCurrentConsoleLine();
            Console.WriteLine("Excel file written!");
        }

        public static void AddTime(int number, double timeInMs)
        {
            if (!_times.ContainsKey(number))
            {
                _times.Add(number, new ArrayList());
            }

            _times[number].Add(timeInMs);
        }

        private void ClearCurrentConsoleLine()
        {
            int currentLineCursor = Console.CursorTop;
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, currentLineCursor);
        }
    }
}