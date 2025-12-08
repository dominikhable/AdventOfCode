namespace AoC2025.Days;

public class Day08 : Day
{
    public override object Task1() => CreateCircuits(1000);

    public override object Task2() => CreateCircuits();


    private int CreateCircuits(int? max = null)
    {
        var vertices = GetVertices();
        var edges = GetEdges(vertices);

        List<HashSet<int>> circuits = [];

        foreach (var edge in edges.Take(max ?? edges.Count))
        {
            int? currentCircuit = null;

            for (int i = 0; i < circuits.Count; i++)
            {
                if (circuits[i].Contains(edge.From) || circuits[i].Contains(edge.To))
                {
                    if (currentCircuit is null)
                    {
                        currentCircuit = i;
                        circuits[i].Add(edge.From);
                        circuits[i].Add(edge.To);

                    }
                    else
                    {
                        circuits[currentCircuit.Value].UnionWith(circuits[i]);
                        circuits.RemoveAt(i);
                        break;
                    }
                }
            }

            if (currentCircuit is null)
            {
                circuits.Add([edge.From, edge.To]);
                continue;
            }

            if (max is null && circuits[currentCircuit.Value].Count == vertices.Count)
            {
                return vertices[edge.From].X * vertices[edge.To].X;
            }
        }

        return circuits
            .Select(c => c.Count)
            .OrderByDescending(c => c)
            .Take(3)
            .Aggregate(1, (acc, x) => acc * x);
    }

    private static List<Edge> GetEdges(List<Vertex> vertices)
    {
        return [.. Enumerable.Range(0, vertices.Count)
            .SelectMany(i => Enumerable.Range(i + 1, vertices.Count - (i + 1))
                .Select(j =>
                {
                    var a = vertices[i];
                    var b = vertices[j];
                    double dx = a.X - b.X;
                    double dy = a.Y - b.Y;
                    double dz = a.Z - b.Z;
                    double length = Math.Sqrt(dx * dx + dy * dy + dz * dz);
                    return new Edge(i, j, length);
                }))
            .OrderBy(e => e.Length)];
    }

    private List<Vertex> GetVertices()
    {
        return [.. GetInputLines()
            .Select(line => line.Split(','))
            .Select(parts =>
                new Vertex(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2])))];
    }

    public record Vertex(int X, int Y, int Z);
    public record Edge(int From, int To, double Length);
}
