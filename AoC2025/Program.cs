int? day = null;
day ??= DateTime.Now.Month == 12 ? DateTime.Now.Day : 0;

var type = Type.GetType($"AoC2025.Days.Day{day:00}")!;
var instance = (AoC2025.Days.Day)Activator.CreateInstance(type)!;
instance.Run();
