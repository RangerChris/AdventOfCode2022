namespace AdventOfCode.Day10;

public abstract class Instruction
{
    public int NumberOfCyclesToComplete;
    public string Name { get; set; }

    public Instruction(string instruction)
    {
        if (instruction.Equals("noop"))
        {
            Name = instruction;
            NumberOfCyclesToComplete = 1;
        }
        if (instruction.StartsWith("addx"))
        {
            Name = "addx";
            NumberOfCyclesToComplete = 2;
        }
    }
    
    public abstract void PostExecution(Cpu cpu);
}

public class AddXInstruction : Instruction
{
    public AddXInstruction(string instruction, int value) : base(instruction)
    {
        XValue = value;
    }

    public int XValue { get; set; }

    public override void PostExecution(Cpu cpu)
    {
        cpu.RegisterX += XValue;
    }
}

public class NoopInstruction : Instruction
{
    public NoopInstruction(string instruction) : base(instruction)
    {
        
    }

    public override void PostExecution(Cpu cpu)
    {
        
    }
}