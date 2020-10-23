using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace QuadraticPrimes
{
    class Program
    {

        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            List<int> primes = new List<int>();
            for (int i = 1; i <= 1000; i++)
                if (IsPrime(i))
                    primes.Add(i);

            int coefficientA = default;
            int coefficientB = default;
            int coefficientPrimecount = default;
            for (int i = 0; i < primes.Count; i++)
            {
                int b = primes[i];
                for (int a = b * -1; a < b; a++)
                {
                    int n = 0;
                    int possiblePrime;
                    int primeCount = -1;
                    do
                    {
                        primeCount++;
                        possiblePrime = (n * n) + (a * n) + b;
                        n++;
                    } while (possiblePrime > 0 && IsPrime(possiblePrime));
                    if (primeCount == 0 || primeCount < coefficientPrimecount)
                        continue;
                    coefficientA = a;
                    coefficientB = b;
                    coefficientPrimecount = primeCount;
                }
            }

            int product = coefficientA * coefficientB;

            timer.Stop();
            Console.WriteLine("The product of the coefficients A and B of the " +
                "quadratic expression n^2 + an + b that generate the most prime " +
                $"numbers is {coefficientA} * {coefficientB} = " +
                $"{product} which generated {coefficientPrimecount} " +
                $"prime numbers\n");
            Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds:F2}ms");
        }

        private static bool IsPrime(int val)
        {
            if (val == 2 || val == 3)
                return true;
            else if (val % 2 == 0)
                return false;

            bool isPrime = true;
            int upperBoundary = Convert.ToInt32(Math.Floor(Math.Sqrt(val)));
            for (int i = 2; i <= upperBoundary; i++)
            {
                if (val % i == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            return isPrime;
        }
    }
}