using Mindbox.TestTask.Shapes;
using Xunit;

namespace Mindbox.TestTask.Tests.ShapesTests;

public class TriangleTests
{
    [Theory]
    [InlineData(2, 3, 0)]
    [InlineData(3, -4, 5)]
    [InlineData(2, 4, 6)]
    public void Triangle_CreateTriangleInvalidSides_ShouldArgumentException(
        double sideA, double sideB, double sideC)
    {
        // Arrange
        // Act
        Action action = () => new Triangle(sideA, sideB, sideC);
        
        // Assert
        Assert.Throws<ArgumentException>(action);
    }
    
    [Theory]
    [InlineData(1, 1, 1, 0.433013)]
    [InlineData(3, 4, 5, 6)]
    public void Triangle_CreateTriangle_ShouldBeExpectedArea(
        double sideA, double sideB, double sideC,double expectedArea)
    {
        // Arrange
        const double tolerance = .0001;
        var triangle = new Triangle(sideA, sideB, sideC);
        
        // Act
        var area = triangle.Area;
        
        // Assert
        Assert.Equal(expectedArea, area, tolerance);
    }

    [Theory]
    [InlineData(3,4,5,true)]
    [InlineData(5, 8, 9.4339, true)]
    [InlineData(5, 5, 7.07107, true)]
    [InlineData(2,4,5, false)]
    [InlineData(3,3,3, false)]
    public void Triangle_CreateTriangle_ShouldBeExpectedRectangular(
        double sideA, double sideB, double sideC, bool expectedRectangular)
    {
        // Arrange
        var triangle = new Triangle(sideA, sideB, sideC);
        
        // Act
        var isRectangular = triangle.IsRectangular;

        // Assert
        Assert.Equal(expectedRectangular, isRectangular);
    }
    
    [Theory]
    [InlineData(3,3,3,true)]
    [InlineData(5, 5, 7, false)]
    [InlineData(5, 6, 7, false)]
    public void Triangle_CreateTriangle_ShouldBeExpectedEquilateral(
        double sideA, double sideB, double sideC, bool expectedEquilateral)
    {
        // Arrange
        var triangle = new Triangle(sideA, sideB, sideC);
        
        // Act
        var isEquilateral = triangle.IsEquilateral;

        // Assert
        Assert.Equal(expectedEquilateral, isEquilateral);
    }
}