using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace AmicableNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            List<int> amicableNumbers = new List<int>();
            int upperLimit = 10000;
            for (int i = 1; i < upperLimit; i++)
            {
                if (amicableNumbers.Contains(i)) continue;
                int divisorSumResult = GetProperDivisorSum(i);
                int divisorSumOfResult = GetProperDivisorSum(divisorSumResult);
                if (divisorSumResult != divisorSumOfResult && divisorSumOfResult == i)
                {
                    amicableNumbers.AddRange(new[] { i, divisorSumResult });
                }
            }
            int amicableNumSum = amicableNumbers.Sum();

            timer.Stop();
            Console.WriteLine($"Sum of all amicable numbers under {upperLimit} is {amicableNumSum}");
            Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }

        static int GetProperDivisorSum(int divisorsOf)
        {
            List<int> divisors = new List<int>();
            int upperLimit = Convert.ToInt32(Math.Floor(Math.Sqrt(divisorsOf)));
            for (int i = upperLimit; i >= 1; i--)
            {
                if (divisorsOf % i == 0)
                {
                    divisors.Add(i);
                    if (i != 1) divisors.Add(divisorsOf / i);
                }
            }
            int result = divisors.Sum();
            return result;
        }
    }
}