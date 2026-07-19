namespace HW4_3_Figures;

public abstract class Figure
{
    public string Name { get; set; }

    public Figure(string name)
    {
        Name = name;
    }

    public abstract double GetArea();
    public abstract double GetPerimeter();
}