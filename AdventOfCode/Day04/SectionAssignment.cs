namespace AdventOfCode.Day04;

public class SectionAssignment
{
    public readonly List<Pair> PairList = new();

    public SectionAssignment(string assignment)
    {
        ParsePairInput(assignment);
    }

    private void ParsePairInput(string pair)
    {
        var pairs = pair.Split(",");
        foreach (var currentPair in pairs)
        {
            var input = currentPair.Split("-");
            var newPair = new Pair(Convert.ToInt32(input[0]), Convert.ToInt32(input[1]));
            PairList.Add(newPair);
        }
    }

    public bool ContainsFully()
    {
        var orderedPairs = PairList.OrderBy(c => c.Min).ToList();
        if (orderedPairs[0].Min <= orderedPairs[1].Min &&
            orderedPairs[0].Max >= orderedPairs[1].Max)
        {
            return true;
        }

        if (orderedPairs[1].Min <= orderedPairs[0].Min &&
            orderedPairs[1].Max >= orderedPairs[0].Max)
        {
            return true;
        }

        return false;
    }

    public bool Overlaps()
    {
        var orderedPairs = PairList.OrderBy(c => c.Min).ToList();
        if ((orderedPairs[0].Min >= orderedPairs[1].Min &&
             orderedPairs[0].Min <= orderedPairs[1].Max) ||
            (orderedPairs[0].Max >= orderedPairs[1].Min &&
             orderedPairs[0].Max <= orderedPairs[1].Min))
        {
            return true;
        }

        if ((orderedPairs[1].Min >= orderedPairs[0].Min &&
             orderedPairs[1].Min <= orderedPairs[0].Max) ||
            (orderedPairs[1].Max >= orderedPairs[0].Min &&
             orderedPairs[1].Max <= orderedPairs[0].Min))
        {
            return true;
        }

        return false;
    }
}

public class Pair
{
    public Pair(int min, int max)
    {
        Min = min;
        Max = max;
    }

    public int Min { get; set; }
    public int Max { get; set; }
}