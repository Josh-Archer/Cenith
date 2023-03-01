namespace Cenith;

public static class Extensions
{
    public static void PrintLegs(this Stack<Point> route)
    {
        while (route.TryPop(out var point))
        {
            Console.WriteLine($"{point.Name}");
        }
        Console.ReadKey();
    } 
}