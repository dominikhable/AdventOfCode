namespace AoC2025.Days;

public class Day03 : Day
{
    public override object Task1() => GetInputLines().Sum(GetLowJoltage);

    public override object Task2() => GetInputLines().Sum(GetHighJoltage);

    private int GetLowJoltage(string line)
    {
        var max = line.Max();
        var indexMax = line.IndexOf(max);

        if (indexMax == (line.Length - 1))
        {
            return int.Parse($"{line[..indexMax].Max()}{max}");
        }

        return int.Parse($"{max}{line[(indexMax + 1)..].Max()}");
    }

    private long GetHighJoltage(string line)
    {
        var stack = new Stack<char>(12);

        for (int i = 0; i < line.Length; i++)
        {
            while (stack.Count > 0 &&
                   stack.Peek() < line[i] &&
                   (line.Length - i) > (12 - stack.Count))
            {
                stack.Pop();
            }

            if (stack.Count < 12)
            {
                stack.Push(line[i]);
            }
        }

        return long.Parse(string.Concat(stack.Reverse()));
    }
}
