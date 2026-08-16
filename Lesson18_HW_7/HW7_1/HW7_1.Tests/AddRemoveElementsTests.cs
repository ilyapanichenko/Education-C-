using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW7_1.Tests;

public class AddRemoveElementsTests
{
    private IWebDriver _driver;
    private readonly By _addButtonLocator = By.XPath("//button[text()='Add Element']");
    private readonly By _deleteButtonLocator = By.XPath("//button[text()='Delete']");

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
    }

    [Test]
    public void AddRemoveElementsTest()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/add_remove_elements/");
        var addButton = _driver.FindElement(_addButtonLocator);
        addButton.Click();
        var deleteButtons = _driver.FindElements(_deleteButtonLocator);
        Assert.That(deleteButtons.Count, Is.EqualTo(1));
        addButton.Click();
        deleteButtons = _driver.FindElements(_deleteButtonLocator);
        Assert.That(deleteButtons.Count, Is.EqualTo(2));
        deleteButtons[0].Click();
        deleteButtons = _driver.FindElements(_deleteButtonLocator);
        Assert.That(deleteButtons.Count, Is.EqualTo(1));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}