namespace AoC2025.Days;

public class Day02 : Day
{
    public override object Task1() => GetInputSeparatedBy(',').SelectMany(GetRange).Where(IsInvalid1).Sum();

    public override object Task2() => GetInputSeparatedBy(',').SelectMany(GetRange).Where(IsInvalid2).Sum();

    private static bool IsInvalid1(long id)
    {
        var s = id.ToString();
        var len = s.Length;

        if (len % 2 == 1) return false;

        return s[..(len/2)] == s[^(len/2)..];
    }

    private static bool IsInvalid2(long id)
    {
        var s = id.ToString();
        var doubled = s + s;

        return doubled.IndexOf(s, 1, StringComparison.Ordinal) < s.Length;
    }

    private IEnumerable<long> GetRange(string range)
    {
        var parts = range.Split('-');
        var start = long.Parse(parts[0]);
        var end = long.Parse(parts[1]);

        for (var i = start; i <= end; i++)
        {
            yield return i;
        }
    }
}
