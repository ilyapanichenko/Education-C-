using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase_IoTests.Core.Configuration;

namespace Qase_IoTests.Core.Pages;

public class LoginPage : BasePage
{
    private readonly By _emailField = By.CssSelector("input[name='email']");
    private readonly By _passwordField = By.CssSelector("input[name='password']");
    private readonly By _loginButton = By.CssSelector("button[type='submit']");
    private readonly By _acceptCookiesButton = By.CssSelector("button[data-action='consent'][data-action-type='accept']");
    private readonly By _cookiesHost = By.Id("usercentrics-cmp-ui");
    private readonly By _loginError = By.XPath("//span[normalize-space()='These credentials do not match our records.']");
    public LoginPage(IWebDriver driver) : base(driver)
    {
    }
    public bool IsEmailFieldVisible()
    {
        return WaitForVisible(_emailField).Displayed;
    }

    public bool IsPasswordFieldVisible()
    {
        return WaitForVisible(_passwordField).Displayed;
    }

    public void Open()
    {
        Driver.Navigate().GoToUrl("https://app.qase.io/login");
    }

    public void EnterEmail(string email)
    {
        var field =  WaitForVisible(_emailField);
        field.Clear();
        field.SendKeys(email);
    }

    public void EnterPassword(string password)
    {
        var field = WaitForVisible(_passwordField);
        field.Clear();
        field.SendKeys(password);
    }
    
    public void ClickLogin()
    {
        WaitForVisible(_loginButton).Click();
    }
    
    public bool AcceptCookiesIfPresent()
    {
        var wait = new WebDriverWait(Driver, TestSettings.WindowsTimeout);
        try
        {
            return wait.Until(driver =>
            {
                var host = driver.FindElements(_cookiesHost).FirstOrDefault();
                if (host == null) 
                    return false;
                var shadowRoot = host.GetShadowRoot();
                var button = shadowRoot.FindElements(_acceptCookiesButton).FirstOrDefault();
                if (button == null || !button.Displayed || !button.Enabled)
                    return false;
                button.Click();
                return true;
            });
        }
        catch (WebDriverTimeoutException)
        {
            return false;
        }
    }
    
    public string GetLoginErrorMessage()
    {
        return WaitForVisible(_loginError).Text;
    }
}