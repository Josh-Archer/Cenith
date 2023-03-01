using AutoFixture;
using AutoFixture.Xunit2;

namespace CenithTests.Services;

public class WorldFactoryTests
{
    [Theory]
    [InlineData(1, 2)]
    [InlineData(0, 1)]
    [InlineData(0, 0)]
    public void BuildWorld_Not2DArray_ThrowsErrorWithMessage(int x, int y)
    {
        var exception = Assert.Throws<Exception>(() => WorldFactory.BuildWorld(x, y, new[] { "" }));
        Assert.Equal("2D array expected", exception.Message);
    }

    [Fact]
    public void BuildWorld_PointTypeWrong_ThrowsErrorWithMessage()
    {
        var exception = Assert.Throws<Exception>(() => WorldFactory.BuildWorld(1, 1, new[] { "" }));
        Assert.Equal("Invalid input", exception.Message);
    }

    [Theory]
    [InlineAutoData]
    [InlineAutoData]
    [InlineAutoData]
    public void BuildWorld_ValidData_ReturnsValidWorld(int xy)
    {
        var action = () => Enum
            .GetValues(typeof(PointType))
            .OfType<Enum>()
            .MinBy(e => Guid.NewGuid())
            !.ToString();

        var input = new List<string>();
        for (var i = 0; i < xy * xy; i++)
        {
            input.Add(action.Invoke());
        }
        
        var result = WorldFactory.BuildWorld(xy, xy, input);
        
        Assert.True(result.GetLength(0) == xy);
        Assert.True(result.GetLength(1) == xy);

        input.Reverse();
        var inputStack = new Stack<string>(input);
        for (var x = 0; x < xy; x++)
        {
            for (var y = 0; y < xy; y++)
            {
                Assert.Equal(inputStack.Pop(), result[x, y].Type.ToString());
                //check neighbors
                //check values regarding type
            }
        }
    }
}