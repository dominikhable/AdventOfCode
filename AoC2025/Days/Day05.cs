namespace AoC2025.Days;

public class Day05 : Day
{
    public override object Task1()
    {
        var lines = GetInputLines().ToList();

        var indexOfEmpty = lines.IndexOf(string.Empty);

        var ranges = lines[..indexOfEmpty].Select(GetFromTo).ToList();

        var values = lines[(indexOfEmpty + 1)..].Select(long.Parse).ToList();

        return values.Count(val => ranges.Any(r => val >= r.from && val <= r.to));
    }

    public override object Task2()
    {
        return GetInputLines()
            .Where(l => l.Contains('-'))
            .Select(GetFromTo)
            .Sum(ProcessRangeRec);       
    }

    readonly List<(long from, long to)> processedRanges = [];

    private long ProcessRangeRec((long from, long to) range)
    {
        long res = 0;

        var snapshot = processedRanges.ToArray();

        foreach (var (from, to) in snapshot)
        {
            if (range.from >= from && range.to <= to)
            {
                return 0;
            }

            if (range.from < from && range.to >= from)
            {
                res += ProcessRangeRec((range.from, from - 1));
            }

            if (range.to > to && range.from <= to)
            {
                res += ProcessRangeRec((to + 1, range.to));
            }

            if (res != 0) break;
        }

        processedRanges.Add(range);

        return res != 0 ? res: range.to - range.from + 1;
    }

    private static (long from, long to) GetFromTo(string range)
    {
        var parts = range.Split('-');
        var from = long.Parse(parts[0]);
        var to = long.Parse(parts[1]);

        return (from, to);
    }
}
