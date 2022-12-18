using System.Drawing;

namespace AdventOfCode.Day14;

public class SandSpawner
{
    public Point Position;
    private readonly World _gameWorld;
    public SandSpawner(int xCoordinate, World world)
    {
        Position = new Point(xCoordinate, 0);
        _gameWorld = world;
    }

    public int Start()
    {
        var result = 0;
        var sand = new SandGrain(Position.X, Position.Y+1, _gameWorld);
        while (!HaveFinished)
        {
            try
            {
                sand.Move();
                result++;
                sand.Position = new Position(Position.X, Position.Y+1);
            }
            catch (IndexOutOfRangeException)
            {
                HaveFinished = true;
            }
        }

        return result;
    }

    public bool HaveFinished { get; set; }
}