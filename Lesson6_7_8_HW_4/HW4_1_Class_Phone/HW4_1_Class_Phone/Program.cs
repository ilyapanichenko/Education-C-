namespace HW4_1_Class_Phone;

class Program
{
    static void Main()
    {
        Phone phone1 = new Phone("+7 999 111-22-33", "iPhone 15", 171);
        Phone phone2 = new Phone("+7 999 444-55-66", "Samsung S24", 168);
        Phone phone3 = new Phone("+7 999 777-88-99", "Xiaomi 14", 193);

        phone1.PrintInfo();
        phone2.PrintInfo();
        phone3.PrintInfo();

        phone1.ReceiveCall("Мама");
        phone2.ReceiveCall("Илья");
        phone3.ReceiveCall("Курьер");

        Console.WriteLine(phone1.GetNumber());
        Console.WriteLine(phone2.GetNumber());
        Console.WriteLine(phone3.GetNumber());

        phone1.ReceiveCall("Мама", "+7 900 000-00-00");

        phone1.SendMessage(
            "+7 156 131-13-11",
            "+7 54 224-22-22",
            "+7 43 344-13-23"
        );
    }

}