namespace HW9_1.Tests.TestData;

public class CheckoutDataBuilder
{
    private string _firstName = "Ilia";
    private string _lastName = "Panichenko";
    private string _postalCode = "12345678";

    public CheckoutDataBuilder WithFirstName(string firstName)
    {
        _firstName = firstName;
        return this;
    }

    public CheckoutDataBuilder WithLastName(string lastName)
    {
        _lastName =  lastName;
        return this;
    }

    public CheckoutDataBuilder WithPostalCode(string postalCode)
    {
        _postalCode =  postalCode;
        return this;
    }
    public CheckoutData Build()
    {
        return new CheckoutData
        {
            FirstName = _firstName,
            LastName = _lastName,
            PostalCode = _postalCode
        };
    }
}