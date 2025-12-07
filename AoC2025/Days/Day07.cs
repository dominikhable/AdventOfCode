using System.Drawing;

namespace AoC2025.Days;

public class Day07 : Day
{
    public override object Task1()
    {
        var lines = GetInputLines();
        var result = 0;
        var beams = new HashSet<int>() { lines.First().IndexOf('S') };  

        foreach (var line in lines.Skip(1))
        {
            for(int i = 0; i < line.Length; i++)
            {
                if (line[i] == '^' && beams.Contains(i))
                {
                    beams.Remove(i);
                    beams.Add(i - 1);
                    beams.Add(i + 1);
                    result++;
                }
            }
        }

        return result;
    }

    public override object Task2()
    {
        var lines = GetInputLines();

        return QuantumSplitRec(lines.First().IndexOf('S'), 0, GetInputPoints('^'), lines.Count());       
    }

    private readonly Dictionary<(int, int), long> cache = [];

    private long QuantumSplitRec(int x, int y, HashSet<Point> splitters, int end)
    {
        if (y == end) return 1;

        if (cache.TryGetValue((x, y), out var cached))
        {
            return cached;
        }

        long result;

        if (splitters.Contains(new Point(x, y)))
        {
            result = QuantumSplitRec(x - 1, y, splitters, end) + QuantumSplitRec(x + 1, y, splitters, end);
        }
        else
        { 
            result = QuantumSplitRec(x, y + 1, splitters, end);
        }

        cache[(x, y)] = result;

        return result;
    }
}
