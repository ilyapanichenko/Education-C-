using HW9_1.Core.Configuration;
using HW9_1.Core.Elements;
using OpenQA.Selenium;

namespace HW9_1.Core.Pages;

public class LoginPage : BasePage
{
    private readonly TextBox _userName;
    private readonly TextBox _password;
    private readonly Button _loginButton;
    private readonly Label _errorMessage;
    #region Elements

    public LoginPage(IWebDriver driver, TestSettings settings) : base(driver,settings)
    {
        _userName = ElementFactory.Create<TextBox>(By.Id("user-name"));
        _password = ElementFactory.Create<TextBox>(By.Id("password"));
        _loginButton = ElementFactory.Create<Button>(By.Id("login-button"));
        _errorMessage = ElementFactory.Create<Label>(By.CssSelector("[data-test='error']"));
    }
    #endregion

    #region Methods
    public override bool IsLoaded()
    {
        return _loginButton.IsElementPresent();
    }
    public override LoginPage Load()
    {
        Driver.Navigate().GoToUrl(Settings.BaseUrl);
        return this;
    }

    public LoginPage EnterUsername(string username = "standard_user")
    {
        _userName.SetText(username);
        return this;
    }

    public LoginPage EnterPassword(string password = "secret_sauce")
    {
        _password.SetText(password);
        return this;
    }

    public ProductsPage Login()
    {
        _loginButton.Click();
        WaitUntilUrlContains("inventory");
        return new ProductsPage(Driver, Settings);
    }

    public LoginPage LoginExpectingError()
    {
        _loginButton.Click();
        return this;
    }

    public string GetErrorMessage() => _errorMessage.GetText();

    #endregion

}