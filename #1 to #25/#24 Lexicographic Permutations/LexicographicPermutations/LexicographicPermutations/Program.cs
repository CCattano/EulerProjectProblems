using System;
using System.Diagnostics;

namespace LexicographicPermutations
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            string seed = "0123456789";
            int? permNum = 1000000;
            permNum ??= Factorial(seed.Length);

            string seq = string.Empty;
            int permQty = 0;
            for (int i = seed.Length - 1; i >= 0; i--)
            {
                int nextDigit = -1;
                int factorial = Factorial(i);
                while (permQty < permNum)
                {
                    nextDigit++;
                    if (seq.Contains(nextDigit.ToString()))
                        continue;
                    else if (seq.Length == seed.Length - 1)
                        break;
                    permQty += factorial;
                }
                seq += nextDigit;
                permQty -= factorial;
            }

            timer.Stop();
            Console.WriteLine($"Permutation number {permNum} of {seed} is {seq}");
            Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }

        private static int Factorial(int factorialOf)
        {
            int factorialVal = factorialOf;
            for (int i = factorialOf - 1; i > 1; i--)
                factorialVal *= i;
            return factorialVal;
        }
    }
}

//static void Shame(string[] args)
//{
//    //Definitely proud of this solve or impl
//    //2783915460 - answer
//    //https://en.wikipedia.org/wiki/Permutation#Generation_in_lexicographic_order
//    string seed = "0123456789";
//    List<string> perms = new List<string>() { seed };
//    while (true)
//    {
//        List<int> sequence = perms.Last().Select(c => int.Parse(c.ToString())).ToList();
//        List<int> indices = new List<int>();
//        for (int i = 0; i < sequence.Count - 1; i++)
//            if (sequence[i] < sequence[i + 1])
//                indices.Add(i);
//        if (!indices.Any())
//            break;
//        int firstIndex = indices.Max();
//        int firstVal = sequence[firstIndex];
//        indices = new List<int>();
//        for (int i = firstIndex + 1; i < sequence.Count; i++)
//            if (sequence[i] > sequence[firstIndex])
//                indices.Add(i);
//        int secondIndex = indices.Max();
//        int secondVal = sequence[secondIndex];
//        sequence[firstIndex] = secondVal;
//        sequence[secondIndex] = firstVal;
//        string newSeq = string.Join(string.Empty, sequence);
//        List<int> nextSequence = sequence.Take(firstIndex + 1).ToList();
//        nextSequence.AddRange(sequence.Skip(firstIndex + 1).Reverse().ToList());
//        string nextSeq = string.Join(string.Empty, nextSequence);
//        perms.AddRange(new[] { newSeq, nextSeq });
//    }
//    perms = perms.Distinct().OrderBy(perm => perm).ToList();
//    Console.WriteLine($"---{perms[999999]}---");
//}