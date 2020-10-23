namespace LatticePaths
{
    class Program
    {
        private static long[,] rowsCols;

        static void Main(string[] args)
        {
            int xBoundary = 20;
            int yBoundary = xBoundary;
            System.Diagnostics.Stopwatch timer = new System.Diagnostics.Stopwatch();
            timer.Start();
            long pathCount = CalculatePaths(xBoundary, yBoundary);
            timer.Stop();
            System.Console.WriteLine($"{pathCount} total paths for a {xBoundary}x{yBoundary} grid");
            System.Console.WriteLine($"Problem solved in {timer.ElapsedMilliseconds}ms");
        }

        static long CalculatePaths(int xBoundary, int yBoundary)
        {
            InitializeGridData(xBoundary, yBoundary);
            for (int col = rowsCols.GetLength(1) - 2; col >= 0; col--)
            {
                for (int row = rowsCols.GetLength(0) - 2; row >= 0; row--)
                {
                    long valToRight = rowsCols[row, col + 1];
                    long valBelow = rowsCols[row + 1, col];
                    rowsCols[row, col] = valToRight + valBelow;
                }
            }
            long result = rowsCols[0, 0];
            return result;
        }

        static void InitializeGridData(int xBoundary, int yBoundary)
        {
            rowsCols = new long[yBoundary + 1, xBoundary];
            int initVal = rowsCols.GetLength(0);
            //Set Initial Y-Axis values
            for (int row = 0; row <= yBoundary; row++)
            {
                rowsCols[row, xBoundary - 1] = initVal--;
            }
            //Set Initial X-Axis values
            for (int col = 0; col < xBoundary; col++)
            {
                rowsCols[yBoundary, col] = 1;
            }
        }
    }
}