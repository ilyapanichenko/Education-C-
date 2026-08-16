namespace HW6_1_Sort;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string City { get; set; }
    public DateTime RegistrationDate { get; set; }

    public Customer(int id, string name, string city, DateTime registrationDate)
    {
        Id = id;
        Name = name;
        City = city;
        RegistrationDate = registrationDate;
    }
}