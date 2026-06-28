namespace HW4_2_Class_CrediCard;

class Program
{
    static void Main()
    {
        var creditCardNumber1 = 555;
        var creditCardNumber2 = 666;
        var creditCardNumber3 = 777;
        var creditCardStartAmount1 = 0;
        var creditCardStartAmount2 = 300;
        var creditCardStartAmount3 = 500;
        CreditCard creditCard1 = new CreditCard(creditCardNumber1, creditCardStartAmount1);
        CreditCard creditCard2 = new CreditCard(creditCardNumber2, creditCardStartAmount2);
        CreditCard creditCard3 = new CreditCard(creditCardNumber3, creditCardStartAmount3);
        Console.WriteLine("Начальное состояние карт:");
        Console.WriteLine(creditCard1.GetCardinfo());
        Console.WriteLine(creditCard2.GetCardinfo());
        Console.WriteLine(creditCard3.GetCardinfo());

        Console.WriteLine();

        decimal transactionCard1 = ReadKeyboard("Введите сумму, которую хотите положить на первую карту: ");
        creditCard1.AddingMoney(transactionCard1);

        decimal transactionCard2 = ReadKeyboard("Введите сумму, которую хотите положить на вторую карту: ");
        creditCard2.AddingMoney(transactionCard2);

        decimal transactionCard3 = ReadKeyboard("Введите сумму, которую хотите снять с третьей карты: ");
        creditCard3.WithdrawMoney(transactionCard3);

        Console.WriteLine();
        Console.WriteLine("Текущее состояние карточек:");

        Console.WriteLine(creditCard1.GetCardinfo());
        Console.WriteLine(creditCard2.GetCardinfo());
        Console.WriteLine(creditCard3.GetCardinfo());
    }

    static decimal ReadKeyboard(string message)
    {
        decimal number;

        while (true)
        {
            Console.Write(message);

            string input = Console.ReadLine();

            if (decimal.TryParse(input, out number) && number >= 0)
            {
                return number;
            }

            Console.WriteLine("Ошибка: введите корректное положительное число.");
        }
    }
}