namespace Mindbox.TestTask.Shapes;

/// <summary>
/// Класс-модель геометрической фигуры
/// </summary>
public abstract class Shape
{
    /// <summary>
    /// Площадь фигуры
    /// </summary>
    public virtual double Area => CalculateShapeArea();

    /// <summary>
    /// Вычислить площадь фигуры
    /// </summary>
    /// <returns></returns>
    protected abstract double CalculateShapeArea();
}