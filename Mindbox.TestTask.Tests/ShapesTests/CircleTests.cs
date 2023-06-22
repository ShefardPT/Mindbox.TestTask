using Mindbox.TestTask.Shapes;
using Xunit;

namespace Mindbox.TestTask.Tests.ShapesTests;

public class CircleTests
{
    [Theory]
    [InlineData(1, double.Pi)]
    [InlineData(2, 4 * double.Pi)]
    [InlineData(1.78412, 10)]
    public void Circle_CreateCircle_ShouldBeExpectedArea(double radius, double expectedArea)
    {
        // Arrange
        const double tolerance = .0001;
        
        // Act
        var circle = new Circle(radius);
        var area = circle.Area;
        
        // Assert
        Assert.Equal(expectedArea, area, tolerance);
    }
    
    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void Circle_InvalidRadius_ShouldArgumentException(double radius)
    {
        // Arrange
        // Act
        Action action = () => new Circle(radius);
        
        // Assert
        var ex = Assert.Throws<ArgumentException>(action);
    }
}