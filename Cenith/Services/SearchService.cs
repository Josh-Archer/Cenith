namespace Cenith.Services;

public class SearchService
{

    public Stack<Point> Calculate(Point[,] world, Point source, Point destination)
    {
        var worldPoints = world.Cast<Point>().ToList();
        var distances = BuildDistances(world);
        var routes = BuildRoutes(world);
        distances[source] = 0;

        while (worldPoints.Count != 0)
        {
            var leastExpensivePoint = GetLeastExpensivePoint(worldPoints, distances);
            ProcessConnectedPoints(leastExpensivePoint, distances, routes);
            worldPoints.Remove(leastExpensivePoint);
        }
        

        return GenerateRouteStack(routes, source, destination);
    }

    private static Dictionary<Point, int> BuildDistances(Point[,] world)
    {
        var distances = new Dictionary<Point, int>();
        foreach (var point in world)
        {
            distances.Add(point, int.MaxValue);
        }

        return distances;
    }

    private static Dictionary<Point, Point?> BuildRoutes(Point[,] world)
    {
        var routes = new Dictionary<Point, Point?>();
        foreach (var point in world)
        {
            routes.Add(point, null);
        }

        return routes;
    }
    
    private static Point GetLeastExpensivePoint(List<Point> worldPoints, IReadOnlyDictionary<Point, int> distances)
    {
        var leastExpensivePoint = worldPoints.First();

        //return worldPoints.First(point => Distances[point] < Distances[leastExpensivePoint]);

        foreach (var point in worldPoints)
        {
            if (distances[point] < distances[leastExpensivePoint])
                leastExpensivePoint = point;
        }

        return leastExpensivePoint;
    }
    
    private static void ProcessConnectedPoints(Point point, Dictionary<Point, int> distances, Dictionary<Point, Point?> routes)
    {
        foreach (var neighbor in point.Neighbors)
        {
            if (distances[point] + neighbor.Value < distances[neighbor.Key])
            {
                distances[neighbor.Key] = neighbor.Value + distances[point];
                routes[neighbor.Key] = point;
            }
        }
    }

    private static Stack<Point> GenerateRouteStack(Dictionary<Point, Point?> routes, Point source, Point destination)
    {
        var stack = new Stack<Point>();
        while (routes[destination] is not null)
        {
            stack.Push(destination);
            destination = routes[destination]!;
        }

        stack.Push(source);
        
        return stack;
    }
}