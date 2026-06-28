namespace HW4_4_Class_structure;

public abstract class Product
{
    public string Name { get; }
    public decimal Price { get; }

        protected Product(string name, decimal price)
        {
            Name = name;
            Price = price;
        }

    public abstract void PrintInfo();

    public abstract bool IsExpired(DateTime currentDate);

    public abstract DateTime GetExpirationDate();
}