namespace AdventOfCode.Day10;

public class Cpu
{
    public Cpu()
    {
        RegisterX = 1;
    }
    
    public int Cycles { get; set; }
    public int RegisterX { get; set; }
    private int _instructionCounter = 0;
    public List<string> Instructions { get; set; }
    public List<CpuState> DebugHistory { get; set; }

    public void LoadInstructions(string input)
    {
        Instructions = input.Split(Environment.NewLine).ToList();
        DebugHistory = new List<CpuState>();
    }

    public void Execute()
    {
        Instruction currentInstruction = null;

        while (_instructionCounter < Instructions.Count)
        {
            if (currentInstruction == null)
            {
                currentInstruction = GetNextInstruction();
            }
            Cycles++;
            currentInstruction.NumberOfCyclesToComplete--;

            if (currentInstruction.NumberOfCyclesToComplete == 0)
            {
                currentInstruction.PostExecution(this);
                _instructionCounter++;
                currentInstruction = null;
            }
            
            DebugHistory.Add(new CpuState(Cycles, RegisterX, Cycles*RegisterX));
        }
        
    }

    private Instruction GetNextInstruction()
    {
        Instruction result = null;
        var instructionData = Instructions[_instructionCounter].Split(" ");

        if (instructionData[0].Equals("addx"))
        {
            result = new AddXInstruction("addx", Convert.ToInt32(instructionData[1]));
        }
        
        // Default instruction
        if (result == null)
        {
            result = new NoopInstruction("noop");
        }
        
        return result;
    }
}

