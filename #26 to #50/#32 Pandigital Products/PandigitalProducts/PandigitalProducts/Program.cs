using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PandigitalProducts
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            HashSet<int> products = new HashSet<int>();
            int sum = 0;

            for (int i = 1; i <= 2000; i++)
                for (int ni = 1; ni <= 500; ni++)
                {
                    int product = i * ni;
                    string components = $"{i}{ni}{product}";
                    if (!components.Contains("0") && components.Length == 9 && components.Distinct().Count() == 9)
                        if (products.Add(product))
                            sum += product;
                }

            timer.Stop();
            Console.WriteLine($"Sum of products who's concatenated multiplicand, " +
                $"multiple, and product is Pandigital is {sum}");
            Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds:F2}ms");
        }
    }
}