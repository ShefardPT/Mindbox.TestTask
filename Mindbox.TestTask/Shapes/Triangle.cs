namespace Mindbox.TestTask.Shapes;

/// <summary>
/// Класс-модель треугольника
/// </summary>
public class Triangle : Shape
{
    /// <summary>
    /// Сторона A треугольника
    /// </summary>
    public double SideA { get; set; }

    /// <summary>
    /// Сторона B треугольника
    /// </summary>
    public double SideB { get; set; }

    /// <summary>
    /// Сторона C треугольника
    /// </summary>
    public double SideC { get; set; }

    /// <inheritdoc />
    public override double Area { get; }

    /// <summary>
    /// Конструктор по трём сторонам треугольника
    /// </summary>
    /// <param name="a">Сторона A треугольника</param>
    /// <param name="b">Сторона B треугольника</param>
    /// <param name="c">Сторона C треугольника</param>
    public Triangle(double a, double b, double c)
    {
        ValidateSides(a, b, c);
        ValidateTriangleConditionBySides(a, b, c);

        SideA = a;
        SideB = b;
        SideC = c;

        Area = CalculateShapeArea();
    }

    /// <inheritdoc />
    protected override double CalculateShapeArea()
    {
        var halfMeter = (SideA + SideB + SideC) / 2;
        var result = Math.Sqrt(halfMeter * (halfMeter - SideA) * (halfMeter - SideB) * (halfMeter - SideC));
        return result;
    }
    
    /// <summary>
    /// Проверка сторон треугольника
    /// </summary>
    private void ValidateSides(double a, double b, double c)
    {
        if (a <= 0 ||
            b <= 0 ||
            c <= 0)
        {
            throw new ArgumentException("Сторона треугольника не может быть меньше или равна нулю.");
        }
    }

    /// <summary>
    /// Проверка условия существования треугольника
    /// </summary>
    private void ValidateTriangleConditionBySides(double a, double b, double c)
    {
        if (a + b <= c ||
            b + c <= a ||
            c + a <= b)
        {
            throw new ArgumentException("Нарушено условие существования треугольника.");
        }
    }
}