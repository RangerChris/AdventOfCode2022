using System.Text;

namespace AdventOfCode.Day12;

public class World
{
    public int WorldMinX;
    public int WorldMaxX;
    public int WorldMinY;
    public int WorldMaxY;
    private readonly char[,] _world;

    private List<string> RockData { get; }
    
    public World(string[] rockData)
    {
        RockData = rockData.ToList();
        CalculateWorldMinMax(rockData);
        _world = new char[10, 10];
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

        for (var y = 0; y < _world.GetLength(1); y++)
        {
            for (var x = 0; x < _world.GetLength(0); x++)
            {
                if (_world[x, y] > 0)
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

    public void DrawHorizontalLine(int x, int y, int length)
    {
        var xStart = ToDrawXCoordinate(x);
        var maxX = xStart + length;
        
        for (int xx = xStart; xx < maxX; xx++)
        {
            _world[xx, y] = '#';
        }
    }
    
    public void DrawVerticalLine(int xStart, int xEnd)
    {
        
    }
}