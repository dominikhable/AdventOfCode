using System.Drawing;

namespace AoC2025.Days;

public class Day09 : Day
{
    public override object Task1()
    {
        var tiles = GetInputLines()
            .Select(line => line.Split(','))
            .Select(parts => (X: long.Parse(parts[0]), Y: long.Parse(parts[1])))
            .ToList();

        return tiles
            .SelectMany((t, i) => tiles.Skip(i).Select(u => CalculateArea(t, u)))
            .Max();
    }

    private static long CalculateArea((long X, long Y) from, (long X, long Y) to)
    {
        return (Math.Abs(from.X - to.X) + 1) * (Math.Abs(from.Y - to.Y) + 1);
    }

    public override object Task2()
    {
        return string.Empty;
    }
}
