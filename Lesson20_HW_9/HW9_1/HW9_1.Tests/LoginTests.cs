using HW9_1.Core.Pages;
namespace HW9_1.Tests;

public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public void OpenLoginPage()
    {
        _loginPage = new LoginPage(Driver);
        _loginPage.Open();
    }

    [Test]
    public void SuccessfulLoginTest()
    {
        var productsPage = _loginPage.Login();

        Assert.That(productsPage.GetTitle(), Is.EqualTo("Products"));
    }

    [Test]
    public void LoginWithWrongPasswordTest()
    {
        var errorText = "Epic sadface: Username and password do not match any user in this service";

        _loginPage.LoginExpectingError("standard_user", "12345678");

        Assert.That(_loginPage.GetErrorMessage(), Is.EqualTo(errorText));
    }
}