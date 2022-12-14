namespace AdventOfCode.Day09;

public class Rope
{
    private readonly int _worldHeight;
    private readonly int _worldWidth;
    public readonly Head RopeHead;
    public readonly Tail RopeTail;
    public readonly Dictionary<string, Position> VisitList = new();

    public Rope(int width, int height)
    {
        _worldWidth = width;
        _worldHeight = height;
        RopeHead = new Head(0, _worldHeight-1);
        RopeTail = new Tail(0, _worldHeight-1);
        AddToVisitList(RopeTail.Position);
    }
    
    public string DoMovement(string move)
    {
        var worldOutput = "";
        var steps = move.Split(" ");
        switch (move[0])
        {
            case 'U':
                worldOutput += MoveUp(Convert.ToInt32(steps[1]));
                break;
            case 'D':
                worldOutput += MoveDown(Convert.ToInt32(steps[1]));
                break;
            case 'L':
                worldOutput += MoveLeft(Convert.ToInt32(steps[1]));
                break;
            case 'R':
                worldOutput += MoveRight(Convert.ToInt32(steps[1]));
                
                break;
        }

        return worldOutput;
    }

    private string MoveRight(int steps)
    {
        var movementShown = "";
        for (var i = 0; i < steps; i++)
        {
            var oldPosition = new Position(RopeHead.Position.X, RopeHead.Position.Y);
            RopeHead.Position.X++;
            if (RopeHead.Position.X - RopeTail.Position.X >= 2)
            {
                RopeTail.Position = oldPosition;
                AddToVisitList(RopeTail.Position);
            }
            
            movementShown += DisplayWorld();
            movementShown += Environment.NewLine;
            movementShown += Environment.NewLine;
        }

        return movementShown;
    }

    private string MoveLeft(int steps)
    {
        var movementShown = "";
        for (var i = 0; i < steps; i++)
        {
            var oldPosition = new Position(RopeHead.Position.X, RopeHead.Position.Y);
            RopeHead.Position.X--;
            if (RopeTail.Position.X - RopeHead.Position.X >= 2)
            {
                RopeTail.Position = oldPosition;
                AddToVisitList(RopeTail.Position);
            }
            
            movementShown += DisplayWorld();
            movementShown += Environment.NewLine;
            movementShown += Environment.NewLine;
        }
        return movementShown;
    }

    private string MoveDown(int steps)
    {
        var movementShown = "";
        for (var i = 0; i < steps; i++)
        {
            var oldPosition = new Position(RopeHead.Position.X, RopeHead.Position.Y);
            RopeHead.Position.Y++;
            if (RopeHead.Position.Y - RopeTail.Position.Y >= 2)
            {
                RopeTail.Position = oldPosition;
                AddToVisitList(RopeTail.Position);
            }
            
            movementShown += DisplayWorld();
            movementShown += Environment.NewLine;
            movementShown += Environment.NewLine;
        }
        
        return movementShown;
    }

    private string MoveUp(int steps)
    {
        var movementShown = "";
        for (var i = 0; i < steps; i++)
        {
            var oldPosition = new Position(RopeHead.Position.X, RopeHead.Position.Y);
            RopeHead.Position.Y--;
            if (RopeTail.Position.Y - RopeHead.Position.Y >= 2)
            {
                RopeTail.Position = oldPosition;
                AddToVisitList(RopeTail.Position);
            }
            
            movementShown += DisplayWorld();
            movementShown += Environment.NewLine;
            movementShown += Environment.NewLine;
        }
        
        return movementShown;
    }
    
    private void AddToVisitList(Position position)
    {
        VisitList.TryAdd("" + position.X + position.Y, position);
    }

    private string DisplayWorld()
    {
        var world = new char[_worldWidth, _worldHeight];

        world[0, _worldHeight-1] = 's';
        try
        {
            world[RopeTail.Position.X, RopeTail.Position.Y] = 'T';
            world[RopeHead.Position.X, RopeHead.Position.Y] = 'H';
        }
        catch (IndexOutOfRangeException e)
        {
            Console.WriteLine(e);
        }
        var screenOutput = "";

        for (var y = 0; y <= world.GetLength(1)-1; y++)
        {
            for (var x = 0; x <= world.GetLength(0)-1; x++)
            {
                if (world[x,y] != 0)
                {
                    screenOutput += world[x,y];
                }
                else
                {
                    screenOutput += ".";
                }
            }
            screenOutput += Environment.NewLine;
        }

        return screenOutput;
    }
}