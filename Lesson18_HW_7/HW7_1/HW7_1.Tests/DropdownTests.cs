using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace HW7_1.Tests;

public class DropdownTests
{
    private IWebDriver _driver;
    private readonly By _dropdownLocator = By.Id("dropdown");
    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void DropdownTest()
    {
        _driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/dropdown");
        var dropdownElement = _driver.FindElement(_dropdownLocator);
        var dropdown = new SelectElement(dropdownElement);
        Assert.That(dropdown.Options.Count, Is.EqualTo(3));
        Assert.That(dropdown.Options[0].Text, Is.EqualTo("Please select an option"));
        Assert.That(dropdown.Options[1].Text, Is.EqualTo("Option 1"));
        Assert.That(dropdown.Options[2].Text, Is.EqualTo("Option 2"));
        dropdown.SelectByValue("1");
        Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 1"));
        dropdown.SelectByValue("2");
        Assert.That(dropdown.SelectedOption.Text, Is.EqualTo("Option 2"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}