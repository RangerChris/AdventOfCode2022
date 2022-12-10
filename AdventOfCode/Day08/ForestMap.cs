namespace AdventOfCode.Day08;

public class ForestMap
{
    public readonly Tree[][] Map;

    public ForestMap(string forestMap)
    {
        var rows = forestMap.Split(Environment.NewLine);
        var columns = rows[0].Length;
        Map = new Tree[rows.Length][];

        CreateTrees(rows, columns);

        SetVisibility();
    }

    public int Rows => Map.Length;
    public int Columns => Map.Length;

    private void CreateTrees(string[] rows, int columns)
    {
        for (var i = 0; i < rows.Length; i++)
        {
            Map[i] = new Tree[columns];
            for (var j = 0; j < columns; j++)
            {
                var height = Convert.ToInt32(rows[i][j].ToString());
                Map[i][j] = new Tree(height);
            }
        }
    }

    private void SetVisibility()
    {
        for (var i = 0; i < Rows; i++)
        for (var j = 0; j < Columns; j++)
            Map[i][j].Visible = IsVisible(i, j);
    }

    private bool IsVisible(int i, int j)
    {
        if (IsAtEdge(i, j)) return true;

        var tree = Map[i][j];

        if (tree.Height == 0) return false;
        
        var scenicScoreNorth = ScenicScoreNorth(i, j);
        var scenicScoreSouth = ScenicScoreSouth(i, j);
        var scenicScoreEast = ScenicScoreEast(i, j);
        var scenicScoreWest = ScenicScoreWest(i, j);

        tree.ScenicScore = scenicScoreNorth * scenicScoreSouth * scenicScoreEast * scenicScoreWest;

        if (HasLineOfSightNorth(i, j) ||
            HasLineOfSightSouth(i, j) ||
            HasLineOfSightEast(i, j) ||
            HasLineOfSightWest(i, j))
            return true;

        return false;
    }
    
    private int ScenicScoreWest(int i, int j)
    {
        var tree = Map[i][j];
        var scenicValue = 0;
        for (var y = 1; y < Columns; y++)
        {
            if (j - y < 0)
            {
                continue;
            }

            if (tree.Height <= Map[i][j-y].Height)
            {
                scenicValue++;
                return scenicValue;
            }
            scenicValue++;
        }

        return scenicValue;
    }
    
    private int ScenicScoreEast(int i, int j)
    {
        var tree = Map[i][j];
        var scenicValue = 0;
        for (var y = 1; y <= Columns; y++)
        {
            if (j + y >= Columns)
            {
                continue;
            }

            if (tree.Height <= Map[i][j+y].Height)
            {
                scenicValue++;
                return scenicValue;
            }
            scenicValue++;
        }

        return scenicValue;
    }
    
    private int ScenicScoreSouth(int i, int j)
    {
        var tree = Map[i][j];
        var scenicValue = 0;
        for (var y = 1; y < Rows; y++)
        {
            if (i + y >= Rows)
            {
                continue;
            }

            if (tree.Height <= Map[i + y][j].Height)
            {
                scenicValue++;
                return scenicValue;
            }

            scenicValue++;
        }

        return scenicValue;
    }
    
    private int ScenicScoreNorth(int i, int j)
    {
        var tree = Map[i][j];
        var scenicValue = 0;
        for (var y = 1; y < Rows; y++)
        {
            if (i - y < 0)
            {
                continue;
            }

            if (tree.Height <= Map[i - y][j].Height)
            {
                scenicValue++;
                return scenicValue;
            }

            scenicValue++;
        }

        return scenicValue;
    }

    private bool IsAtEdge(int i, int j)
    {
        if (i == 0 || i == Rows-1) return true;
        if (j == 0 || j == Columns-1) return true;

        return false;
    }

    private bool HasLineOfSightNorth(int i, int j)
    {
        var tree = Map[i][j];
        for (var y = 1; y < Rows; y++)
        {
            if (i - y < 0)
            {
                continue;
            }

            if (tree.Height <= Map[i - y][j].Height)
            {
                return false;
            }
        }

        return true;
    }

    private bool HasLineOfSightSouth(int i, int j)
    {
        var tree = Map[i][j];
        for (var y = 1; y < Rows; y++)
        {
            if (i + y >= Rows)
            {
                continue;
            }

            if (tree.Height <= Map[i + y][j].Height)
            {
                return false;
            }
        }

        return true;
    }

    private bool HasLineOfSightEast(int i, int j)
    {
        var tree = Map[i][j];
        for (var y = 1; y <= Columns; y++)
        {
            if (j + y >= Columns)
            {
                continue;
            }

            if (tree.Height <= Map[i][j+y].Height)
            {
                return false;
            }
        }

        return true;
    }

    private bool HasLineOfSightWest(int i, int j)
    {
        var tree = Map[i][j];
        for (var y = 1; y < Columns; y++)
        {
            if (j - y < 0)
            {
                continue;
            }

            if (tree.Height <= Map[i][j-y].Height)
            {
                return false;
            }
        }

        return true;
    }

    public IEnumerable<Tree> GetVisibleTrees()
    {
        var visibleTrees = Map.SelectMany(c => c).ToList().Where(t => t.Visible);
        return visibleTrees;
    }
}