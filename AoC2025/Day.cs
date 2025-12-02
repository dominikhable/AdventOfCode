using System.Diagnostics;

namespace AoC2025;

public abstract class Day
{
    public void Run()
    {
        var dayName = GetType().Name;
        Console.WriteLine($"Running {dayName} 2025\n");

        RunSolve(nameof(Task1), Task1);
        RunSolve(nameof(Task2), Task2);
    }

    private static void RunSolve(string name, Func<object> solve)
    {
        var sw = Stopwatch.StartNew();
        var result = solve();
        sw.Stop();

        Console.WriteLine($"Solved {name} in {sw.ElapsedMilliseconds,4} ms. Result:\t{result}");
    }

    private string GetInputFilePath()
    {
        var fileName = $"{GetType().Name}.txt";
        var filePath = Path.Combine(AppContext.BaseDirectory, "Inputs", fileName);

        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException($"Input file not found. Expected at: {filePath}");
        }

        return filePath;
    }

    protected IEnumerable<string> GetInputLines()
    {
        return File.ReadAllLines(GetInputFilePath());
    }

    protected IEnumerable<string> GetInputSeparatedBy(char separator)
    {
        var content = File.ReadAllText(GetInputFilePath());
        return content.Split(separator, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    }

    public abstract object Task1();
    public abstract object Task2();
}
