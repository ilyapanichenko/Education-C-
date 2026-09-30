using Allure.Net.Commons;
using Allure.NUnit.Attributes;
using HW9_1.Core.Pages;

namespace HW9_1.Tests;

[AllureEpic("SauceDemo")]
[AllureFeature("Authentication")]
[AllureSuite("Login")]
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
    [AllureDescription("Successful login with valid credentials")]
    public void SuccessfulLoginTest()
    {
        var productsPage = AllureApi.Step("Login as standard user", () =>
            _loginPage
                .EnterUsername()
                .EnterPassword()
                .Login());

        AllureApi.Step("Verify Products page is opened", () =>
            Assert.That(productsPage.GetTitle(), Is.EqualTo("Products")));
    }

    [Test]
    [AllureDescription("Login attempt with incorrect password")]
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