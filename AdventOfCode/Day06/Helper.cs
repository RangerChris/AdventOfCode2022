﻿namespace AdventOfCode.Day06;

public static class Helper
{
    public static IList<int> AllIndexOf(this string text, string str, StringComparison comparisonType)
    {
        IList<int> allIndexOf = new List<int>();
        int index = text.IndexOf(str, comparisonType);
        while(index != -1)
        {
            allIndexOf.Add(index);
            index = text.IndexOf(str, index + 1, comparisonType);
        }
        return allIndexOf;
    }
}