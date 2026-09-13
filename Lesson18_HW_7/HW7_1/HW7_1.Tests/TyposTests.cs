

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW7_1.Tests;

public class TyposTests
{
    private IWebDriver _driver;
    private readonly By _locatorTypos = By.TagName("p");
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }
    [Test]
    public void TyposTest()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/typos");
        var typosElements = _driver.FindElements(_locatorTypos);
        Assert.That(typosElements[0].Text, Is.EqualTo("This example demonstrates a typo being introduced. It does it randomly on each page load."));
        Assert.That(typosElements[1].Text, Is.EqualTo("Sometimes you'll see a typo, other times you won't."));
    }
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}