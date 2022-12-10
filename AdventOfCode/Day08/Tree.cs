namespace AdventOfCode.Day08;

public class Tree
{
    public Tree(int height)
    {
        Height = height;
        Visible = false;
    }

    public int Height { get; }
    public bool Visible { get; set; }
    public int ScenicScore { get; set; }

    public override string ToString()
    {
        return $"Height: {Height} Visible: {Visible}";
    }
}