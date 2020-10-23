using System;
using System.Diagnostics;

namespace CountingSundays
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int sundays = 0;
            DateTime date = new DateTime(1901, 1, 1);
            DateTime stop = new DateTime(2001, 1, 1);
            while (date < stop)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday)
                    sundays++;
                date = date.AddMonths(1);
            }

            timer.Stop();
            Console.WriteLine($"{sundays} Sundays fall on the first of the month " +
                "between 1/1/1901 and 12/31/2000");
            Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds}ms");
        }
    }
}