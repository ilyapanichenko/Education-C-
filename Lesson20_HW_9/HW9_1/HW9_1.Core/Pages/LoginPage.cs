using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    #region Locators

    private readonly By _userNameLocator = By.Id("user-name");
    private readonly By _passwordLocator = By.Id("password");
    private readonly By _loginButtonLocator = By.Id("login-button");
    private readonly By _errorMessageLocator = By.CssSelector("[data-test='error']");

    #endregion

    #region Methods

    public void Open()
    {
        Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    public LoginPage EnterUsername(string username)
    {
        Type(_userNameLocator, username);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        Type(_passwordLocator, password);
        return this;
    }

    public ProductsPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        EnterUsername(username).EnterPassword(password);
        Click(_loginButtonLocator);
        WaitUntilUrlContains("inventory");

        return new ProductsPage(Driver);
    }

    public LoginPage LoginExpectingError(string username, string password)
    {
        EnterUsername(username).EnterPassword(password);
        Click(_loginButtonLocator);

        return this;
    }

    public string GetErrorMessage() => GetText(_errorMessageLocator);

    #endregion
}