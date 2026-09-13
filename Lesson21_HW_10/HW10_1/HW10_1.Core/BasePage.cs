using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW10_1.Core;

public class BasePage
{
    protected readonly IWebDriver Driver;

    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);
    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
    }
    protected void OpenPage(string url)
    {
        Driver.Navigate().GoToUrl(url);
    }

    protected void Click(By locator)
    {
        Driver.FindElement(locator).Click();
    }

    protected string GetText(By locator)
    {
        return Driver.FindElement(locator).Text;
    }

    protected bool IsElementPresent(By locator)
    {
        return Driver.FindElements(locator).Count > 0;
    }

    protected bool IsElementEnabled(By locator)
    {
        return Driver.FindElement(locator).Enabled;
    }
    protected void WaitUntilElementAbsent(By locator)
    {
        CreateWait().Until(driver =>
            driver.FindElements(locator).Count == 0);
    }

    protected void WaitUntilTextEquals(By locator, string expectedText)
    {
        CreateWait().Until(driver =>
        {
            var elements = driver.FindElements(locator);
            return elements.Count > 0 && elements[0].Text == expectedText;
        });
    }
    protected WebDriverWait CreateWait()
    {
        return new WebDriverWait(Driver, DefaultTimeout);
    }
    protected void SendKeys(By locator, string value)
    {
        Driver.FindElement(locator).SendKeys(value);
    }

}