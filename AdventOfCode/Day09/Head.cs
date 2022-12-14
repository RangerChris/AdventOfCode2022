namespace AdventOfCode.Day09;

public class Head
{
    public Head(int x, int y)
    {
        Position = new Position(x, y);
    }
    public Position Position { get; set; }
}