using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW7_1.Tests;

public class TablesTests
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
    public void TestTables()
    {
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/tables");
        var firstElement = _driver.FindElement(By.XPath("//table[1]//tr[1]//td[1]"));
        Assert.That(firstElement.Text, Is.EqualTo("Smith"));
        var secondElement = _driver.FindElement(By.XPath("//table[1]//tr[1]//td[2]"));
        Assert.That(secondElement.Text, Is.EqualTo("John"));
        var thirdElement = _driver.FindElement(By.XPath("//table[1]//tr[1]//td[3]"));
        Assert.That(thirdElement.Text, Is.EqualTo("jsmith@gmail.com"));
    }
    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}