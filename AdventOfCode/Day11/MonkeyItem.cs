namespace AdventOfCode.Day11;

public class MonkeyItem
{
    public MonkeyItem(int level)
    {
        WorryLevel = level;
    }

    public int WorryLevel { get; set; }
    public int NumberOfTimesInspected { get; set; }
}