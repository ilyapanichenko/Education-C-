namespace HW4_4_Class_structure;

public class SingleProduct : Product
{
    public DateTime ProductionDate { get; }
    public int ShelfLifeDays { get; }

    public SingleProduct(
        string name,
        decimal price,
        DateTime productionDate,
        int shelfLifeDays) : base(name, price)
    {
        ProductionDate = productionDate;
        ShelfLifeDays = shelfLifeDays;
    }

    public override DateTime GetExpirationDate()
    {
        return ProductionDate.AddDays(ShelfLifeDays);
    }

    public override bool IsExpired(DateTime currentDate)
    {
        return currentDate.Date > GetExpirationDate().Date;
    }

    public override void PrintInfo()
    {
        Console.WriteLine($"Продукт: {Name}");
        Console.WriteLine($"Цена: {Price} р.");
        Console.WriteLine($"Дата производства: {ProductionDate:dd.MM.yyyy}");
        Console.WriteLine($"Срок годности: {ShelfLifeDays} дней");
        Console.WriteLine($"Годен до: {GetExpirationDate():dd.MM.yyyy}");
        Console.WriteLine($"Статус: {(IsExpired(DateTime.Today) ? "Просрочен" : "Годен")}");
    }
}