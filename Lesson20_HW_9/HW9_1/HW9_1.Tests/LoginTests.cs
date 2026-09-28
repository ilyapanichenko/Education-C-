using HW9_1.Core.Pages;
namespace HW9_1.Tests;

public class LoginTests : BaseTest
{
    private LoginPage _loginPage = null!;

    [SetUp]
    public void OpenLoginPage()
    {
        _loginPage = new LoginPage(Driver, Settings);
        _loginPage.Load();
    }

    [Test]
    public void SuccessfulLoginTest()
    {
        var productsPage = _loginPage
            .EnterUsername()
            .EnterPassword()
            .Login();
        Assert.That(productsPage.GetTitle(), Is.EqualTo("Products"));
    }

    [Test]
    public void LoginWithWrongPasswordTest()
    {
        var errorText = "Epic sadface: Username and password do not match any user in this service";
        _loginPage
            .EnterUsername()
            .EnterPassword("12345678")
            .LoginExpectingError();
        Assert.That(_loginPage.GetErrorMessage(), Is.EqualTo(errorText));
    }
}