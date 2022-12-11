namespace AdventOfCode.Day11;

public class Monkey
{
    public Monkey(int monkeyIndex, IEnumerable<string> items, string worry, int worryTest, int trueMonkeyId, int falseMonkeyId)
    {
        Id = monkeyIndex;
        foreach (var item in items)
        {
            ItemList.Add(new MonkeyItem(Convert.ToInt32(item.Trim())));
        }
        WorryAction = worry;
        WorryTest = worryTest;
        TrueMonkeyId = trueMonkeyId;
        FalseMonkeyId = falseMonkeyId;
    }

    public int FalseMonkeyId { get; set; }

    public int TrueMonkeyId { get; set; }

    public int WorryTest { get; set; }

    public string WorryAction { get; set; }

    public readonly List<MonkeyItem> ItemList = new List<MonkeyItem>();
    public int Id { get; set; }

    public int InspectCount { get; set; }

    public void Inspect(MonkeyItem item)
    {
        // Play with item
        var worryTemp = WorryAction.Split(" ");
        if (worryTemp[0].Equals("*"))
        {
            if (worryTemp[1].Equals("old"))
            {
                item.WorryLevel *= item.WorryLevel;
            }
            else
            {
                item.WorryLevel *= Convert.ToInt32(worryTemp[1]);    
            }
            
        }

        if (worryTemp[0].Equals("+"))
        {
            item.WorryLevel += Convert.ToInt32(worryTemp[1]);
        }

        GiveItemToMonkey(item);

        item.NumberOfTimesInspected++;
        InspectCount++;
    }

    public void GiveItemToMonkey(MonkeyItem item)
    {
        item.WorryLevel = item.WorryLevel / 3;
        // Bored with item
        var divisibleTest = item.WorryLevel % WorryTest;
        if (divisibleTest == 0)
        {
            ItemList.Remove(item);
            var monkey = MonkeyBusiness.Monkeys.SingleOrDefault(c => c.Id == TrueMonkeyId);
            monkey?.ItemList.Add(item);
        }
        else
        {
            ItemList.Remove(item);
            var monkey = MonkeyBusiness.Monkeys.SingleOrDefault(c => c.Id == FalseMonkeyId);
            monkey?.ItemList.Add(item);
        }
    }
}