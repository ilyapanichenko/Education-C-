using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW9_1.Tests;

public class BaseTest
{
    protected IWebDriver Driver = null!;

    [SetUp]
    public void SetUp()
    {
        Driver = new ChromeDriver();
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}