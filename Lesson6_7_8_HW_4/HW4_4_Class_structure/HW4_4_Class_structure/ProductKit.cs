namespace HW4_4_Class_structure;

public class ProductKit : Product
{
    public Product[] Products { get; }

    public ProductKit(
        string name,
        decimal price,
        Product[] products) : base(name, price)
    {
        Products = products;
    }

    public override DateTime GetExpirationDate()
    {
        DateTime earliestExpirationDate = Products[0].GetExpirationDate();

        foreach (Product product in Products)
        {
            if (product.GetExpirationDate() < earliestExpirationDate)
            {
                earliestExpirationDate = product.GetExpirationDate();
            }
        }

        return earliestExpirationDate;
    }

    public override bool IsExpired(DateTime currentDate)
    {
        return currentDate.Date > GetExpirationDate().Date;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Комплект: {Name}");
        Console.WriteLine($"Цена комплекта: {Price} р.");
        Console.WriteLine($"Годен до: {GetExpirationDate():dd.MM.yyyy}");
        Console.WriteLine($"Статус: {(IsExpired(DateTime.Today) ? "Просрочен" : "Годен")}");
        Console.WriteLine("Состав комплекта:");

        foreach (Product product in Products)
        {
            Console.WriteLine($"- {product.Name}, годен до: {product.GetExpirationDate():dd.MM.yyyy}");
        }
    }
}