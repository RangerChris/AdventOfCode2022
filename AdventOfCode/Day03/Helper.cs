namespace AdventOfCode.Day03;

public static class Helper
{
    public static char GetGroupPriorityItem(List<Rucksack> group)
    {
        var tt = group[0].Content.Intersect(group[1].Content).Intersect(group[2].Content);
        return tt.FirstOrDefault();
    }

    public static int GetPriority(char item)
    {
        var offSet = 96;
        if (char.IsUpper(item)) offSet = 38;

        var priority = item - offSet;
        return priority;
    }
}