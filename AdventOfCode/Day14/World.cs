using System.Drawing;
using System.Text;

namespace AdventOfCode.Day14;

public class World
{
    public int WorldMinX;
    public int WorldMaxX;
    public int WorldMinY;
    public int WorldMaxY;
    internal readonly char[,] WorldData;

    private List<string> RockData { get; }

    public SandSpawner Spawner { get; }

    public World(string[] rockData)
    {
        RockData = rockData.ToList();
        CalculateWorldMinMax(rockData);
        WorldData = new char[ToDrawXCoordinate(WorldMaxX)+1, WorldMaxY+1];
        ParseRocks();
        Spawner = new SandSpawner(ToDrawXCoordinate(500), this);
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
                dataX.Add(ToDrawXCoordinate(Convert.ToInt16(xy[0])));
                dataY.Add(Convert.ToInt16(xy[1]));
            }
            AddRock(dataX, dataY);
        }
    }

    private void AddRock(IReadOnlyList<int> dataX, IReadOnlyList<int> dataY)
    {
        var pen = new Point(dataX[0], dataY[0]);
        var rockIndex = 1;

        while (rockIndex < dataX.Count)
        {
            if (pen.X < dataX[rockIndex] || pen.X > dataX[rockIndex])
            {
                DrawHorizontalLine(pen.X, pen.Y, dataX[rockIndex], dataY[rockIndex]);
            }

            if (pen.Y < dataY[rockIndex] || pen.Y > dataY[rockIndex])
            {
                DrawVerticalLine(pen.X, pen.Y, dataX[rockIndex], dataY[rockIndex]);
            }

            pen = new Point(dataX[rockIndex], dataY[rockIndex]);
            rockIndex++;
        }
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
        
        WorldData[Spawner.Position.X, Spawner.Position.Y] = '+';

        for (var y = 0; y < WorldData.GetLength(1); y++)
        {
            for (var x = 0; x < WorldData.GetLength(0); x++)
            {
                if (WorldData[x, y] > 0)
                {
                    result.Append(WorldData[x, y]);
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
    
    public int CountSandGrains()
    {
        int result = 0;
        

        for (var y = 0; y < WorldData.GetLength(1); y++)
        {
            for (var x = 0; x < WorldData.GetLength(0); x++)
            {
                if (WorldData[x, y] == 'o')
                {
                    result++;
                }
            }
        }

        return result;
    }

    public int ToDrawXCoordinate(int inputCoordinate)
    {
        var result = inputCoordinate - WorldMinX;
        return result;
    }

    public void DrawHorizontalLine(int x, int y, int x2, int y2)
    {
        var startX = x;
        var endX = x2;
        if (startX > x2)
        {
            startX = x2;
            endX = x;
        }

        while(startX <= endX)
        {
            WorldData[startX++, y] = '#';
        }
    }

    public void DrawVerticalLine(int x, int y, int x2, int y2)
    {
        var startY = y;
        var endY = y2;
        if (startY > y2)
        {
            startY = y2;
            endY = y;
        }

        while(startY <= endY)
        {
            WorldData[x, startY++] = '#';
        }
    }
}