namespace AdventOfCode.Day10;

public class CpuStateLine
{
    public CpuStateLine(int cycleValue, int registerValue, long signalValue, Instruction? currentInstruction)
    {
        Cycle = cycleValue;
        RegisterValue = registerValue;
        SignalValue = signalValue;
        CurrentInstruction = currentInstruction;
    }

    public override string ToString()
    {
        return $"Cycle: {Cycle} Reg-X {RegisterValue} Signal: {SignalValue} {CurrentInstruction}";
    }

    public Instruction? CurrentInstruction { get; set; }

    public long SignalValue { get; set; }

    public int RegisterValue { get; set; }

    public int Cycle { get; set; }
    
}