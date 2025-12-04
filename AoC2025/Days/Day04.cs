using System.Drawing;

namespace AoC2025.Days;

public class Day04 : Day
{
    public override object Task1() => GetRemovables(GetInputPoints('@')).Count;

    public override object Task2()
    {
        var rolls = GetInputPoints('@');
        var initRollCount = rolls.Count;

        while (true)
        {
            var removables = GetRemovables(rolls);

            if (removables.Count is 0) break;

            rolls.ExceptWith(removables);
        }

        return initRollCount - rolls.Count;
    }

    private static List<Point> GetRemovables(HashSet<Point> rolls)
    {
        return [.. rolls.Where(r => CountNeighbors(r, rolls) < 4)];
    }

    private static int CountNeighbors(Point p, HashSet<Point> grid)
    {
        return Util.AdjacentNeighbors.Count(o => grid.Contains(new Point(p.X + o.dx, p.Y + o.dy)));
    }
}
