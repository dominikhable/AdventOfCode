namespace AoC2025;

public class Util
{
    /// <summary>
    /// Represents the 8 adjacent neighbors (Moore neighborhood).
    /// </summary>
    public static readonly (int dx, int dy)[] AdjacentNeighbors =
        [(-1, -1), (0, -1), (1, -1), 
         (-1,  0),          (1,  0), 
         (-1,  1), (0,  1), (1,  1)];
}
