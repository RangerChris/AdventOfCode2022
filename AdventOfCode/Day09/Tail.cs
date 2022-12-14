namespace AdventOfCode.Day09;

public class Tail
{
    public Tail(int x, int y)
    {
        Position = new Position(x, y);
    }
    
    public Position Position { get; set; }
}