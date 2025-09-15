using UnityEngine;

public class FormatNumber : MonoBehaviour
{
    public string FormatWithSuffix(float number)
    {
        string[] suffixes = { "", "k", "M", "B", "T", "AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH"};
        int suffixIndex = 0;

        while (number >= 1000f && suffixIndex < suffixes.Length - 1)
        {
            number /= 1000f;
            suffixIndex++;
        }

        return number.ToString("0.##") + suffixes[suffixIndex];
    }

    public string FormatRoundedSuffix(float number)
    {
        string[] suffixes = { "", "k", "M", "B", "T", "AA", "BB", "CC", "DD", "EE", "FF", "GG", "HH"};
        int suffixIndex = 0;

        while (number >= 1000f && suffixIndex < suffixes.Length - 1)
        {
            number /= 1000f;
            suffixIndex++;
        }

        // Round down to nearest whole number (truncate)
        int rounded = Mathf.FloorToInt(number);

        return rounded.ToString() + suffixes[suffixIndex];
    }
}
