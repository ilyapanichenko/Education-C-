using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Qase_IoTests.Core.Configuration;

namespace Qase_IoTests.Core.Pages;

public abstract class BasePage
{
    protected readonly IWebDriver Driver;
    private readonly WebDriverWait _wait;

    protected BasePage(IWebDriver driver)
    {
        Driver = driver;
        _wait = new WebDriverWait(driver,TestSettings.DefaultTimeout);
    }
    protected IWebElement WaitForVisible(By locator)
    {
        return _wait.Until(driver =>
        {
            var element = driver.FindElement(locator);
            return element.Displayed ? element : null;
        });
    }
    protected bool WaitForUrlPath(string path)
    {
        return _wait.Until(driver => new Uri(driver.Url).AbsolutePath == path);
    }
}