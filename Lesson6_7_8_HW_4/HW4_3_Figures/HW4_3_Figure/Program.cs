namespace HW4_3_Figures;

class Program
{
    static void Main()
    {
        Figure[] figures = new Figure[5];

        figures[0] = new Rectangle(4, 5);
        figures[1] = new Circle(3);
        figures[2] = new Triangle(3, 4, 5);
        figures[3] = new Rectangle(10, 2);
        figures[4] = new Circle(7);

        double sumPerimeter = 0;

        foreach (Figure figure in figures)
        {
            Console.WriteLine($"Фигура: {figure.Name}");
            Console.WriteLine($"Площадь: {figure.GetArea()}");
            Console.WriteLine($"Периметр: {figure.GetPerimeter()}");
            Console.WriteLine();

            sumPerimeter += figure.GetPerimeter();
        }

        Console.WriteLine($"Сумма периметров всех фигур: {sumPerimeter}");
    }
}
