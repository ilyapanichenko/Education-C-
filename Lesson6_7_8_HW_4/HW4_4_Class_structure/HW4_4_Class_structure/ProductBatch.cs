namespace HW4_4_Class_structure;

public class ProductBatch : Product
{
    public int Quantity { get; }
    public DateTime ProductionDate { get; }
    public int ShelfLifeDays { get; }

    public ProductBatch(
        string name,
        decimal price,
        int quantity,
        DateTime productionDate,
        int shelfLifeDays) : base(name, price)
    {
        Quantity = quantity;
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
        Console.WriteLine($"Партия: {Name}");
        Console.WriteLine($"Цена за штуку: {Price} р.");
        Console.WriteLine($"Количество: {Quantity} шт.");
        Console.WriteLine($"Общая стоимость партии: {Price * Quantity} р.");
        Console.WriteLine($"Дата производства: {ProductionDate:dd.MM.yyyy}");
        Console.WriteLine($"Срок годности: {ShelfLifeDays} дней");
        Console.WriteLine($"Годен до: {GetExpirationDate():dd.MM.yyyy}");
        Console.WriteLine($"Статус: {(IsExpired(DateTime.Today) ? "Просрочена" : "Годна")}");
    }
}