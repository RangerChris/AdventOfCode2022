namespace AdventOfCode.Day10;

public class Cpu
{
    public Cpu()
    {
        RegisterX = 1;
        Cycles = 1;
    }
    
    public int Cycles { get; set; }
    public int RegisterX { get; set; }
    private int _instructionCounter = 0;
    public List<string> Instructions { get; set; }
    public List<CpuStateLine> CpuStateHistory { get; set; }

    public void LoadInstructions(string input)
    {
        Instructions = input.Split(Environment.NewLine).ToList();
        CpuStateHistory = new List<CpuStateLine>();
    }

    public void Execute()
    {
        Instruction currentInstruction = null;

        while (_instructionCounter < Instructions.Count)
        {
            CpuStateHistory.Add(new CpuStateLine(Cycles, RegisterX, Cycles*RegisterX, currentInstruction));
            if (currentInstruction == null)
            {
                currentInstruction = GetNextInstruction();
            }

            currentInstruction.NumberOfCyclesToComplete--;

            if (currentInstruction.NumberOfCyclesToComplete == 0)
            {
                currentInstruction.PostExecution(this);
                _instructionCounter++;
                currentInstruction = null;
            }
            Cycles++;
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

    public CpuStateLine? GetSignalValue(int cycle)
    {
        var result = CpuStateHistory.SingleOrDefault(c => c.Cycle == cycle);
        return result;
    }
}

