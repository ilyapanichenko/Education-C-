using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HW8_1.Tests;

public class SauceDemoTests
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
    public void SauceDemoTest()
    {
        _driver.Navigate().GoToUrl("https://www.saucedemo.com");
        var cssTwoClasses = _driver.FindElement(
            By.CssSelector(".input_error.form_input"));
        var idLocator = _driver.FindElement(
            By.Id("user-name"));
        idLocator.SendKeys("standard_user");
        var passwordInput = _driver.FindElement(
            By.Id("password"));
        passwordInput.SendKeys("secret_sauce");
        var nameLocator = _driver.FindElement(
            By.Name("login-button"));
        nameLocator.Click();

        var classNameLocator = _driver.FindElement(
            By.ClassName("primary_header"));
        var tagNameLocator = _driver.FindElement(
            By.TagName("footer"));
        var linkTextLocator = _driver.FindElement(
            By.LinkText("Twitter"));
        var partialLinkTextLocator = _driver.FindElement(
            By.PartialLinkText("Face"));
        var xpathAttribute = _driver.FindElement(
            By.XPath("//div[@class='right_component']"));
        var xpathText = _driver.FindElement(
            By.XPath("//span[text()='Products']"));
        var xpathPartialAttribute = _driver.FindElement(
            By.XPath("//div[contains(@class, '_component')]"));
        var xpathPartialText = _driver.FindElement(
            By.XPath("//span[contains(text(), 'Prod')]"));
        var xpathAncestor = _driver.FindElement(
            By.XPath("//div[@class='right_component']/ancestor::div[@class='header_secondary_container']"));
        var xpathDescendant = _driver.FindElement(
            By.XPath("//div[@class='right_component']/descendant::option"));
        var xpathFollowing = _driver.FindElement(
            By.XPath("//span[text()='Products']/following::select"));
        var xpathParent = _driver.FindElement(
            By.XPath("//div[@class='right_component']/parent::div"));
        var xpathPreceding = _driver.FindElement(
            By.XPath("//select[@class='product_sort_container']/preceding::span[text()='Products']"));
        var xpathAnd = _driver.FindElement(
            By.XPath("//select[@class='product_sort_container' and @data-test='product-sort-container']"));
        var cssClass = _driver.FindElement(
            By.CssSelector(".select_container"));
        var cssNestedClasses = _driver.FindElement(
            By.CssSelector(".header_secondary_container .title"));
        var cssId = _driver.FindElement(
            By.CssSelector("#root"));
        var cssTagName = _driver.FindElement(
            By.CssSelector("a"));
        var cssTagAndClass = _driver.FindElement(
            By.CssSelector("div.inventory_item_img"));
        var cssAttributeEquals = _driver.FindElement(
            By.CssSelector("div[class='inventory_item_img']"));
        var cssAttributeContainsWord = _driver.FindElement(
            By.CssSelector("div[class~='inventory_item_img']"));
        var cssAttributePrefix = _driver.FindElement(
            By.CssSelector("[data-test|='product']"));
        var cssAttributeStartsWith = _driver.FindElement(
            By.CssSelector("[class^='inventory']"));
        var cssAttributeEndsWith = _driver.FindElement(
            By.CssSelector("[class$='item_img']"));
        var cssAttributeContains = _driver.FindElement(
            By.CssSelector("[class*='item_img']"));
    }

    [TearDown]
    public void TearDown()
    {
        _driver.Quit();
        _driver.Dispose();
    }
}