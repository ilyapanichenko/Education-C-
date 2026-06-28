namespace HW4_1_Class_Phone;

class Phone
{
    private string Number { get; set; }
    private string Model { get; set; }

    private double _weight;

    private double Weight
    {
        get
        {
            return _weight;
        }
        set
        {
            if (value >= 0)
            {
                _weight = value;
            }
        }
    }

    public Phone()
    {
    }

    public Phone(string number, string model)
    {
        Number = number;
        Model = model;
    }

    public Phone(string number, string model, double weight) : this(number, model)
    {
        Weight = weight;
    }

    public void ReceiveCall(string name)
    {
        Console.WriteLine($"Звонит {name}");
    }

    public void ReceiveCall(string name, string callerNumber)
    {
        Console.WriteLine($"Звонит {name}, номер: {callerNumber}");
    }

    public string GetNumber()
    {
        return Number;
    }

    public void SendMessage(params string[] phoneNumbers)
    {
        Console.WriteLine("Сообщение будет отправлено на номера:");

        foreach (string phoneNumber in phoneNumbers)
        {
            Console.WriteLine(phoneNumber);
        }
    }

    public void PrintInfo()
    {
        Console.WriteLine($"Номер: {Number}, модель: {Model}, вес: {Weight}");
    }
}