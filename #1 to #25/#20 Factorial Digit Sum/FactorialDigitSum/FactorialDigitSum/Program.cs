using System;
using System.Diagnostics;
using System.Linq;
using System.Numerics;

namespace FactorialDigitSum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            int factorialOf = 100;

            //Use of some Linq
            //BigInteger factorialValue = factorialOf;
            //for (int i = factorialOf; i > 1; i--) factorialValue *= i;
            //int digitSum = factorialValue
            //                   .ToString()
            //                   .Select(digit => int.Parse(digit.ToString()))
            //                   .Sum();

            //Linq chain only for shits n giggles
            //int digitSum = Enumerable
            //                   .Range(1, factorialOf)
            //                   .Select(v => BigInteger.Parse(v.ToString()))
            //                   .Reverse()
            //                   .Aggregate(seed: (BigInteger)1, (a, cv) => a * cv)
            //                   .ToString()
            //                   .Select(digit => int.Parse(digit.ToString()))
            //                   .Sum();

            //No Linq
            BigInteger factorialValue = factorialOf;
            for (int i = factorialOf; i > 1; i--)
                factorialValue *= i;
            string factValAsStr = factorialValue.ToString();
            int digitSum = 0;
            for (int i = 0; i < factValAsStr.Length; i++)
                digitSum += int.Parse(factValAsStr[i].ToString());

            timer.Stop();
            Console.WriteLine($"Sum of the digits of {factorialOf}! is {digitSum}");
            Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }
    }
}