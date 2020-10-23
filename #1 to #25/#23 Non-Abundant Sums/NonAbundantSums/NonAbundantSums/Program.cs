using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NonAbundantSums
{
    public class Program
    {
        private static readonly Stopwatch _timer = new Stopwatch();

        public static void Main(string[] args)
        {
            _timer.Start();

            //Get all abundant nums between 12 and 28123
            List<int> abundantNums = new List<int>();
            for (int i = 12; i < 28123; i++)
            {
                int divisorSum = GetDivisorSum(i);
                if (divisorSum > i)
                    abundantNums.Add(i);
            }

            //For each num, add every other num to it, itself included
            List<int> abundantSums = new List<int>();
            for (int i = 0; i < abundantNums.Count; i++)
                for (int ni = i; ni < abundantNums.Count; ni++)
                {
                    int sum = abundantNums[i] + abundantNums[ni];
                    if (sum <= 28123)
                        abundantSums.Add(sum);
                }

            //Remove any duplicate sums
            abundantSums = abundantSums.Distinct().ToList();

            //for all nums between 0 and 28123 see if it's in the sum list
            //If not add it to the missing val list
            List<int> missingVals = new List<int>();
            for (int i = 0; i <= 28123; i++)
                if (!abundantSums.Contains(i))
                    missingVals.Add(i);

            //Calc sum of inexpressible nums
            int sumOfNums = missingVals.Sum();

            _timer.Stop();
            Console.WriteLine("The sum of all positive integers that cannot " +
                $"be expressed as the sum of two abundant numbers is {sumOfNums}");
            Console.WriteLine($"Problem solved in {_timer.ElapsedMilliseconds}ms");
        }

        private static int GetDivisorSum(int divisorOf)
        {
            List<int> divisors = new List<int>();

            int upperLimit = Convert.ToInt32(Math.Floor(Math.Sqrt(divisorOf)));
            for (int i = 1; i <= upperLimit; i++)
                if (divisorOf % i == 0)
                {
                    divisors.Add(i);
                    if (i != 1)
                    {
                        int divVal = divisorOf / i;
                        if (divVal != i)
                            divisors.Add(divVal);
                    }
                }

            int divisorSum = divisors.Sum();
            return divisorSum;
        }
    }
}