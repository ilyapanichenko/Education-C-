using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW7_1.Tests;

public class InputsTests
{
    private IWebDriver _driver;
    private readonly By _inputLocator  = By.TagName("input");
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void InputsTest()
    {
        _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/inputs");
        var input = _driver.FindElement(_inputLocator);
        input.SendKeys("a");
        Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
        input.Clear();
        input.SendKeys("1");
        Assert.That(input.GetAttribute("value"), Is.EqualTo("1"));
        input.Clear();
        input.SendKeys("-1");
        Assert.That(input.GetAttribute("value"), Is.EqualTo("-1"));
        input.Clear();
        input.SendKeys("!@#$%^&*");
        Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
        input.Clear();
        input.SendKeys(" ");
        Assert.That(input.GetAttribute("value"), Is.EqualTo(""));
        input.Clear();
        input.SendKeys("0");
        Assert.That(input.GetAttribute("value"), Is.EqualTo("0"));
        input.SendKeys(Keys.ArrowUp);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("1"));
        input.SendKeys(Keys.ArrowUp);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("2"));
        input.SendKeys(Keys.ArrowDown);
        Assert.That(input.GetAttribute("value"), Is.EqualTo("1"));
    }
    
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}