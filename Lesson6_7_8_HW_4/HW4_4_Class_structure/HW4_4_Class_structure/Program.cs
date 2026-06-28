namespace HW4_4_Class_structure;

class Program
{
    static void Main()
    {
        Product milk = new SingleProduct(
            "Молоко",
            90,
            new DateTime(2026, 6, 20),
            7
        );

        Product bread = new SingleProduct(
            "Хлеб",
            50,
            new DateTime(2026, 6, 15),
            3
        );

        Product cheeseBatch = new ProductBatch(
            "Сыр",
            250,
            10,
            new DateTime(2026, 6, 21),
            30
        );

        Product yogurtBatch = new ProductBatch(
            "Йогурт",
            70,
            20,
            new DateTime(2026, 6, 5),
            10
        );

        Product breakfastKit = new ProductKit(
            "Завтрак",
            300,
            new Product[]
            {
                milk,
                bread,
                cheeseBatch
            }
        );

        Product[] products =
        {
            milk,
            bread,
            cheeseBatch,
            yogurtBatch,
            breakfastKit
        };

        Console.WriteLine("Полная информация о товарах:");
        Console.WriteLine();

        foreach (Product product in products)
        {
            product.PrintInfo();
            Console.WriteLine();
        }

        Console.WriteLine("Просроченные товары:");
        Console.WriteLine();

        foreach (Product product in products)
        {
            if (product.IsExpired(DateTime.Today))
            {
                Console.WriteLine(product.Name);
            }
        }
    }
}