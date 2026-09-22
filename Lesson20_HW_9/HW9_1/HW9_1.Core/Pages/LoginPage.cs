using HW9_1.Core.Elements;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW9_1.Core.Pages;

public class LoginPage(IWebDriver driver) : BasePage(driver)
{
    #region Elements

    private readonly TextBox _userName = new TextBox(driver,By.Id("user-name"));
    private readonly TextBox _password = new TextBox(driver,By.Id("password"));
    private readonly Button _loginButton = new Button(driver,By.Id("login-button"));
    private readonly Label _errorMessage = new Label(driver, By.CssSelector("[data-test='error']"));

    #endregion

    #region Methods

    public void Open()
    {
        Driver.Navigate().GoToUrl("https://www.saucedemo.com/");
    }

    public LoginPage EnterUsername(string username)
    {
        _userName.SetText(username);
        return this;
    }

    public LoginPage EnterPassword(string password)
    {
        _password.SetText(password);
        return this;
    }

    public ProductsPage Login(string username = "standard_user", string password = "secret_sauce")
    {
        EnterUsername(username).EnterPassword(password);
        _loginButton.Click();
        WaitUntilUrlContains("inventory");

        return new ProductsPage(Driver);
    }

    public LoginPage LoginExpectingError(string username, string password)
    {
        EnterUsername(username).EnterPassword(password);
        _loginButton.Click();
        return this;
    }

    public string GetErrorMessage() => _errorMessage.GetText();

    #endregion
}