namespace AdventOfCode.Day03;

public class ElfGroup
{
    public ElfGroup()
    {
        Group = new List<Rucksack>();
    }
    public List<Rucksack> Group { get; set; }
    public char PriorityItem { get; set; }
    public int Priority { get; set; }
    public override string ToString()
    {
        return $"Members: {Group.Count} Priority: {Priority}";
    }
}