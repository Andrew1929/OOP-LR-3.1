using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace OOL_LR_3._1
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "transactions.csv";
            string dateFormat = "yyyy-MM-dd";
            Func<string, DateTime> getDate = (line) => DateTime.ParseExact(line.Split(',')[0], dateFormat, CultureInfo.InvariantCulture);

            Func<string, double> getAmount = (line) => double.Parse(line.Split(',')[1]);

            Action<DateTime, double> displayTotal = (date, total) => Console.WriteLine($"{date.ToString(dateFormat)}: {total}");
            var groupedByDate = File.ReadLines(filePath)
                                    .GroupBy(getDate)
                                    .OrderBy(g => g.Key);
            DateTime currentDate = DateTime.MinValue;
            double currentTotal = 0;
            foreach (var group in groupedByDate)
            {
                if (currentDate != group.Key)
                {
                    displayTotal(currentDate, currentTotal);
                    currentDate = group.Key;
                    currentTotal = 0;
                }
                currentTotal += group.Sum(getAmount);
                displayTotal(currentDate, currentTotal);
                if (group.Count() % 10 == 0)
                {
                    RewriteToFile(group, filePath);
                }
            }
            displayTotal(currentDate, currentTotal);
        }
        static void RewriteToFile(IEnumerable<string> lines, string filePath)
        {
            string tempFilePath = Path.GetTempFileName();
            File.WriteAllLines(tempFilePath, lines);
            File.Delete(filePath);
            File.Move(tempFilePath, filePath);
        }
    }  
}
