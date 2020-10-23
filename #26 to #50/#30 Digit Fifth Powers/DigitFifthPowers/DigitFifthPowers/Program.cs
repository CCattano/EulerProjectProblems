using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace DigitFifthPowers
{
    public class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            int powerOf = 5;
            Dictionary<int, double> powers = new Dictionary<int, double>();
            for (int i = 0; i < 10; i++)
                powers.Add(i, Math.Pow(i, powerOf));

            double upperLimit = powers.Values.Last() * 4;
            List<double> results = new List<double>();

            for (int i = 2; i < upperLimit; i++)
            {
                double sum = 0;
                string number = i.ToString();
                for (int ni = 0; ni < number.Length; ni++)
                {
                    int digit = int.Parse(number[ni].ToString());
                    sum += powers[digit];
                    if (sum > i)
                        break;
                }
                if (sum == i)
                    results.Add(i);
            }

            double sumResult = results.Sum();

            timer.Stop();
            Console.WriteLine($"The sum of all numbers that can be written as the sum " +
                $"of their digits taken to the fifth power is {sumResult}");
            Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds:F2}ms");
        }
    }
}