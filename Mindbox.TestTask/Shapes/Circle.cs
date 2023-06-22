namespace Mindbox.TestTask.Shapes;

/// <summary>
/// Класс-модель круга/окружности
/// </summary>
public class Circle: Shape
{
    /// <summary>
    /// Радиус окружности
    /// </summary>
    public double Radius { get; }
    
    /// <inheritdoc />
    public override double Area { get; }
    
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="radius">Радиус круга/окружности</param>
    public Circle(double radius)
    {
        ValidateRadius(radius);
        
        Radius = radius;
        Area = CalculateShapeArea();
    }

    /// <inheritdoc />
    protected override double CalculateShapeArea()
    {
        var result = Math.PI * Math.Pow(Radius, 2);
        return result;
    }

    /// <summary>
    /// Проверка радиуса
    /// </summary>
    private void ValidateRadius(double radius)
    {        
        if (radius <= 0)
        {
            throw new ArgumentException("Радиус круга не может быть меньше или равен нулю.", nameof(radius));
        }
    }
}