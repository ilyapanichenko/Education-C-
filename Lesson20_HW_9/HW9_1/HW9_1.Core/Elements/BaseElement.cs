using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW9_1.Core.Elements;

public abstract class BaseElement
{
    protected readonly IWebDriver Driver;
    protected readonly By Locator;
    private static readonly TimeSpan DefaultTimeout = TimeSpan.FromSeconds(10);

    protected BaseElement(IWebDriver driver, By locator)
    {
        Driver = driver;
        Locator = locator;
    }

    public bool IsElementPresent()
    {
        return Driver.FindElements(Locator).Count > 0;
    }

    protected IWebElement WaitUntilElementVisible()
    {
        return CreateWait().Until(driver =>
        {
            var element = driver.FindElement(Locator);
            return element.Displayed ? element : null;
        })!;
    }

    protected IWebElement WaitUntilElementClickable()
    {
        return CreateWait().Until(driver =>
        {
            var element = driver.FindElement(Locator);
            return element.Displayed && element.Enabled ? element : null;
        })!;
    }

    public void WaitUntilElementAbsent()
    {
        CreateWait().Until(driver => driver.FindElements(Locator).Count == 0);
    }

    private WebDriverWait CreateWait()
    {
        var wait = new WebDriverWait(Driver, DefaultTimeout);
        wait.IgnoreExceptionTypes(typeof(StaleElementReferenceException));
        return wait;
    }
}