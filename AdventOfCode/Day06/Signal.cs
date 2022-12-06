namespace AdventOfCode.Day06;

public class Signal
{
    public Signal(string signalData, int signalLength)
    {
        SignalData = signalData;
        SignalLength = signalLength;
    }

    public int SignalLength { get; set; }

    public string SignalData { get; set; }

    public int FindStart()
    {
        var startPosition = 0;
        while (startPosition < SignalData.Length)
        {
            var content = SignalData.Substring(startPosition, SignalLength);
            if (IsAllDifferent(content))
            {
                return startPosition + SignalLength;
            }
            startPosition++;
        }

        return 0;
    }

    private bool IsAllDifferent(string content)
    {
        if (content.Length != SignalLength) return false;

        var indexes = new Dictionary<int, int>();

        for (int i = 0; i < SignalLength; i++)
        {
            try
            {
                var letter1 = content.AllIndexOf(content[i].ToString(), StringComparison.Ordinal);
                foreach (var currentLetter in letter1)
                {
                    indexes.Add(currentLetter, 0);
                }
            }
            catch (Exception)
            {
                return false;
            }    
        }

        return true;
    }
}