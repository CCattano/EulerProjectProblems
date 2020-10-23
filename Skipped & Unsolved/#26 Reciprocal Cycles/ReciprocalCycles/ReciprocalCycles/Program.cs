using System;
using System.Collections.Generic;
using System.Linq;

namespace ReciprocalCycles
{
    class Program
    {
        static void Main(string[] args)
        {
            List<CycleDetail> cycleDetails = new List<CycleDetail>();
            //for (decimal i = 2; i <= 1000; i++)
            for (decimal i = 7; i <= 1000; i++)
            {
                decimal value = 1m / i;
                Console.WriteLine($"{value}");
                string decimals = value.ToString().Split(".")[1];
                string seq = string.Empty;
                for (int ni = 0; ni < decimals.Length - 2; ni++)
                {
                    string cycle = $"{decimals[ni]}";
                    int nextIndex = decimals.IndexOf(cycle, ni);
                    if (decimals[ni + 1] == decimals[nextIndex + 1])
                    {
                        seq += cycle + decimals[ni + 1];
                        ni++;
                    }
                }
                if (!string.IsNullOrWhiteSpace(seq))
                    cycleDetails.Add(new CycleDetail()
                    {
                        Value = i,
                        CycleLength = seq.Length == 2 ? 1 : seq.Length,
                        Cycle = seq
                    });
            }
            decimal longestCycleDenominator = cycleDetails.OrderByDescending(cd => cd.CycleLength).First().Value;
            Console.WriteLine(cycleDetails.FirstOrDefault(cd => cd.Value == longestCycleDenominator)?.Cycle ?? "?");
            Console.WriteLine(longestCycleDenominator);
        }
    }

    public class CycleDetail
    {
        public decimal Value { get; set; }
        public int CycleLength { get; set; }
        public string Cycle { get; set; }
    }
}