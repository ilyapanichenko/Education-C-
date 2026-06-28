namespace HW4_3_Figures;

public class Triangle : Figure
{
    public double Side1 { get; set; }
    public double Side2 { get; set; }
    public double Side3 { get; set; }

    public Triangle(double side1, double side2, double side3) : base("Треугольник")
    {
        Side1 = side1;
        Side2 = side2;
        Side3 = side3;
    }

    public override double GetArea()
    {
        double halfPerimeter = GetPerimeter() / 2;

        return Math.Sqrt(
            halfPerimeter *
            (halfPerimeter - Side1) *
            (halfPerimeter - Side2) *
            (halfPerimeter - Side3)
        );
    }

    public override double GetPerimeter()
    {
        return Side1 + Side2 + Side3;
    }
}