using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace NamesScores
{
    class Program
    {
        private static readonly Stopwatch _timer = new Stopwatch();
        private static readonly List<string> _names = new List<string>();
        private static readonly List<char> _alphabet = new List<char>()
        {
            'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M',
            'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z'
        };

        static void Main(string[] args)
        {
            LoadData();
            int sumOfScores = _names
                                .Select(name => name.Select(c => _alphabet.IndexOf(c) + 1).Sum())
                                .Select((s, i) => s * (i + 1))
                                .Sum();
            _timer.Stop();
            Console.WriteLine($"Sum of name scores is {sumOfScores}");
            Console.WriteLine($"Problem solved in {_timer.ElapsedMilliseconds}ms");
        }

        static void LoadData()
        {
            const string fileName = @"p022_names.txt";
            string dir = Directory.GetCurrentDirectory();

            string fileLines = File.ReadAllText($"{dir}\\{fileName}").Replace(@"""", string.Empty);

            //Include time taken to reorder list in problem solve time by starting timer here.
            _timer.Start();
            _names.AddRange(fileLines.Split(",").OrderBy(v => v));
        }
    }
}