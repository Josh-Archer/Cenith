namespace Cenith.Services;

// Rename this to factory?
public class WorldFactory
{
    public static Point[,] BuildWorld(int x, int y, IEnumerable<string> worldInput)
    {
        if (x != y || x is 0)
        {
            throw new Exception("2D array expected");
        }
        
        var world = InitializeWorld(x, y, worldInput);
        
        for (var xIndex = 0; xIndex < world.GetLength(0); xIndex++)
        {
            for (var yIndex = 0; yIndex < world.GetLength(1); yIndex++)
            {
                AddNeighbors(world, xIndex, yIndex);
            }
        }

        return world;
    }

    private static Point[,] InitializeWorld(int x, int y, IEnumerable<string> worldInput)
    {
        var world = new Point[x,y];
        var enumerable = worldInput.ToArray();
        for (var i = 0; i < enumerable.Length; i++)
        {
            if (!Enum.TryParse(enumerable[i], true, out PointType pointType))
            {
                throw new Exception("Invalid input");
            }

            var xDimension = i / x;
            var yDimension = i % y;
    
            world[xDimension, yDimension] = new Point { Type = pointType, Name = $"{xDimension}:{yDimension}:{pointType}"};
        }

        return world;
    }

    private static void AddNeighbors(Point[,] world, int x, int y)
    {
        var xMax = world.GetLength(0);
        var yMax = world.GetLength(1);
        var neighbors = world[x, y].Neighbors;
        
        // Double check this logic
        if (x < xMax - 1)
        {
            var neighbor = world[x + 1, y];
            neighbors.Add(neighbor, int.Abs(neighbor.Health + neighbor.Moves));
        }
        if (x is not 0)
        {
            var neighbor = world[x - 1, y];
            neighbors.Add(neighbor, int.Abs(neighbor.Health + neighbor.Moves));
        }

        if (y < yMax - 1)
        {
            var neighbor = world[x, y + 1];
            neighbors.Add(neighbor, int.Abs(neighbor.Health + neighbor.Moves));
        }
        if (y is not 0)
        {
            var neighbor = world[x, y - 1];
            neighbors.Add(neighbor, int.Abs(neighbor.Health + neighbor.Moves));
        }
    }
}