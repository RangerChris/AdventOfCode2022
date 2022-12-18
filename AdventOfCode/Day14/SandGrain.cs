namespace AdventOfCode.Day14;

public class SandGrain
{
    public Position Position;
    public World GameWorld { get; set; }

    public SandGrain(int positionX, int positionY, World world)
    {
        Position = new Position(positionX, positionY);
        GameWorld = world;
    }

    public void Move()
    {
        while (true)
        {
            // Move down
            if (GameWorld.WorldData[Position.X, Position.Y + 1] == 0)
            {
                Position = new Position(Position.X, Position.Y+1);
                continue;
            }
            
            // Can we move left
            if (GameWorld.WorldData[Position.X-1, Position.Y+1] == 0)
            {
                Position = new Position(Position.X-1, Position.Y);
                continue;
            }
            
            // Can we move right
            if (GameWorld.WorldData[Position.X+1, Position.Y+1] == 0)
            {
                Position = new Position(Position.X+1, Position.Y);
                continue;
            }

            GameWorld.WorldData[Position.X, Position.Y] = 'o';
            break;
        }
    }
}