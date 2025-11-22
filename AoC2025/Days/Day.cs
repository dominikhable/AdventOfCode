using System.Diagnostics;

namespace AoC2025.Days;

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

    public abstract object Task1();
    public abstract object Task2();
}
