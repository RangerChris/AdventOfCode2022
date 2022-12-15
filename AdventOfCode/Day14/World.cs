using System.Drawing;
using System.Text;

namespace AdventOfCode.Day14;

public class World
{
    public int WorldMinX;
    public int WorldMaxX;
    public int WorldMinY;
    public int WorldMaxY;
    private readonly char[,] world;

    private List<string> RockData { get; }
    
    public World(string[] rockData)
    {
        RockData = rockData.ToList();
        CalculateWorldMinMax(rockData);
        world = new char[10, 10];
        ParseRocks();
    }

    private void ParseRocks()
    {
        foreach (var currentRock in RockData)
        {
            var coordinates = currentRock.Split(" ");
            var dataX = new List<int>();
            var dataY = new List<int>();
            foreach (var coordinate in coordinates)
            {
                var xy = coordinate.Split(",");
                dataX.Add(Convert.ToInt16(xy[0]));
                dataY.Add(Convert.ToInt16(xy[1]));
            }
            AddRock(dataX, dataY);
        }
    }

    private void AddRock(IReadOnlyList<int> dataX, IReadOnlyList<int> dataY)
    {
        var pen = new Point(ToDrawXCoordinate(dataX[0]), dataY[0]);
        var rockIndex = 0;

        foreach (var currentX in dataX)
        {
            var xCoordinate = ToDrawXCoordinate(currentX);
            var yCoordinate = dataY[rockIndex];

            if (pen.X < xCoordinate)
            {
                DrawHorizontalLine(pen.X, pen.Y, xCoordinate, yCoordinate);
            }

            if (pen.X > xCoordinate)
            {
                DrawHorizontalLine(xCoordinate, yCoordinate, pen.X, pen.Y);
            }
            
            if (pen.Y < yCoordinate)
            {
                DrawHorizontalLine(pen.X, pen.Y, xCoordinate, yCoordinate);
            }

            if (pen.Y > yCoordinate)
            {
                DrawHorizontalLine(xCoordinate, yCoordinate, pen.X, pen.Y);
            }

            rockIndex++;
            if (rockIndex < dataX.Count)
            {
                pen = new Point(ToDrawXCoordinate(dataX[rockIndex]), dataY[rockIndex]);    
            }
        }

        // for (var i = 0; i <= dataX.Count; i++)
        // {
        //     if (i < dataX.Count-1)
        //     {
        //         if (dataX[i] == dataX[i + 1])
        //         {
        //             DrawVerticalLine(dataX[i], dataY[i], dataY[i + 1] - dataY[i]);
        //         }
        //
        //         if (dataY[i] == dataY[i + 1])
        //         {
        //             DrawHorizontalLine(dataX[i], dataY[i], dataX[i] - dataX[i + 1]);
        //         }
        //     }
        // }
    }

    private void CalculateWorldMinMax(IEnumerable<string> rockData)
    {
        var allData = "";

        foreach (var rock in rockData)
        {
            allData += rock + " ";
        }

        var dataList = allData.Trim().Split(" ").ToList();
        var dataX = new List<int>();
        var dataY = new List<int>();

        foreach (var currentData in dataList)
        {
            var xy = currentData.Split(",");
            dataX.Add(Convert.ToInt16(xy[0]));
            dataY.Add(Convert.ToInt16(xy[1]));
        }

        WorldMinX = Convert.ToInt16(dataX.Min());
        WorldMaxX = Convert.ToInt16(dataX.Max());
        WorldMinY = Convert.ToInt16(dataY.Min());
        WorldMaxY = Convert.ToInt16(dataY.Max());
    }

    public string DrawWorld()
    {
        var result = new StringBuilder();

        for (var y = 0; y < world.GetLength(1); y++)
        {
            for (var x = 0; x < world.GetLength(0); x++)
            {
                if (world[x, y] > 0)
                {
                    result.Append('#');
                }
                else
                {
                    result.Append('.');
                }
            }

            result.Append(Environment.NewLine);
        }

        return result.ToString();
    }

    public int ToDrawXCoordinate(int inputCoordinate)
    {
        var result = inputCoordinate - WorldMinX;
        return result;
    }

    public void DrawHorizontalLine(int x, int y, int x2, int y2)
    {
        for (var xx = x; xx <= x2; xx++)
        {
            world[xx, y] = '#';
        }
    }
    
    public void DrawVerticalLine(int x, int y, int x2, int y2)
    {
        for (var yy = x; yy <= y2; yy++)
        {
            world[x, yy] = '#';
        }
    }
}