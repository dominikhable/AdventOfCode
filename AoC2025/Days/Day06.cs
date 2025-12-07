using System.Text;

namespace AoC2025.Days;

public class Day06 : Day
{
    public override object Task1() => GetColumns().Sum(c => Calculate(c[..^1], c[^1][0]));

    public override object Task2()
    {
        var lines = GetInputLines().Select(line => $"{line} 0").ToArray(); // hacky af :D
        var lineLength = lines[0].Length;
        var lineCount = lines.Length - 1;
        long result = 0;
        List<string> values = [];

        char op = '.';

        for (int x = -1; x < lineLength; x++)
        {
            if (x == lineLength - 1 || lines[^1][x+1] != ' ')
            {
                result += Calculate([.. values], op);

                values.Clear();

                if (x < lineLength - 1)
                {
                    op = lines[^1][x + 1];
                }

                continue;
            }

            var sb = new StringBuilder(lineCount);

            for (int y = 0; y < lineCount; y++)
            {
                sb.Append(lines[y][x]);
            }

            values.Add(sb.ToString());
        }

        return result;

    }

    private static long Calculate(string[] column, char op)
    {
        if (column.Length is 0) return 0;

        var values = column.Take(column.Length).Select(long.Parse);

        return op == '+' ? 
            values.Sum() : 
            values.Aggregate(1L, (acc, x) => acc * x);
    }

    private List<string[]> GetColumns()
    {
        var lines = GetInputLines().ToList();

        var rows = lines
            .Take(lines.Count)
            .Select(line => line
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .ToArray())
            .ToArray();

        int columnCount = rows[0].Length;

        var columns = Enumerable.Range(0, columnCount)
            .Select(c => rows.Select(r => r[c]).ToArray())
            .ToList();
        return columns;
    }
}
