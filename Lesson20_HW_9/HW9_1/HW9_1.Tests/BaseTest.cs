using HW9_1.Core.Configuration;
using HW9_1.Core.Factories;
using OpenQA.Selenium;

namespace HW9_1.Tests;

public class BaseTest
{
    protected IWebDriver Driver = null!;
    protected TestSettings Settings = null!;
    [SetUp]
    public void SetUp()
    {
        Settings = ConfigurationProvider.GetSettings();
        Driver = DriverFactory.CreateDriver(Settings);
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}