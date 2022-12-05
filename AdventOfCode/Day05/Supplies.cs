namespace AdventOfCode.Day05;

public class Supplies
{
    public readonly List<List<char>> Stacks = new();

    public List<MovementInstructions> Instructions { get; set; }

    public void AddCreatesToStack(string content)
    {
        var newStack = new List<char>();
        newStack.AddRange(content);
        Stacks.Add(newStack);
    }

    public void AddInstructions(List<MovementInstructions> allInstructions)
    {
        Instructions = allInstructions;
    }

    public void StartCrane()
    {
        if (UseCrateMover9001)
        {
            foreach (var instruction in Instructions)
            {
                var startIndex = (Stacks[instruction.FromStack - 1].Count) - instruction.NumberOfCreatesToMove;
                var crateList = Stacks[instruction.FromStack - 1].GetRange(startIndex, instruction.NumberOfCreatesToMove);
                Stacks[instruction.FromStack - 1].RemoveRange(startIndex, instruction.NumberOfCreatesToMove);
                Stacks[instruction.ToStack - 1].AddRange(crateList);    
            }

            return;
        }
        
        foreach (var instruction in Instructions)
        {
            for (var i = 0; i < instruction.NumberOfCreatesToMove; i++)
            {
                var crate = Stacks[instruction.FromStack-1].Last();
                Stacks[instruction.FromStack-1].RemoveAt(Stacks[instruction.FromStack-1].Count-1);
                Stacks[instruction.ToStack-1].Add(crate);
            }
        }
    }

    public bool UseCrateMover9001 { get; set; }
}