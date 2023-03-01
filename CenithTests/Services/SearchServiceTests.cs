namespace CenithTests.Services;

public class SearchServiceTests
{
    private readonly SearchService _service;
    
    public SearchServiceTests()
    {
        _service = new SearchService();
    }
    
    [Theory]
    [InlineData(true, false, false)]
    [InlineData(false, true, false)]
    [InlineData(false, false, true, typeof(NullReferenceException))]
    [InlineData(true, true, false)]
    [InlineData(true, false, true)]
    [InlineData(false, true, true)]
    public void Calculate_ArgumentIsNull_ThrowsException(bool isWorldNull, bool isSourceNull, bool isDestinationNull, Type? exceptionType = null)
    {
        var source = new Point {Type = PointType.Blank };
        var destination = new Point {Type = PointType.Lava };
        var world = new[,]
        {
            {source},
            {destination},
        };

        if (isWorldNull)
        {
            world = null;
        }

        if (isSourceNull)
        {
            source = null;
        }

        if (isDestinationNull)
        {
            destination = null;
        }

        Assert.Throws(exceptionType ?? typeof(ArgumentNullException),() => _service.Calculate(world, source, destination));
    }

    [Theory]
    [InlineData(3, "blank", "speeder", "lava", "lava", "speeder", "lava", "mud", "blank", "lava")]
    public void Calculate_Finds_OptimalPath(int xy, params string[] pointTypes)
    {
        var testWorld = WorldFactory.BuildWorld(xy, xy, pointTypes);
        
        var route = _service.Calculate(testWorld, testWorld[0, 0], testWorld[2,0]);
        
        Assert.True(route.Count is 5);
        Assert.Equal("0:0:Blank", route.Pop().Name);
        Assert.Equal("0:1:Speeder", route.Pop().Name);
        Assert.Equal("1:1:Speeder", route.Pop().Name);
        Assert.Equal("2:1:Blank", route.Pop().Name);
        Assert.Equal("2:0:Mud", route.Pop().Name);
    }
}