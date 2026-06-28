namespace HW4_2_Class_CrediCard;

public class CreditCard
{
    public int AccountNumber { get; set; }
    public decimal CurrentAmount { get; set; }

    public CreditCard(int accountNumber, decimal currentAmount)
    {
        AccountNumber = accountNumber;
        CurrentAmount = currentAmount;
    }

    public void AddingMoney(decimal moneyToAdd)
    {
        if (moneyToAdd < 0)
        {
            Console.WriteLine("Нельзя добавить сумму меньше 0");
        }
        else
        {
            CurrentAmount += moneyToAdd;
        }
    }

    public void WithdrawMoney(decimal moneyToWithdraw)
    {
        if (moneyToWithdraw < 0)
        {
            Console.WriteLine("Нельзя снять сумму меньше 0");
        }
        else if (moneyToWithdraw <= CurrentAmount)
        {
            CurrentAmount -= moneyToWithdraw;
        }
        else
        {
            Console.WriteLine($"На карте {AccountNumber} недостаточно средств.");
        }
    }

    public string GetCardinfo()
    {
        return $"Информация о карте {AccountNumber}: Текущий счет - {CurrentAmount}р.";
    }
}