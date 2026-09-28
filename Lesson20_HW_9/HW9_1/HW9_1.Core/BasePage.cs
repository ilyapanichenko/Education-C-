using HW9_1.Core.Configuration;
using HW9_1.Core.Factories;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace HW9_1.Core;

public abstract class BasePage
{
    protected TestSettings Settings = null!;
    protected readonly IWebDriver Driver;
    protected readonly ElementFactory ElementFactory;

    protected BasePage(IWebDriver driver, TestSettings settings)
    {
        Driver = driver;
        Settings = settings;
        ElementFactory = new ElementFactory(driver);
    }

    #region Methods
    
    protected void WaitUntilUrlContains(string text)
    {
        CreateWait().Until(driver => driver.Url.Contains(text));
    }

    private WebDriverWait CreateWait()
    {
        return new WebDriverWait(Driver, TimeSpan.FromSeconds(Settings.TimeoutSeconds));
    }

    public abstract bool IsLoaded();
    public abstract BasePage Load();
    
    #endregion
}
