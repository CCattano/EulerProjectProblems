using System;
using System.Diagnostics;
using System.Numerics;

namespace ThousandDigitFibNum
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            BigInteger firstFibNum;
            BigInteger lastFibNum = firstFibNum = 1;
            BigInteger currFibNum = 1;
            int fibNumsCalced = 2;
            while (currFibNum.ToString().Length < 1000)
            {
                currFibNum = lastFibNum + firstFibNum;
                firstFibNum = lastFibNum;
                lastFibNum = currFibNum;
                fibNumsCalced++;
            }

            timer.Stop();
            Console.WriteLine("Index of the first Fib Num to be 1000 digits " +
                $"long is {fibNumsCalced}");
            Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }
    }
}