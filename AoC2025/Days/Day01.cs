namespace AoC2025.Days;

public class Day01 : Day
{
    public override object Task1()
    {
        var result = 0;
        var current = 50;
        var input = GetInputLines().Select(LRtoMinusPlus).Select(int.Parse);

        foreach(var val in input)
        {
            current = (current + val + 100) % 100;
            if (current is 0) result++;
        }

        return result;
    }

    public override object Task2()
    {
        var result = 0;
        var current = 50;
        var input = GetInputLines().Select(LRtoMinusPlus).Select(int.Parse);

        foreach (var val in input)
        {
            var turns = Math.Abs(val) / 100;
            var ticks = Math.Abs(val) % 100;
            var dir = val > 0 ? 1 : -1;

            for (int i = 0; i < ticks; i++)
            {
                current += dir;
                if (current is 0 or 100) result++;
            }

            current = (current + 100) % 100;
            result += turns;
        }

        return result;
    }

    private static string LRtoMinusPlus(string x) => x.Replace('L', '-').Replace('R', '+');
}
