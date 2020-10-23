using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitCancellingFractions
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> nonTrivialFractions = new List<string>();
            for(int n = 1; n <= 98; n++)
            {
                for(int d = 1; d <= 99; d++)
                {
                    if(n == 49 && d == 98)
                    {
                    }
                    double LCD = GetLCD(n, d);
                    double reducedN = n / LCD;
                    double reducedD = d / LCD;
                    if (reducedN.ToString().Length > 1 || reducedD.ToString().Length > 1)
                        continue;
                    if ($"{d}".Contains($"{reducedD}") && $"{n}".Contains($"{reducedN}"))
                        nonTrivialFractions.Add($"{n}/{d} -> {reducedN}/{reducedD}");
                }
            }
        }

        static double GetLCD(int numerator, int denominator)
        {
            List<double> numDivisors = GetAllDivisors(numerator);
            List<double> denDivisors = GetAllDivisors(denominator);
            List<double> commonDivisors = new List<double>();
            for (int i = 0; i < numDivisors.Count; i++)
                if (denDivisors.Contains(numDivisors[i]))
                    commonDivisors.Add(numDivisors[i]);
            double LCD = commonDivisors.OrderByDescending(d => d).First();
            return LCD;
        }

        static List<double> GetAllDivisors(int number)
        {
            List<double> divisors = new List<double>();
            double upperLimit = Math.Floor(Math.Sqrt(number));
            for (int i = 1; i <= upperLimit; i++)
            {

                    divisors.Add(i);
                    if (i != 1)
                        divisors.Add(number / i);

            }
            return divisors;
        }
    }
}
