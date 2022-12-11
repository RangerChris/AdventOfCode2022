using System.Numerics;
using FluentAssertions;

namespace AdventOfCode.Day09;

public class Day09
{
    [Fact]
    public void Day09Hint1()
    {
        var input = @"R 4
U 4
L 3
D 1
R 4
D 1
L 5
R 2";

        var moves = input.Split(Environment.NewLine);
        var rope = new Rope();

        foreach (var move in moves)
        {
            rope.DoMovement(move);
        }

        rope.RopeHead.Position.X.Should().Be(2);
        rope.RopeHead.Position.Y.Should().Be(2);
        rope.RopeTail.Position.Y.Should().Be(1);
        rope.RopeTail.Position.Y.Should().Be(2);
    }
}

public class Rope
{
    public readonly Head RopeHead = new Head();
    public readonly Tail RopeTail = new Tail();
    public List<Vector2> VisitList = new List<Vector2>();

    public void DoMovement(string move)
    {
        var steps = move.Split(" ");
        switch (move[0])
        {
            case 'U' : MoveUp(Convert.ToInt32(steps[1]));
                break;
            case 'D' : MoveDown(Convert.ToInt32(steps[1]));
                break;
            case 'L' : MoveLeft(Convert.ToInt32(steps[1]));
                break;
            case 'R' : MoveRight(Convert.ToInt32(steps[1]));
                break;
        }
    }

    private void MoveRight(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            RopeHead.Position.X++;
            if (RopeHead.Position.X > RopeTail.Position.X)
            {
                
            }
        }
    }

    private void MoveLeft(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            RopeHead.Position.X--;
        }
    }

    private void MoveDown(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            RopeHead.Position.Y--;
        }
    }

    private void MoveUp(int steps)
    {
        for (var i = 0; i < steps; i++)
        {
            RopeHead.Position.Y++;
        }
    }
}

public class Tail
{
    public Tail()
    {
        Position = new Position(0, 0);
    }
    
    public Position Position { get; set; }
}

public class Head
{
    public Head()
    {
        Position = new Position(0, 0);
    }
    public Position Position { get; set; }
}

public class Position
{
    public int X;
    public int Y;

    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }
}