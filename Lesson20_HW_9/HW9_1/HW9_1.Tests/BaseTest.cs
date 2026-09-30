using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using HW9_1.Core.Configuration;
using HW9_1.Core.Factories;
using OpenQA.Selenium;

namespace HW9_1.Tests;

[AllureNUnit]
public abstract class BaseTest
{
    protected IWebDriver Driver = null!;
    protected TestSettings Settings = null!;

    [SetUp]
    [AllureBefore("Start browser")]
    public void SetUp()
    {
        Settings = ConfigurationProvider.GetSettings();

        AllureApi.AddTestParameter("browser", Settings.Browser);

        Driver = DriverFactory.CreateDriver(Settings);
        Driver.Manage().Window.Maximize();
    }

    [TearDown]
    [AllureAfter("Close browser")]
    public void TearDown()
    {
        Driver.Quit();
        Driver.Dispose();
    }
}