namespace HW4_3_Figures;

public class Rectangle : Figure
{
    public double Length { get; set; }
    public double Width { get; set; }

    public Rectangle(double length, double width) : base("Прямоугольник")
    {
        Length = length;
        Width = width;
    }

    public override double GetArea()
    {
        return Length * Width;
    }

    public override double GetPerimeter()
    {
        return 2 * (Length + Width);
    }
}