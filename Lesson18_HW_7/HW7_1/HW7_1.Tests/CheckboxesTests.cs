using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW7_1.Tests;

public class CheckboxesTests
{
    private IWebDriver _driver;
    private readonly By _checkboxLocator = By.CssSelector("[type=checkbox]");

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void CheckboxesTest()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/checkboxes");
        var checkboxes = _driver.FindElements(_checkboxLocator);
        Assert.That(checkboxes.Count, Is.EqualTo(2));
        Assert.That(checkboxes[0].Selected, Is.False);
        Assert.That(checkboxes[1].Selected, Is.True);
        checkboxes[0].Click();
        Assert.That(checkboxes[0].Selected, Is.True);
        checkboxes[1].Click();
        Assert.That(checkboxes[1].Selected, Is.False);
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}