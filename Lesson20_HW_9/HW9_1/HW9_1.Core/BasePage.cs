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
    
    protected void WaitUntilUrlContains(string text)
    {
        CreateWait().Until(driver => driver.Url.Contains(text));
    }

    private WebDriverWait CreateWait()
    {
        return new WebDriverWait(Driver, DefaultTimeout);
    }

    #endregion
}