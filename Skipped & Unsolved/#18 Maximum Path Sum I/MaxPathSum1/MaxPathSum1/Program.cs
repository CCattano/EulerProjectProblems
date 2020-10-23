using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace MaxPathSum1
{
    class Program
    {
        static void Main(string[] args)
        {
            MainProgram program = new MainProgram();
            //Stopwatch timer = new Stopwatch();
            //timer.Start();
            int maxPathSum = program.GetMaxPathSum();
            //timer.Stop();
            //Console.WriteLine($"Maximum Path Sum is {maxPathSum}");
            //Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }
    }

    public class MainProgram
    {
        private readonly List<List<int>> _triangle = new List<List<int>>();

        public int GetMaxPathSum()
        {
            int sum = 0;
            LoadData();

            int startingRowPos = 0;
            for (int row = 0; row < _triangle.Count; row++)
            {
                //Initial values
                int startingRowVal = _triangle[row][startingRowPos];
                int nextRowLeftVal = _triangle[row + 1][startingRowPos];
                int nextRowRightVal = _triangle[row + 1][startingRowPos + 1];
                //Initial sums
                int leftSum = startingRowVal + nextRowLeftVal;
                int rightSum = startingRowVal + nextRowRightVal;
                //Potential values
                //Two vals for immediate left choice
                int leftChoiceFutureLeftVal = _triangle[row + 2][startingRowPos];
                int leftChoiceFutureRightVal = _triangle[row + 2][startingRowPos + 1];
                //Two vals for immediate right choice
                int rightChoiceFutureLeftVal = _triangle[row + 2][startingRowPos + 1];
                int rightChoiceFutureRightVal = _triangle[row + 2][startingRowPos + 2];
                //Potential sums for immediate left choice
                int leftChoiceFutureLeftSum = leftSum + leftChoiceFutureLeftVal;
                int leftChoiceFutureRightSum = leftSum + leftChoiceFutureRightVal;
                //Potential sums for immediate right choice
                int rightChoiceFutureLeftSum = rightSum + rightChoiceFutureLeftVal;
                int rightChoiceFutureRightSum = rightSum + rightChoiceFutureRightVal;

                //Left choice options
                Console.WriteLine($"If you choose {nextRowLeftVal} the current sum will be {leftSum}");
                Console.WriteLine($"You could then choose from {leftChoiceFutureLeftVal} or {leftChoiceFutureRightVal}");
                Console.WriteLine($"Resulting in a potential sum of {leftChoiceFutureLeftSum} or {leftChoiceFutureRightSum}");
                //Right choice options
                Console.WriteLine($"If you choose {nextRowRightVal} the current sum will be {rightSum}");
                Console.WriteLine($"You could then choose from {rightChoiceFutureLeftVal} or {rightChoiceFutureRightVal}");
                Console.WriteLine($"Resulting in a potential sum of {rightChoiceFutureLeftSum} or {rightChoiceFutureRightSum}");

            }

            return 0;
        }

        private void LoadData()
        {
            const string fileName = @"triangle values.txt";
            string dir = Directory.GetCurrentDirectory();
            List<String> fileLines = File.ReadAllLines($"{dir}\\{fileName}").ToList();
            fileLines.ForEach(line =>
            {
                string cleanLine = line.Trim();
                List<Int32> lineValues = cleanLine.Split(" ").Select(lineVal => int.Parse(lineVal)).ToList();
                _triangle.Add(lineValues);
            });
        }

        private class IterationDetail
        {
            public int nextRowIndex { get; set; }
        }
    }
}
