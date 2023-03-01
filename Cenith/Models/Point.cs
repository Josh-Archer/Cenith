namespace Cenith.Models;

public class Point
{
    public PointType Type { get; init; }
    public Dictionary<Point, int> Neighbors { get; set; } = new();
    public string Name { get; set; }

    public int Health => Type switch
    {
        PointType.Blank => 0,
        PointType.Lava => -50,
        PointType.Speeder => -5,
        PointType.Mud => -10,
    };
    
    public int Moves => Type switch
    {
        PointType.Blank => -1,
        PointType.Lava => -10,
        PointType.Speeder => 0,
        PointType.Mud => -5,
    };
}

public enum PointType
{
    Blank,
    Speeder,
    Lava,
    Mud,
}