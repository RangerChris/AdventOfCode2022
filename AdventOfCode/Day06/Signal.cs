namespace AdventOfCode.Day06;

public class Signal
{
    public Signal(string signalData)
    {
        SignalData = signalData;
    }

    public string SignalData { get; set; }

    public int FindStart()
    {
        var startPosition = 0;
        while (startPosition < SignalData.Length)
        {
            var content = SignalData.Substring(startPosition, 4);
            if (IsAllDifferent(content))
            {
                return startPosition + 4;
            }
            startPosition++;
        }

        return 0;
    }

    private bool IsAllDifferent(string content)
    {
        if (content.Length != 4) return false;

        var indexes = new Dictionary<int, int>();
        var letter1 = content.AllIndexOf(content[0].ToString(), StringComparison.Ordinal);
        foreach (var currentLetter in letter1) indexes.Add(currentLetter, 0);

        try
        {
            var letter2 = content.AllIndexOf(content[1].ToString(), StringComparison.Ordinal);
            foreach (var currentLetter in letter2) indexes.Add(currentLetter, 0);
            var letter3 = content.AllIndexOf(content[2].ToString(), StringComparison.Ordinal);
            foreach (var currentLetter in letter3) indexes.Add(currentLetter, 0);
            var letter4 = content.AllIndexOf(content[3].ToString(), StringComparison.Ordinal);
            foreach (var currentLetter in letter4) indexes.Add(currentLetter, 0);
        }
        catch (Exception e)
        {
            return false;
        }

        return true;
    }
}