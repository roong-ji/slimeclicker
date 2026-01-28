using UnityEngine;

public static class ValueFormatter
{
    private const double Unit = 1000;
    
    private static readonly string[] Units = 
    {
        "", "K", "M", "B", "T", 
        "aa", "ab", "ac", "ad", "ae", "af", "ag", "ah", "ai", "aj", "ak", "al", "am", "an", "ao", "ap", "aq", "ar", "as", "at", "au", "av", "aw", "ax", "ay", "az",
        "ba", "bb", "bc"
    };
    
    public static string ToUnitString(this double value)
    {
        if (value < Unit) return value.ToString("F0");

        int unitIndex = 0;
        double tempValue = value;

        while (tempValue >= Unit && unitIndex < Units.Length - 1)
        {
            tempValue /= Unit;
            unitIndex++;
        }

        return $"{tempValue:F2}{Units[unitIndex]}";
    }
}
