using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace HW7_1.Tests;

public class NotificationTests
{
    private IWebDriver _driver;

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void NotificationTest()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/notification_message_rendered");
        var link = _driver.FindElement(By.XPath("//a[text()='Click here']"));
        link.Click();
        var notification = _driver.FindElement(By.Id("flash"));
        Assert.That(notification.Text, Does.Contain("Action successful"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}