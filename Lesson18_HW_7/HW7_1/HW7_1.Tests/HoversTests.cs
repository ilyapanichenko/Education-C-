using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;

namespace HW7_1.Tests;

public class HoversTests
{
    private IWebDriver _driver;
    private readonly By _profilesLocator = By.ClassName("figure");

    [SetUp]
    public void Setup()
    {
        _driver = new ChromeDriver();
        _driver.Manage().Window.Maximize();
        _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        _driver.Navigate().GoToUrl("https://the-internet.herokuapp.com/hovers");
    }

    [TestCase(0, "name: user1")]
    [TestCase(1, "name: user2")]
    [TestCase(2, "name: user3")]
    public void ProfileTest(int profileIndex, string expectedName)
    {
        CheckProfile(profileIndex, expectedName);
    }
    private void CheckProfile(int profileIndex, string expectedName)
    {
        var actions = new Actions(_driver);
        var profiles = _driver.FindElements(_profilesLocator);
        Assert.That(profiles.Count, Is.EqualTo(3));
        actions.MoveToElement(profiles[profileIndex]).Perform();
        var name = profiles[profileIndex].FindElement(By.TagName("h5"));
        Assert.That(name.Text, Is.EqualTo(expectedName));
        var profileLink = profiles[profileIndex].FindElement(By.TagName("a"));
        Assert.That(profileLink.Text, Is.EqualTo("View profile"));
        profileLink.Click();
        var body = _driver.FindElement(By.TagName("body"));
        Assert.That(body.Text, Does.Not.Contain("Not Found"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}