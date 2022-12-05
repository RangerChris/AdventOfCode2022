namespace AdventOfCode.Day05;

public class MovementInstructions
{
    public MovementInstructions(string instruction)
    {
        var reducedInstruction = instruction.Replace("move ", "");
        reducedInstruction = reducedInstruction.Replace("from ", "");
        reducedInstruction = reducedInstruction.Replace("to ", "");
        var keyNumbers = reducedInstruction.Split(' ');
        NumberOfCreatesToMove = Convert.ToInt32(keyNumbers[0]);
        FromStack = Convert.ToInt32(keyNumbers[1]);
        ToStack = Convert.ToInt32(keyNumbers[2]);
    }

    public int ToStack { get; set; }

    public int FromStack { get; set; }

    public int NumberOfCreatesToMove { get; set; }
}