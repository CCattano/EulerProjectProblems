using System;
using System.Diagnostics;

namespace NumberSpiralDiagonals
{
    class Program
    {
        static void Main(string[] args)
        {
            Stopwatch timer = Stopwatch.StartNew();

            int lateralDimensionBoundary = 1001;
            int lastRing = (lateralDimensionBoundary - 1) / 2;
            int corner = 1;
            int ring = 1;
            int sum = 1;
            while (ring <= lastRing)
            {
                for (int i = 0; i < 4; i++)
                {
                    corner += ring == 1 ? ring + 1 : ring * 2;
                    sum += corner;
                }
                ring++;
            }

            timer.Stop();
            Console.WriteLine($"Diagonal Sum is {sum}");
            Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds:F3}ms");
        }
    }
}

//    private static List<List<int>> _grid = new List<List<int>>();

//    static void OldMain(string[] args)
//    {
//        Stopwatch timer = Stopwatch.StartNew();
//        GenerateEmptyGrid(1001, 1001);
//        PopulateEmptyGrid();
//        int diagonalSum = CountDiagonals();
//        timer.Stop();
//        Console.WriteLine($"Diagonal Sum is {diagonalSum}");
//        Console.WriteLine($"Problem solved in {timer.Elapsed.TotalMilliseconds:F2}ms");
//    }

//    private static void GenerateEmptyGrid(int x, int y)
//    {
//        List<int> row = new List<int>();
//        for (int xAxis = 0; xAxis < x; xAxis++)
//            row.Add(0);
//        for (int yAxis = 0; yAxis < y; yAxis++)
//            _grid.Add(row.Concat(Array.Empty<int>()).ToList());
//    }

//    private static void PopulateEmptyGrid()
//    {
//        //Positional Info
//        int stopXPos = _grid[0].Count - 1;
//        int stopYPos = 0;
//        int xPos = stopXPos / 2;
//        int yPos = (_grid.Count - 1) / 2;
//        //Transitional Info
//        int xTraverseCt = 1;
//        int yTraverseCt = 1;
//        MoveDir direction = MoveDir.Right;
//        //Initial Vals
//        int lastValue = 1;
//        _grid[yPos][xPos] = lastValue;
//        //Das loop
//        while (!(yPos == stopYPos && xPos == stopXPos))
//            switch (direction)
//            {
//                case MoveDir.Right:
//                    int traverseCt = yPos == 0 ? xTraverseCt - 1 : xTraverseCt;
//                    for (int i = 0; i < traverseCt; i++)
//                        _grid[yPos][++xPos] = ++lastValue;
//                    xTraverseCt++;
//                    direction = MoveDir.Down;
//                    break;
//                case MoveDir.Down:
//                    for (int i = 0; i < yTraverseCt; i++)
//                        _grid[++yPos][xPos] = ++lastValue;
//                    yTraverseCt++;
//                    direction = MoveDir.Left;
//                    break;
//                case MoveDir.Left:
//                    for (int i = 0; i < xTraverseCt; i++)
//                        _grid[yPos][--xPos] = ++lastValue;
//                    xTraverseCt++;
//                    direction = MoveDir.Up;
//                    break;
//                case MoveDir.Up:
//                    for (int i = 0; i < yTraverseCt; i++)
//                        _grid[--yPos][xPos] = ++lastValue;
//                    yTraverseCt++;
//                    direction = MoveDir.Right;
//                    break;
//            }
//    }

//    private static int CountDiagonals()
//    {
//        //Initial Positions
//        int y1;
//        int x1 = y1 = 0;
//        int y2 = _grid.Count - 1;
//        int x2 = 0;
//        //Terminating Conditions
//        int stopX = _grid[0].Count - 1;
//        int stopY = _grid.Count - 1;
//        //Initial Value
//        int sum = _grid[y1][x1] + _grid[y2][x2];
//        //Das loop
//        while (!(y1 == stopY && x1 == stopX))
//            sum += _grid[++y1][++x1] + _grid[--y2][++x2];
//        //Account for shared intersection value
//        int midY = (_grid.Count - 1) / 2;
//        int midX = (_grid[0].Count - 1) / 2;
//        sum -= _grid[midY][midX];
//        return sum;
//    }

//public enum MoveDir
//{
//    Right,
//    Down,
//    Left,
//    Up
//}