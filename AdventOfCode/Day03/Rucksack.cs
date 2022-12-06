namespace AdventOfCode.Day03;

public class Rucksack
{
    public Rucksack(string content)
    {
        Content = content;
    }

    public string Content { get; set; }

    public string Compartment1
    {
        get
        {
            var temp = Content.Substring(0, Content.Length / 2);
            return temp;
        }
    }

    public string Compartment2
    {
        get
        {
            var temp = Content.Substring(Content.Length / 2);
            return temp;
        }
    }

    public char PriorityItem
    {
        get
        {
            var item = Compartment1.Intersect(Compartment2);
            return item.FirstOrDefault();
        }
    }

    public int Priority
    {
        get
        {
            var offSet = 96;
            var item = PriorityItem;
            if (char.IsUpper(item)) offSet = 38;

            var priority = item - offSet;
            return priority;
        }
    }
}