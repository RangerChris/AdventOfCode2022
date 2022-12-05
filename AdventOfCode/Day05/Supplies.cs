namespace AdventOfCode.Day05;

public class Supplies
{
    public List<List<char>> Stacks = new();

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
        foreach (var instruction in Instructions)
        {
            Console.WriteLine(instruction.OriginalInstruction);
            for (int i = 0; i < instruction.NumberOfCreatesToMove; i++)
            {
                var crate = Stacks[instruction.FromStack-1].Last();
                Stacks[instruction.FromStack-1].RemoveAt(Stacks[instruction.FromStack-1].Count-1);
                Stacks[instruction.ToStack-1].Add(crate);
            }
        }
    }
}