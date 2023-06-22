namespace Mindbox.TestTask.Shapes;

/// <summary>
/// Класс-модель треугольника
/// </summary>
public class Triangle : Shape, IEquilateral, IRectangular
{
    /// <summary>
    /// Сторона A треугольника
    /// </summary>
    public double SideA { get; }

    /// <summary>
    /// Сторона B треугольника
    /// </summary>
    public double SideB { get; }

    /// <summary>
    /// Сторона C треугольника
    /// </summary>
    public double SideC { get; }

    /// <inheritdoc />
    public override double Area { get; }

    /// <inheritdoc />
    public bool IsEquilateral { get; }

    /// <inheritdoc />
    public bool IsRectangular { get; }

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
        IsEquilateral = CheckIsEquilateral();
        IsRectangular = CheckIsRectangular();
    }

    /// <inheritdoc />
    protected override double CalculateShapeArea()
    {
        var halfMeter = (SideA + SideB + SideC) / 2;
        var result = Math.Sqrt(halfMeter * (halfMeter - SideA) * (halfMeter - SideB) * (halfMeter - SideC));
        return result;
    }

    /// <summary>
    /// Проверка на равносторонность
    /// </summary>
    private bool CheckIsEquilateral()
    {
        var result = SideA.Equals(SideB) && SideB.Equals(SideC);
        return result;
    }

    /// <summary>
    /// Проверка на прямоугольность
    /// </summary>
    private bool CheckIsRectangular()
    {
        // возможно было бы лучше расчитывать каждый из углов треугольника
        // но согласно постановке задачи это не требуется
        // можно реализовать позже
        
        const double tolerance = .0001;
        var sides = new[] { SideA, SideB, SideC }.OrderDescending().ToArray();
        var supposedHypotenuse = sides[0];
        var cathet1 = sides[1];
        var cathet2 = sides[2];
        var hypotByCathets = double.Hypot(cathet1, cathet2);

        var result = Math.Abs(supposedHypotenuse - hypotByCathets) < tolerance;
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