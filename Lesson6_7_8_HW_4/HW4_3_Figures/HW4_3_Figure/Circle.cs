namespace HW4_3_Figures;

public class Circle : Figure
{
    public double Radius { get; set; }

    public Circle(double radius) : base("Круг")
    {
        Radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * Radius * Radius;
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * Radius;
    }
}