namespace AdventOfCode.Day10;

public class Monitor
{
    private readonly char[][] _screen = 
    {
        new char[40],
        new char[40],
        new char[40],
        new char[40],
        new char[40],
        new char[40]
    };

    public string ShowScreen(Cpu cpu)
    {
        var screenOutput = "";

        DrawOnScreen(cpu);

        for (var y = 0; y < _screen.Length; y++)
        {
            for (var x = 0; x < _screen[y].Length; x++)
            {
                screenOutput += _screen[y][x];
            }
            screenOutput += Environment.NewLine;
        }
        
        return screenOutput;
    }

    private void DrawOnScreen(Cpu cpu)
    {
        var cycleIndex = 1;
        for (var y = 0; y < _screen.Length; y++)
        {
            for (var x = 0; x < _screen[y].Length; x++)
            {
                var regX = cpu.GetCpuStateAtCycle(cycleIndex)?.RegisterValue;
                if (regX == x - 1 || regX == x || regX == x + 1)
                {
                    _screen[y][x] = '#';    
                }
                else
                {
                    _screen[y][x] = '.';    
                }

                cycleIndex++;
            }
        }
    }
}