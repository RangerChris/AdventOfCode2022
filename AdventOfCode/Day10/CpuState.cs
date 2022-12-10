namespace AdventOfCode.Day10;

public class CpuState
{
    public CpuState(int cycleValue, int registerValue, long signalValue)
    {
        Cycle = cycleValue;
        RegisterValue = registerValue;
        SingalValue = signalValue;
    }

    public long SingalValue { get; set; }

    public int RegisterValue { get; set; }

    public int Cycle { get; set; }
    
}