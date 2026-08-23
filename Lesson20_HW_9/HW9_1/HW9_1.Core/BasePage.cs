using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW9_1.Core;

public class BasePage
{
    protected readonly IWebDriver Driver;

    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }

    #region Methods

    protected void Click(By locator)
    {
        WaitUntilElementClickable(locator).Click();
    }

    protected void Type(By locator, string text)
    {
        WaitUntilElementClickable(locator).SendKeys(text);
    }

    protected string GetText(By locator)
    {
        return WaitUntilElementVisible(locator).Text;
    }

    protected bool IsElementPresent(By locator)
    {
        return Driver.FindElements(locator).Count > 0;
    }

    protected void WaitUntilUrlContains(string text)
    {
        CreateWait().Until(driver => driver.Url.Contains(text));
    }

    protected IWebElement WaitUntilElementVisible(By locator)
    {
        return CreateWait().Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed ? element : null;
        })!;
    }

    protected IWebElement WaitUntilElementClickable(By locator)
    {
        return CreateWait().Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed && element.Enabled ? element : null;
        })!;
    }

    protected void WaitUntilElementAbsent(By locator)
    {
        CreateWait().Until(driver => driver.FindElements(locator).Count == 0);
    }

    private WebDriverWait CreateWait()
    {
        return new WebDriverWait(Driver, DefaultTimeout);
    }

    #endregion
}